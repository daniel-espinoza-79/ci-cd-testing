#!/bin/bash
echo "Starting migrations..."

# Function to execute migrations
run_migrations() {
    local service_name=$1
    local service_path=$2

    echo "Running migrations for ${service_name}..."
    cd ${service_path} || { echo "Error: Could not navigate to ${service_path}"; exit 1; }

    dotnet ef migrations add InitialCreate || { echo "Error: Failed to add migrations for ${service_name}"; exit 1; }
    dotnet ef database update || { echo "Error: Failed to update database for ${service_name}"; exit 1; }

    echo "Migrations completed for ${service_name}."
}

# Run migrations for each service
run_migrations "UserService" "/app/MigrationsConfig/UserServiceMigration"
run_migrations "InventoryService" "/app/MigrationsConfig/InventoryServiceMigration"
run_migrations "PaymentService" "/app/MigrationsConfig/PaymentServiceMigration"

echo "All migrations completed successfully."
