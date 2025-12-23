defmodule Advent.Repo do
  use Ecto.Repo,
    otp_app: :advent,
    adapter: Ecto.Adapters.Postgres
end
