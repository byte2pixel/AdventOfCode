defmodule AdventWeb.Live.SolutionLive.Visualizations.Default do
  @moduledoc """
  Default visualization for Advent solutions.
  """

  use Phoenix.LiveComponent

  def update(assigns, socket) do
    {:ok, assign(socket, assigns)}
  end

  def render(assigns) do
    ~H"""
    <div class="text-zinc-400 text-center">No visualization implemented for this day/part.</div>
    """
  end
end
