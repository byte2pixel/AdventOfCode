defmodule AdventWeb.InputLive.FormComponent do
  use AdventWeb, :live_component

  alias Advent.Aoc

  @impl true
  def render(assigns) do
    ~H"""
    <div>
      <.header>
        {@title}
        <:subtitle>Use this form to manage input records in your database.</:subtitle>
      </.header>

      <.simple_form
        for={@form}
        id="input-form"
        phx-target={@myself}
        phx-change="validate"
        phx-submit="save"
      >
        <.input
          field={@form[:day]}
          type="select"
          label="Day"
          options={Enum.map(1..12, &{Integer.to_string(&1), &1})}
        />
        <.input
          field={@form[:part]}
          type="select"
          label="Part"
          options={Enum.map(1..2, &{Integer.to_string(&1), &1})}
        />
        <.input
          field={@form[:input_type]}
          type="select"
          label="Input type"
          options={[{"Test", "test"}, {"Full", "full"}]}
        />
        <.input field={@form[:input]} type="textarea" label="Input" rows={10} />
        <:actions>
          <.button phx-disable-with="Saving...">Save Input</.button>
        </:actions>
      </.simple_form>
    </div>
    """
  end

  @impl true
  def update(%{input: input} = assigns, socket) do
    {:ok,
     socket
     |> assign(assigns)
     |> assign_new(:form, fn ->
       to_form(Aoc.change_input(input))
     end)}
  end

  @impl true
  def handle_event("validate", %{"input" => input_params}, socket) do
    changeset = Aoc.change_input(socket.assigns.input, input_params)
    {:noreply, assign(socket, form: to_form(changeset, action: :validate))}
  end

  def handle_event("save", %{"input" => input_params}, socket) do
    save_input(socket, socket.assigns.action, input_params)
  end

  defp save_input(socket, :edit, input_params) do
    case Aoc.update_input(socket.assigns.input, input_params) do
      {:ok, input} ->
        notify_parent({:saved, input})

        {:noreply,
         socket
         |> put_flash(:info, "Input updated successfully")
         |> push_patch(to: socket.assigns.patch)}

      {:error, %Ecto.Changeset{} = changeset} ->
        {:noreply, assign(socket, form: to_form(changeset))}
    end
  end

  defp save_input(socket, :new, input_params) do
    case Aoc.create_input(input_params) do
      {:ok, input} ->
        notify_parent({:saved, input})

        {:noreply,
         socket
         |> put_flash(:info, "Input created successfully")
         |> push_patch(to: socket.assigns.patch)}

      {:error, %Ecto.Changeset{} = changeset} ->
        {:noreply, assign(socket, form: to_form(changeset))}
    end
  end

  defp notify_parent(msg), do: send(self(), {__MODULE__, msg})
end
