defmodule AdventWeb.SolutionLive.Index do
  use AdventWeb, :live_view
  alias Advent.Aoc

  @impl true
  def mount(%{"day" => day, "part" => part}, _session, socket) do
    day = String.to_integer(day)
    part = String.to_integer(part)

    inputs = Aoc.list_inputs_for_day_part(day, part)

    # Create a unique key for this LiveView session's speed setting
    session_id = :crypto.strong_rand_bytes(16) |> Base.encode64()

    {:ok,
     socket
     |> assign(:day, day)
     |> assign(:part, part)
     |> assign(:inputs, inputs)
     |> assign(:selected_input, nil)
     |> assign(:solving, false)
     |> assign(:result, nil)
     |> assign(:visualization_state, nil)
     |> assign(:enable_visualization, false)
     |> assign(:visualization_speed, 100)
     |> assign(:solve_time, nil)
     |> assign(:session_id, session_id)
     |> assign(:visualization_available, visualization_available?(day, part))}
  end

  @impl true
  def handle_event("select_input", %{"id" => id}, socket) do
    input = Enum.find(socket.assigns.inputs, &(&1.id == String.to_integer(id)))
    {:noreply, assign(socket, :selected_input, input)}
  end

  @impl true
  def handle_event("toggle_visualization", _params, socket) do
    new_viz_state = !socket.assigns.enable_visualization

    # If disabling visualization while solving, set speed to 0 immediately
    if !new_viz_state and socket.assigns.solving do
      Process.put({:viz_speed, socket.assigns.session_id}, 0)
    end

    # If enabling visualization while solving, restore the speed
    if new_viz_state and socket.assigns.solving do
      Process.put({:viz_speed, socket.assigns.session_id}, socket.assigns.visualization_speed)
    end

    {:noreply, assign(socket, :enable_visualization, new_viz_state)}
  end

  @impl true
  def handle_event("set_speed", %{"speed" => speed}, socket) do
    speed_val = if is_binary(speed), do: String.to_integer(speed), else: speed

    # Store the speed in process dictionary with session key
    # The solver task will read from this
    Process.put({:viz_speed, socket.assigns.session_id}, speed_val)

    {:noreply, assign(socket, :visualization_speed, speed_val)}
  end

  @impl true
  def handle_event("solve", _params, socket) do
    IO.puts("========== SOLVE BUTTON CLICKED ==========")

    if socket.assigns.selected_input do
      IO.puts("Selected input found, starting solver task")
      send(self(), :solve_step)

      {:noreply,
       assign(socket, solving: true, result: nil, visualization_state: nil, solve_time: nil)}
    else
      IO.puts("ERROR: No input selected")
      {:noreply, put_flash(socket, :error, "Please select an input first")}
    end
  end

  @impl true
  def handle_info(:solve_step, socket) do
    IO.puts("========== SOLVE_STEP MESSAGE RECEIVED ==========")

    day = socket.assigns.day
    part = socket.assigns.part

    if socket.assigns.selected_input do
      input = socket.assigns.selected_input.input
      parent = self()
      enable_viz = socket.assigns.enable_visualization
      session_id = socket.assigns.session_id

      # Store initial speed in process dictionary
      Process.put({:viz_speed, session_id}, socket.assigns.visualization_speed)

      IO.inspect("Solving Day #{day}, Part #{part}", label: "SOLUTION")

      solver_module = get_solver_module(day, part)
      IO.inspect(solver_module, label: "Solver module")

      case solver_module do
        {:ok, module} ->
          IO.puts("Starting solver in background task")

          start_time = System.monotonic_time(:millisecond)

          Task.start(fn ->
            try do
              callback =
                if enable_viz do
                  fn state ->
                    send(parent, {:update_visualization, state})
                  end
                else
                  nil
                end

              # Pass the session_id and parent PID so solver can read current speed
              result = module.solve(input, callback, {parent, session_id})

              end_time = System.monotonic_time(:millisecond)
              solve_time = end_time - start_time

              send(parent, {:solver_complete, result, solve_time})
            rescue
              error ->
                IO.inspect(error, label: "ERROR in solver task")
                send(parent, {:solver_complete, "Error: #{inspect(error)}", 0})
            end
          end)

        {:error, reason} ->
          IO.inspect(reason, label: "ERROR")
          {:noreply, assign(socket, solving: false, result: reason)}
      end

      {:noreply, socket}
    else
      IO.puts("ERROR: selected_input is nil in handle_info")
      {:noreply, assign(socket, solving: false, result: "No input selected")}
    end
  end

  @impl true
  def handle_info({:update_visualization, state}, socket) do
    if socket.assigns.enable_visualization do
      {:noreply, assign(socket, :visualization_state, state)}
    else
      {:noreply, socket}
    end
  end

  @impl true
  def handle_info({:solver_complete, result, solve_time}, socket) do
    IO.inspect(result, label: "Solver complete")

    # Clean up the speed from process dictionary
    Process.delete({:viz_speed, socket.assigns.session_id})

    {:noreply, assign(socket, solving: false, result: result, solve_time: solve_time)}
  end

  @impl true
  def handle_info({:get_speed, task_pid, session_id}, socket) do
    # Send current speed back to the solver task
    speed = Process.get({:viz_speed, session_id}, socket.assigns.visualization_speed)
    send(task_pid, {:speed, speed})
    {:noreply, socket}
  end

  defp get_solver_module(day, part) do
    day_str = String.pad_leading(Integer.to_string(day), 2, "0")

    module_name =
      Module.concat([
        Advent.Solvers,
        "Day#{day_str}",
        "Part#{part}"
      ])

    if Code.ensure_loaded?(module_name) do
      {:ok, module_name}
    else
      {:error, "Solver not implemented for Day #{day}, Part #{part}"}
    end
  end

  defp get_visualization_component(day, part) do
    day_str = String.pad_leading(Integer.to_string(day), 2, "0")

    module_name =
      Module.concat([
        AdventWeb.SolutionLive.Visualizations,
        "Day#{day_str}Part#{part}"
      ])

    if Code.ensure_loaded?(module_name) do
      {:ok, module_name}
    else
      # Use default visualization if not implemented
      {:ok, AdventWeb.Live.SolutionLive.Visualizations.Default}
    end
  end

  # Returns true if a visualization component is implemented for the given day/part
  defp visualization_available?(day, part) do
    day_str = String.pad_leading(Integer.to_string(day), 2, "0")

    module_name =
      Module.concat([
        AdventWeb.SolutionLive.Visualizations,
        "Day#{day_str}Part#{part}"
      ])

    Code.ensure_loaded?(module_name)
  end
end
