#!/bin/bash

set -e

cat infrastructure.env services.env > .env

# Create directories only if they don't exist
mkdir -p user_service_data
mkdir -p inventory_service_data
mkdir -p payment_service_data

# Start infrastructure and application services in detached mode
docker compose --env-file .env -f docker-compose.networks.yml -f docker-compose.volumes.yml -f docker-compose.infrastructure.yml -f docker-compose.services.yml up --build

# Confirm that all services have started successfully
echo "All services have been successfully started."


docker cp infrastructure-user-service-1:/app/ user_service_data