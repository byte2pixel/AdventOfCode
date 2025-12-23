defmodule Advent.AocTest do
  use Advent.DataCase

  alias Advent.Aoc

  describe "inputs" do
    alias Advent.Aoc.Input

    import Advent.AocFixtures

    @invalid_attrs %{input: nil, part: nil, day: nil, input_type: nil}

    test "list_inputs/0 returns all inputs" do
      input = input_fixture()
      assert Aoc.list_inputs() == [input]
    end

    test "get_input!/1 returns the input with given id" do
      input = input_fixture()
      assert Aoc.get_input!(input.id) == input
    end

    test "create_input/1 with valid data creates a input" do
      valid_attrs = %{input: "some input", part: 42, day: 42, input_type: "some input_type"}

      assert {:ok, %Input{} = input} = Aoc.create_input(valid_attrs)
      assert input.input == "some input"
      assert input.part == 42
      assert input.day == 42
      assert input.input_type == "some input_type"
    end

    test "create_input/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = Aoc.create_input(@invalid_attrs)
    end

    test "update_input/2 with valid data updates the input" do
      input = input_fixture()
      update_attrs = %{input: "some updated input", part: 43, day: 43, input_type: "some updated input_type"}

      assert {:ok, %Input{} = input} = Aoc.update_input(input, update_attrs)
      assert input.input == "some updated input"
      assert input.part == 43
      assert input.day == 43
      assert input.input_type == "some updated input_type"
    end

    test "update_input/2 with invalid data returns error changeset" do
      input = input_fixture()
      assert {:error, %Ecto.Changeset{}} = Aoc.update_input(input, @invalid_attrs)
      assert input == Aoc.get_input!(input.id)
    end

    test "delete_input/1 deletes the input" do
      input = input_fixture()
      assert {:ok, %Input{}} = Aoc.delete_input(input)
      assert_raise Ecto.NoResultsError, fn -> Aoc.get_input!(input.id) end
    end

    test "change_input/1 returns a input changeset" do
      input = input_fixture()
      assert %Ecto.Changeset{} = Aoc.change_input(input)
    end
  end
end
