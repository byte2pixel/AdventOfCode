defmodule Advent.Solvers.Behaviours.Solver do
  @moduledoc """
  Behaviour for Advent of Code solvers. Each solver must implement a parse/1 function.
  """

  @callback parse(input :: String.t()) :: any()
end
