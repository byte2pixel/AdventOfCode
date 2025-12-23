defmodule AdventWeb.SolutionLive.Visualizations.Day01Part1 do
  use Phoenix.LiveComponent

  def update(assigns, socket) do
    # Provide default state if nil
    state = assigns.state || %{position: 50, degrees: 180.0, count: 0, rotation: {"Start", 0}}
    {:ok, assign(socket, state: state)}
  end

  def render(assigns) do
    ~H"""
    <div class="text-center">
      <p class="text-zinc-600 mb-4 font-semibold">Safe Dial</p>
      <div class="relative w-64 h-64 mx-auto">
        <svg viewBox="0 0 200 200" class="w-full h-full">
          <!-- Outer circle -->
          <circle cx="100" cy="100" r="90" fill="none" stroke="#d4d4d8" stroke-width="2" />
          
    <!-- Position 0 marker at top -->
          <circle cx="100" cy="10" r="4" fill="#3b82f6" />
          
    <!-- Tick marks every 10 positions -->
          <%= for i <- [10, 20, 30, 40, 50, 60, 70, 80, 90] do %>
            <% angle = (i * 3.6 - 90) * :math.pi() / 180 %>
            <% x = 100 + 85 * :math.cos(angle) %>
            <% y = 100 + 85 * :math.sin(angle) %>
            <text x={x} y={y + 6} text-anchor="middle" class="text-xs fill-zinc-400">
              {i}
            </text>
          <% end %>
          
    <!-- Green flash when at position 0 -->
          <circle
            :if={@state.position == 0}
            cx="100"
            cy="100"
            r="95"
            fill="none"
            stroke="#22c55e"
            stroke-width="5"
            opacity="0.6"
            class="animate-pulse"
          />
          
    <!-- Dial pointer - use cumulative degrees for smooth animation -->
          <g class="dial-pointer" style={"transform: rotate(#{@state.degrees}deg);"}>
            <line
              x1="100"
              y1="100"
              x2="100"
              y2="20"
              stroke="#ef4444"
              stroke-width="3"
              stroke-linecap="round"
            />
            <circle cx="100" cy="100" r="6" fill="#ef4444" />
          </g>
          
    <!-- Current position text -->
          <text x="100" y="165" text-anchor="middle" class="text-3xl font-bold fill-zinc-800">
            {@state.position}
          </text>
        </svg>
      </div>

      <div class="mt-6 space-y-2">
        <p class="text-sm text-zinc-600">
          Times at 0: <span class="font-bold text-green-600 text-lg">{@state.count}</span>
        </p>
        <p :if={@state.rotation && elem(@state.rotation, 0) != "Start"} class="text-xs text-zinc-400">
          Last rotation:
          <span class="font-mono bg-zinc-100 px-2 py-1 rounded">
            {elem(@state.rotation, 0)}{elem(@state.rotation, 1)}
          </span>
        </p>
      </div>
    </div>
    """
  end
end
