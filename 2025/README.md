# Advent 2025

A Phoenix web app for solving Advent of Code 2025 puzzles with input management and visualizations.

**Requirements**

This repo comes with a devcontainer configuration for Visual Studio Code.  If you do not use devcontainers, you will need to install the following dependencies:

  * [Elixir](https://elixir-lang.org/install.html) ~> 1.16
  * [Erlang/OTP](https://www.erlang.org/downloads) ~> 26.0
  * [PostgreSQL](https://www.postgresql.org/download/) ~> 16

## Setup

This project assumes access to a PostgreSQL database. If you don't have one, you can modify `docker-compose.yml` to include a Postgres service or use a local/cloud instance. Update the `DATABASE_URL` in your `.env` file accordingly.

  * Copy `.env.example` to `.env` and set your own values
  * If you do not have a postgres server modify the `docker-compose.yml` to add a postgres service.

To start your Phoenix server:

  - Open this folder in Visual Studio Code.
  - Launch the Dev Container.
  - Open a terminal in the container.
  - Install dependencies with `mix deps.get`
  - Create and migrate your database with `mix ecto.setup`
  - Start Phoenix endpoint with `mix phx.server`
  - Visit [`localhost:4000`](http://localhost:4000) from your browser

If not using the devcontainer, ensure the dependencies are installed, then run the setup steps in a terminal.

## Troubleshooting

- **Database Connection Errors**: Verify your `DATABASE_URL` in `.env` is correct and the database is running.
- **Port Conflicts**: If port 4000 is in use, change it in `config/dev.exs` or set `PORT` environment variable.
- **Dependency Issues**: Run `mix deps.clean --all` and `mix deps.get` if you encounter compilation errors.

## Adding Input for Each Day

According to Advent of Code's rules. I cannot redistribute the input.  You will need to visit the input for each day and paste the input into the text area provided in the web app.

From the app:
  - Click on manage inputs
  - Select the day you want to add input for
  - Select the input type: test input or actual input
  - Paste the input into the text area
  - Submit

## Solving Problems

From the main page:
  - Select the day + part you want to solve
  - Choose your input (test or actual)
  - Set your visualization options
  - Click "Solve"
  - The result will be displayed.

## Resources

- [Advent of Code 2025](https://adventofcode.com/2025)
- [Phoenix Framework Documentation](https://hexdocs.pm/phoenix/)
- [Elixir Documentation](https://elixir-lang.org/docs.html)
