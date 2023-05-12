# Entity framework example

An example for the final lesson of PV003. This repo includes the code example with the final solution.

It showcases of the basic usage of ORM for a small project.

In the _ModelFirst_ project the showcase of creating a database table from dotnet 7.

Then in the _DatabaseFirst_ project the previously created database is used to generate the models and dbcontext.

## Starting the database

### Prerequisites

[Docker desktop](https://www.docker.com/products/docker-desktop/)

### Usage

The database has its _docker-compose.yml_ file. The `docker-compose up` command starts up a docker container exposing the database on its port 5432.

## Important commands for the model first approach

**These commands need to be used in the Package Manager Console.**

### The following command creates a new migration

`dotnet ef migrations add Pepela`

## Impotant commands for the database first approach

### The following command creates modules from the database

`dotnet ef dbcontext scaffold "Host=localhost;Database=Office;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL -o Models`
