# Venues-Api

Sample ASP.Net WebApi project for managing venues

## Features

- ASP.NET WebApi Backend.
- Entity Framework ORM using code-first migrations.
- Sql Server Database Backend.
- ViewModels Support using [Automapper](https://automapper.org/).
- Request Validation using [FluentValidation](https://github.com/JeremySkinner/FluentValidation).
- Fully RESTfull API.

## Available Endpoints

### Get All Venues

```
GET /venues
```

Returns the top 10 venues ordered by creation date

### Get Venue By Id

```
GET /venues/{id}
```

Returns an object representing the venue with the specified id

**Params:**

`id` the venue id

### Create New Venue

```
POST /venues
```

Creates a new venue object

**Request Body:**
```
{
  name: string | required,
  address: string | required,
  type: string | required,
  capacity: int | min:0
}
```

### Update Venue

```
POST /venues/{id}
```

Updates a given venue with the specified data

**Params:**

`id` the venue id.

**Request Body:**
```
{
  name: string | required,
  address: string | required,
  type: string | required,
  capacity: int | min:0
}
```

### Delete Venue

```
DELETE /venues/{id}
```

Delete a given venue by id

**Params:**

`id` the venue id.
