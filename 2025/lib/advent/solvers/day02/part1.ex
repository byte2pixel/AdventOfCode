defmodule Advent.Solvers.Day02.Part1 do
  @moduledoc """
  Solver for Day 2, Part 1: Range Problem
  """

  @behaviour Advent.Solvers.Behaviours.Solver
  alias Advent.Solvers.Day02.Parser

  def solve(input, _step_callback \\ nil, _speed_context \\ nil) do
    IO.inspect("Starting Day 2, Part 1 solver", label: "SOLVER")
    ranges = parse(input)

    Enum.reduce(ranges, 0, fn {start_range, end_range}, acc ->
      acc + compute_special_sum(start_range, end_range)
    end)
  end

  @impl true
  def parse(input), do: Parser.parse_input(input)

  defp compute_special_sum(start_id, end_id) do
    start_id..end_id
    |> Enum.filter(fn id ->
      id_str = Integer.to_string(id)
      len = String.length(id_str)

      # Check for even length and repeated sequence
      rem(len, 2) == 0 and
        (fn ->
          half_len = div(len, 2)
          {first_half, second_half} = String.split_at(id_str, half_len)
          first_half == second_half
        end).()
    end)
    |> Enum.sum()
  end
end
