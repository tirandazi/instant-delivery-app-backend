# IDA (Instant Delivery App)

## Overview

IDA is an instant delivery app where prospective buyers can place orders for daily-use household goods which can be delivered to their doorstep quickly, thereby providing convenience. This project serves as a learning exercise to explore and practice best practices in using ASP.NET core 8.

## Tech Stack

- **Backend**: ASP.NET CORE

## Installation

### Prerequisites

- SDK .net 8
- docker-compose
- nuget(package manager)
- VSCode

### Setting Up Development Environments
   
1. **Add extensions for .NET development in VSCode**:

    - Nuget Gallery
    - .NET Extension Install Tool and extension Pack
    - C# and C# Dev kit
    - C# Extensions(JosKreativ)
    - IntelliCode
    -RestClient or Thunderbolt
    (to test endpoints) (Or could use postman/insomnia)

### Project Setup

1. **Clone the repository**:

    ```bash
    git clone https://github.com/tirandazi/instant-delivery-app-backend.git
    ```

    OR

    ```bash
    git clone git@github.com:tirandazi/instant-delivery-app-backend.git
    ```

2. **Navigate into the project directory**:

    ```bash
    cd instant-delivery-app-backend
    ```

3. **Creat and .env file**:

    ```bash
    PORT=8080
    APP_ENV=local
    DB_HOST=localhost
    DB_PORT=5432
    DB_EXPOSED_PORT=5432
    DB_DATABASE=instant_delivery_app
    DB_USERNAME=idauser
    DB_PASSWORD=idapass
    DB_SCHEMA=public
    ```

    In terminal, run the following command :

    ```bash
    set -a
    
    source .env
    ```


4. **Get the DB up and running**:

    ```bash
    docker-compose up 
    ```

   Seed the data into the database tables
      - Run the script `sh data-seeder.sh`

    To get into the  DB container and view data

    ```bash
     docker exec -it <container_name> psql -h localhost -U idauser -d instant_delivery_app
    ```

6. **Start the .NET backend with hot reload**:

    ```bash
    dotnet watch run --project Api/
    ```
7. **To run the tests**:

    Get to main folder containg Api and Test folders
    ```bash
    cd ..
    ```

    ```bash
    dotnet test
    ```

