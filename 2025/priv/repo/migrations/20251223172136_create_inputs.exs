defmodule Advent.Repo.Migrations.CreateInputs do
  use Ecto.Migration

  def change do
    create table(:inputs) do
      add :day, :integer
      add :part, :integer
      add :input_type, :string
      add :input, :text

      timestamps(type: :utc_datetime)
    end
  end
end
