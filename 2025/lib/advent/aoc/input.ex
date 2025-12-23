defmodule Advent.Aoc.Input do
  use Ecto.Schema
  import Ecto.Changeset

  schema "inputs" do
    field :input, :string
    field :part, :integer
    field :day, :integer
    field :input_type, :string

    timestamps(type: :utc_datetime)
  end

  @doc false
  def changeset(input, attrs) do
    input
    |> cast(attrs, [:day, :part, :input_type, :input])
    |> validate_required([:day, :part, :input_type, :input])
  end
end
