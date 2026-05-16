# REST API Basics

Building a production-grade REST API from scratch, in progressive layers. Each module in this repo adds one major concern on top of the previous: start with basic CRUD and layered architecture, then add validation, authentication, user-scoped data, complex query options, and finally API versioning, health checks, and a generated SDK. The same movie-catalog domain is used throughout, which makes it easy to see exactly what each concern adds.

---

## [rest-api/crud-basics](rest-api/crud-basics/)

Three-layer REST API: HTTP controller, service/repository application layer, and request/response contracts. Basic CRUD for a movies resource backed by SQLite.

_Learned: splitting an API into API / Application / Contracts layers from the start is a structural bet — it costs nothing when the project is small and pays off the moment you need to test the business logic without spinning up HTTP._

---

## [rest-api/validation-middleware](rest-api/validation-middleware/)

FluentValidation rules on requests, surfaced to the client through a custom `ValidationMappingMiddleware` that shapes error responses uniformly.

_Learned: putting validation error formatting in middleware rather than in controllers means every endpoint returns the same error shape automatically — clients can write one error-handling path for the whole API._

---

## [rest-api/authentication](rest-api/authentication/)

JWT Bearer authentication, claims-based authorization, and a separate Identity service that mints tokens for testing.

_Learned: JWT authentication is stateless — the token carries all the claims the server needs to authorize a request, so there is nothing to look up, which is why it scales horizontally without a shared session store._

---

## [rest-api/user-scoped-data](rest-api/user-scoped-data/)

Ratings resource where results depend on who is asking — the authenticated user's identity is extracted from the JWT and threaded through the service layer to scope queries.

_Learned: threading user identity as a plain value through service method signatures keeps the business logic unaware of HTTP or auth frameworks — the same service code works in a background job, a test, or an API controller._

---

## [rest-api/pagination-filtering](rest-api/pagination-filtering/)

`GetAllMoviesOptions` object with title filter, year filter, sort field/direction, and page/size — validated as a unit and passed through the full stack.

_Learned: modeling query options as a validated object rather than a parameter list means you can add a new filter or sort field in one place — the validator, the repository, and the API contract all reference the same type._

---

## [rest-api/versioning-sdk](rest-api/versioning-sdk/)

API versioning via media type headers, database health check, Swagger configured for multiple versions, a Refit-based typed SDK library, and a console consumer demonstrating the SDK.

_Learned: generating a typed SDK from your own API creates a compile-time contract between server and client — if the server changes a response shape, the consumer fails to build before it ever fails at runtime._

---

## How to Run

Each module folder is a standalone solution. To run any module:

```bash
cd rest-api/<module-name>
dotnet run --project Movies.Api
```

For authenticated endpoints, start the Identity service first:

```bash
dotnet run --project rest-api/helpers/Identity.Api
```

The Postman collection in `rest-api/helpers/Course.postman_collection.json` has pre-configured requests for all modules.

Open `rest-api/rest-api.sln` in Visual Studio or Rider to browse all projects.

---

Thanks to Nick Chapsas for the course — [From Zero to Hero: REST APIs in ASP.NET Core](https://dometrain.com/course/from-zero-to-hero-rest-apis-in-asp-net-core).

[Certificate of completion](certificate/Rest%20API%20in%20DotNet%20-%20Einav%20Haimovich.pdf)
