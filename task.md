Build a CRUD Application with a Backend API and a Frontend Framework of your choice.

You are tasked with developing a simple CRUD (Create, Read, Update, Delete) application for managing a list of items. The application should consist of a backend API built with .NET Core, and you have the flexibility to choose the frontend framework that you are most comfortable with. You can choose to build the frontend using either Blazor Server, Blazor WebAssembly, React, or Angular. The application should allow users to perform basic CRUD operations on the items, including creating new items, viewing a list of items, updating existing items, and deleting items.

Requirements:
1. Backend:
- Use .NET Core and Entity Framework to create the API.
- Implement the following API endpoints:
  - ✅ GET /api/items: Retrieve a list of all items.
  - ✅ POST /api/items: Create a new item.
  - ✅ GET /api/items/{id}: Retrieve details of a specific item.
  - ✅ PUT /api/items/{id}: Update details of a specific item.
  - ✅ DELETE /api/items/{id}: Delete a specific item.

2. Frontend:
- Choose one of the following frontend frameworks: Blazor Server, Blazor WebAssembly, React, or Angular.
- Implement the following features:
  - ✅ Display a list of items with their details.
  - ✅ Create a new item by submitting a form.
  - ✅ Edit an existing item by updating its details.
  - ✅ Delete an item from the list.

Instructions:
1. Backend:
- ✅ Set up a new .NET Core project using a tool of your choice (e.g., Visual Studio, VS Code, Rider or dotnet CLI).
- ✅ Create the necessary API endpoints and models for managing items.
- Implement the API endpoints for CRUD operations, including proper input validation ❌ and error handling ❌.
- Configure the database connection using Entity Framework and ensure the API interacts with the database correctly.
- ✅ Use Entity Framework with the database of your choice.
- Add a Dockerfile for the backend and the required Database in docker-compose file ✅.
2. Frontend:
- Choose one of the following frontend frameworks: Blazor Server, Blazor WebAssembly, React, or Angular.
- Set up a new project for the chosen frontend framework using the corresponding tools and documentation.
- Create the necessary components and services for managing items.
- Implement the logic for retrieving the list of items from the backend API and displaying them.
- Implement the logic for editing and deleting items.
- Add the Dockerfile for the frontend in the docker-compose file.

Submission
Once you have completed the task, please provide the following:
- The GitHub repository link for the source code. ❌
- Any necessary instructions for running the application locally (e.g., required packages, environment setup). ❌
- A brief description of the key decisions you made during development, references, and any challenges you encountered. ❌