#!/bin/bash

set -e  # Exit on any error

# Combine environment variables into a single .env file
echo "Merging environment files..."
cat infrastructure.env services.env > .env

# Step 1: Start Infrastructure
echo "Starting infrastructure..."
docker compose --env-file .env -f docker-compose.networks.yml -f docker-compose.volumes.yml -f docker-compose.infrastructure.yml up --build -d

# Step 2: Wait for Infrastructure to Be Healthy
echo "Waiting for infrastructure to be ready..."
services=("user_service_db" "payment_service_db" "inventory_service_db" "rabbitmq")
for service in "${services[@]}"; do
  echo "Waiting for $service to be healthy..."
  while [[ "$(docker inspect -f '{{.State.Health.Status}}' $service)" != "healthy" ]]; do
    sleep 5
    echo "Still waiting for $service..."
  done
  echo "$service is healthy!"
done

# Step 3: Run Migrations
echo "Running migrations..."
docker run --rm --env-file .env danielespinoza/migrations:v1.0.0

# Step 4: Start Application Services
echo "Starting application services..."
docker compose --env-file .env -f docker-compose.services.yml up --build -d

# Confirm successful execution
echo "All services have been started successfully, and migrations are complete."
