#!/bin/bash

set -e  # Exit on any error
cat infrastructure.env services.env >> .env


# Function to start services without migrations
start_services() {
  echo "Starting services without migrations..."
  docker compose -f docker-compose.networks.yml -f docker-compose.volumes.yml -f docker-compose.infrastructure.yml -f docker-compose.services.yml up  --build
}

# Function to stop and remove services (down)
stop_services() {
  echo "Stopping and removing all containers, networks, and volumes..."
  docker compose -f docker-compose.networks.yml -f docker-compose.volumes.yml -f docker-compose.infrastructure.yml -f docker-compose.services.yml down -v
}

# Check the first parameter to determine action
case "$1" in
  "down")
    echo "Stopping services..."
    stop_services
    ;;
  *)
    echo "Running normally..."
    start_services
    ;;
esac

# Confirm successful execution
echo "Operation completed successfully."

rm .env