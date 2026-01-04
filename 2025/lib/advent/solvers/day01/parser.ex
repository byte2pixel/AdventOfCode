defmodule Advent.Solvers.Day01.Parser do
  @moduledoc """
  Shared parser for Day 1 solvers.
  """

  def parse_input(input) do
    input
    |> String.split("\n", trim: true)
    |> Enum.map(&parse_rotation/1)
  end

  def parse_rotation(line) do
    <<dir::binary-size(1), distance::binary>> = line
    {dir, String.to_integer(distance)}
  end
end