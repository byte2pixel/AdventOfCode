defmodule AdventWeb.InputLive.Index do
  use AdventWeb, :live_view

  alias Advent.Aoc
  alias Advent.Aoc.Input

  @impl true
  def mount(_params, _session, socket) do
    {:ok, stream(socket, :inputs, Aoc.list_inputs())}
  end

  @impl true
  def handle_params(params, _url, socket) do
    {:noreply, apply_action(socket, socket.assigns.live_action, params)}
  end

  defp apply_action(socket, :edit, %{"id" => id}) do
    socket
    |> assign(:page_title, "Edit Input")
    |> assign(:input, Aoc.get_input!(id))
  end

  defp apply_action(socket, :new, _params) do
    socket
    |> assign(:page_title, "New Input")
    |> assign(:input, %Input{})
  end

  defp apply_action(socket, :index, _params) do
    socket
    |> assign(:page_title, "Listing Inputs")
    |> assign(:input, nil)
  end

  @impl true
  def handle_info({AdventWeb.InputLive.FormComponent, {:saved, input}}, socket) do
    {:noreply, stream_insert(socket, :inputs, input)}
  end

  @impl true
  def handle_event("delete", %{"id" => id}, socket) do
    input = Aoc.get_input!(id)
    {:ok, _} = Aoc.delete_input(input)

    {:noreply, stream_delete(socket, :inputs, input)}
  end
end
