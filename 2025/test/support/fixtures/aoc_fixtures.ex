defmodule Advent.AocFixtures do
  @moduledoc """
  This module defines test helpers for creating
  entities via the `Advent.Aoc` context.
  """

  @doc """
  Generate a input.
  """
  def input_fixture(attrs \\ %{}) do
    {:ok, input} =
      attrs
      |> Enum.into(%{
        day: 42,
        input: "some input",
        input_type: "some input_type",
        part: 42
      })
      |> Advent.Aoc.create_input()

    input
  end
end
