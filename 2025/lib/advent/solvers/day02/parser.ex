defmodule Advent.Solvers.Day02.Parser do
  @moduledoc """
  Shared parser for Day 2 solvers.
  """

  def parse_input(input) do
    input
    |> String.split(",", trim: true)
    |> Enum.map(&parse_range/1)
  end

  def parse_range(range) do
    [start_str, end_str] = String.split(range, "-")
    {String.to_integer(start_str), String.to_integer(end_str)}
  end
end
