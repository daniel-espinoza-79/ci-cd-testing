FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY MigrationsConfig/ MigrationsConfig/
COPY InventoryService/src/InventoryService.Intraestructure/ InventoryService/src/InventoryService.Intraestructure/
COPY InventoryService/src/InventoryService.Domain/ InventoryService/src/InventoryService.Domain/
COPY PaymentService/src/PaymentService.Infrastructure/ PaymentService/src/PaymentService.Infrastructure/
COPY PaymentService/src/PaymentService.Domain/ PaymentService/src/PaymentService.Domain/
COPY UserService/src/UserService.Infrastructure/ UserService/src/UserService.Infrastructure/
COPY UserService/src/UserService.Domain/ UserService/src/UserService.Domain/
COPY InventoryService/src/InventoryService.Commons/ InventoryService/src/InventoryService.Commons/
COPY PaymentService/src/PaymentService.Commons/ PaymentService/src/PaymentService.Commons/

WORKDIR /app/MigrationsConfig/UserServiceMigration

RUN dotnet restore

WORKDIR /app/MigrationsConfig/InventoryServiceMigration

RUN dotnet restore

WORKDIR /app/MigrationsConfig/PaymentServiceMigration

RUN dotnet restore


RUN dotnet tool install --global dotnet-ef

ENV PATH="$PATH:/root/.dotnet/tools"
WORKDIR /app/MigrationsConfig

RUN chmod +x init-migrations.sh

ENTRYPOINT [ "./init-migrations.sh" ]