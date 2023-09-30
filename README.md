## how to run locally

1. spin up docker containers - via `docker compose up`
2. reach frontend in browser - [frontend at localhost:8002](http://localhost:8002)

## key notes about development

- decisions you made during development
  1. [enable CORS in backend for Development evironment](https://stackoverflow.com/a/64858510)
  2. return only `id` in POST responses after creating a resource, prefer to provide minimum data in response so that we do not force clients to receive useless data that can grow over time
  3. lets use named `HttpClient` just to try this feature, in this project we will not need more then one http communication dependency, only single backend
  4. decided to not go with CQRS in backend as amount of actions is very little

- references
  1. [Ant Design Blazor](https://antblazor.com) - library of UI components I used before, easy to throw in for feedback or forms components, it has minimum configuration boilerplate
  2. [FluentValidation.AutoValidation](https://github.com/SharpGrip/FluentValidation.AutoValidation) - useful package to validate inputs for asp.net core actions

- challenges you encountered
  - Sometimes you forget how many things have to be considered once you start project from scratch. Usually I am working with code bases that are mature and all basic things are already wired up, but starting new project you have to go through all data flow, validation, feedback, local dev and production, configs, adding 3rd party packages, logging, dependency injection and so on.

## todo

- backend
  - share models for http communication between `backend` and `frontend` in standalone `.dll`  
- frontend
  - popup on item add/edit success
- devops
  - inject database connection string via docker instead of hardcoded
  - add dedicated network for `backend + database` so `database` is not exposed to any other container