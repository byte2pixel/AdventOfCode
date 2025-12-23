defmodule AdventWeb.InputLiveTest do
  use AdventWeb.ConnCase

  import Phoenix.LiveViewTest
  import Advent.AocFixtures

  @create_attrs %{input: "some input", part: 42, day: 42, input_type: "some input_type"}
  @update_attrs %{input: "some updated input", part: 43, day: 43, input_type: "some updated input_type"}
  @invalid_attrs %{input: nil, part: nil, day: nil, input_type: nil}

  defp create_input(_) do
    input = input_fixture()
    %{input: input}
  end

  describe "Index" do
    setup [:create_input]

    test "lists all inputs", %{conn: conn, input: input} do
      {:ok, _index_live, html} = live(conn, ~p"/inputs")

      assert html =~ "Listing Inputs"
      assert html =~ input.input
    end

    test "saves new input", %{conn: conn} do
      {:ok, index_live, _html} = live(conn, ~p"/inputs")

      assert index_live |> element("a", "New Input") |> render_click() =~
               "New Input"

      assert_patch(index_live, ~p"/inputs/new")

      assert index_live
             |> form("#input-form", input: @invalid_attrs)
             |> render_change() =~ "can&#39;t be blank"

      assert index_live
             |> form("#input-form", input: @create_attrs)
             |> render_submit()

      assert_patch(index_live, ~p"/inputs")

      html = render(index_live)
      assert html =~ "Input created successfully"
      assert html =~ "some input"
    end

    test "updates input in listing", %{conn: conn, input: input} do
      {:ok, index_live, _html} = live(conn, ~p"/inputs")

      assert index_live |> element("#inputs-#{input.id} a", "Edit") |> render_click() =~
               "Edit Input"

      assert_patch(index_live, ~p"/inputs/#{input}/edit")

      assert index_live
             |> form("#input-form", input: @invalid_attrs)
             |> render_change() =~ "can&#39;t be blank"

      assert index_live
             |> form("#input-form", input: @update_attrs)
             |> render_submit()

      assert_patch(index_live, ~p"/inputs")

      html = render(index_live)
      assert html =~ "Input updated successfully"
      assert html =~ "some updated input"
    end

    test "deletes input in listing", %{conn: conn, input: input} do
      {:ok, index_live, _html} = live(conn, ~p"/inputs")

      assert index_live |> element("#inputs-#{input.id} a", "Delete") |> render_click()
      refute has_element?(index_live, "#inputs-#{input.id}")
    end
  end

  describe "Show" do
    setup [:create_input]

    test "displays input", %{conn: conn, input: input} do
      {:ok, _show_live, html} = live(conn, ~p"/inputs/#{input}")

      assert html =~ "Show Input"
      assert html =~ input.input
    end

    test "updates input within modal", %{conn: conn, input: input} do
      {:ok, show_live, _html} = live(conn, ~p"/inputs/#{input}")

      assert show_live |> element("a", "Edit") |> render_click() =~
               "Edit Input"

      assert_patch(show_live, ~p"/inputs/#{input}/show/edit")

      assert show_live
             |> form("#input-form", input: @invalid_attrs)
             |> render_change() =~ "can&#39;t be blank"

      assert show_live
             |> form("#input-form", input: @update_attrs)
             |> render_submit()

      assert_patch(show_live, ~p"/inputs/#{input}")

      html = render(show_live)
      assert html =~ "Input updated successfully"
      assert html =~ "some updated input"
    end
  end
end
