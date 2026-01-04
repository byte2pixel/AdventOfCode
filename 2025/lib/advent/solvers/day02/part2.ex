defmodule Advent.Solvers.Day02.Part2 do
  @moduledoc """
  Solver for Day 2, Part 2: Range Problem
  """

  @behaviour Advent.Solvers.Behaviours.Solver
  alias Advent.Solvers.Day02.Parser

  def solve(input, _step_callback \\ nil, _speed_context \\ nil) do
    IO.inspect("Starting Day 2, Part 2 solver", label: "SOLVER")
    ranges = parse(input)

    IO.inspect(ranges, label: "RANGES")

    # Collect all matching IDs in a MapSet to ensure uniqueness
    unique_ids =
      Enum.reduce(ranges, MapSet.new(), fn {start_range, end_range}, acc_set ->
        IO.inspect({start_range, end_range}, label: "Current Range")
        ids = compute_special_ids(start_range, end_range)
        MapSet.union(acc_set, MapSet.new(ids))
      end)

    # Sum only unique IDs
    MapSet.to_list(unique_ids) |> Enum.sum()
  end

  @impl true
  def parse(input), do: Parser.parse_input(input)

  defp compute_special_ids(start_id, end_id) do
    IO.inspect({start_id, end_id}, label: "compute_special_ids range")

    range = start_id..end_id
    IO.inspect(Enum.count(range), label: "Range count")

    range
    |> Enum.filter(fn id ->
      id_str = Integer.to_string(id)
      len = String.length(id_str)
      # Skip single-digit IDs
      if len == 1 do
        false
      else
        # compute multiples of length.
        split_at_list =
          for n <- 1..(len - 1), n > 0 and rem(len, n) == 0 do
            n
          end

        result =
          Enum.any?(split_at_list, fn split_at ->
            # Only chunk if split_at > 0 and divides length evenly
            if split_at > 0 and rem(len, split_at) == 0 do
              parts = String.split(id_str, "", trim: true) |> Enum.chunk_every(split_at)
              Enum.uniq(parts) |> length() == 1
            else
              false
            end
          end)

        if result, do: IO.inspect(id, label: "Matching id")
        result
      end
    end)
  end
end
