FROM elixir:1.18.4-otp-28
# Install build dependencies and Elixir tools
RUN apt-get update && apt-get install -y \
    build-essential \
    curl \
    git \
    inotify-tools \
    nodejs \
    npm \
    postgresql-client \
    watchman \
    wget \
    zsh \
    zsh-autosuggestions \
    zsh-syntax-highlighting \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/* && \
    mix local.hex --force && \
    mix local.rebar --force

WORKDIR /advent
