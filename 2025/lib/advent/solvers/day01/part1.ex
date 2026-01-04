defmodule Advent.Solvers.Day01.Part1 do
  @moduledoc """
  Solver for Day 1, Part 1: Safe Dial Problem
  """

  @behaviour Advent.Solvers.Behaviours.Solver
  alias Advent.Solvers.Day01.Parser

  def solve(input, step_callback \\ nil, speed_context \\ nil) do
    IO.inspect("Starting Day 1, Part 1 solver", label: "SOLVER")

    rotations = parse(input)

    {_final_position, _final_degrees, final_rotations} =
      Enum.reduce(rotations, {50, 180.0, 0}, fn rotation, {pos, degrees, count} ->
        new_pos = apply_rotation(pos, rotation)

        rotation_degrees =
          case rotation do
            {"L", distance} ->
              -rem(distance, 100) * 3.6

            {"R", distance} ->
              rem(distance, 100) * 3.6
          end

        new_degrees = degrees + rotation_degrees

        new_degrees =
          cond do
            new_degrees > 720 -> new_degrees - 360
            new_degrees < -360 -> new_degrees + 360
            true -> new_degrees
          end

        new_count = if new_pos == 0, do: count + 1, else: count

        if step_callback do
          step_callback.(%{
            position: new_pos,
            degrees: new_degrees,
            count: new_count,
            rotation: rotation
          })

          # Read current speed from parent process dictionary
          delay =
            case speed_context do
              {parent_pid, session_id} ->
                # Ask parent process for current speed
                send(parent_pid, {:get_speed, self(), session_id})

                receive do
                  {:speed, speed} -> speed
                after
                  100 -> 100
                end

              _ ->
                0
            end

          if delay > 0 do
            Process.sleep(delay)
          end
        end

        {new_pos, new_degrees, new_count}
      end)

    final_rotations
  end

  @impl true
  def parse(input), do: Parser.parse_input(input)

  defp apply_rotation(position, {"L", distance}) do
    result = rem(position - distance, 100)
    if result < 0, do: result + 100, else: result
  end

  defp apply_rotation(position, {"R", distance}) do
    rem(position + distance, 100)
  end
end
