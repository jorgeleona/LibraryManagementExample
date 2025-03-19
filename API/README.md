# Library Management API Exercise

## Objective

Build a RESTful Web API for managing books, authors, and categories.

## Pre-requirements

Before starting the exercise, ensure you have a local development environment set up with:

- **IDE/Code Editor**: Any IDE or code editor (e.g., Visual Studio Code, IntelliJ IDEA, PyCharm).
- **Web Framework**: Use a framework of your choice to build the API (e.g., Express, Flask, Django, ASP.NET Core, etc.).
- **Relational Database**: Use a database such as PostgreSQL, MySQL, SQLite, or SQL Server.
- **ORM/Query Builder (Optional)**: Use tools like Sequelize, TypeORM, or Entity Framework for data management.
- **API Testing Tools**: Tools like Postman, curl, or automated testing frameworks.
- **Dependencies**: Manage dependencies via a package manager (e.g., npm, pip, Maven, NuGet).
- **Runtime Setup**: Ensure the application can be run locally using Docker or native setup.

---

## Exercise Description

Create a RESTful Web API for a Library Management System that provides CRUD operations and relationships between the following entities:

1. **Books**: Add, fetch, update, and delete books. Books should also belong to one or more categories.
2. **Authors**: Manage author details, with each book being linked to a valid author.
3. **Categories**: Organize books into multiple categories.

---

## Core Features

### 1. Books
- Add a new book.
- Fetch the details of a specific book.
- Fetch a list of all books, with optional filtering by:
  - Author
  - Title
  - Category
- Update the details of a book.
- Delete a book.

### 2. Authors
- Add a new author.
- Fetch the details of a specific author.
- Fetch a list of all authors.
- Update the details of an author.
- Delete an author.

### 3. Categories
- Add a new category.
- Fetch a list of all categories.
- Fetch the details of a specific category, including all books under it.
- Update the details of a category.
- Delete a category.

---

## Relationships

1. Each **book** must be associated with a valid **author**.
2. A **book** can belong to multiple **categories**, and a **category** can include multiple **books**.

---

## Database Schema

1. **Book**:
   - `id` (unique identifier)
   - `title`
   - `authorId` (foreign key referencing `Author.id`)
   - `publishedDate`
   - `genre`

2. **Author**:
   - `id` (unique identifier)
   - `name`
   - `dateOfBirth`

3. **Category**:
   - `id` (unique identifier)
   - `name`

4. **BookCategory** (Join Table):
   - `bookId` (foreign key referencing `Book.id`)
   - `categoryId` (foreign key referencing `Category.id`)

---

## Endpoints

### Books
- `POST /books`: Add a new book.
- `GET /books`: Fetch all books (with optional filters).
- `GET /books/{id}`: Fetch details of a specific book.
- `PUT /books/{id}`: Update details of a book.
- `DELETE /books/{id}`: Delete a book.

### Authors
- `POST /authors`: Add a new author.
- `GET /authors`: Fetch all authors.
- `GET /authors/{id}`: Fetch details of a specific author.
- `PUT /authors/{id}`: Update details of an author.
- `DELETE /authors/{id}`: Delete an author.

### Categories
- `POST /categories`: Add a new category.
- `GET /categories`: Fetch all categories.
- `GET /categories/{id}`: Fetch a category and its books.
- `PUT /categories/{id}`: Update details of a category.
- `DELETE /categories/{id}`: Delete a category.

### Bonus Endpoints
- `POST /books/{id}/categories`: Assign multiple categories to a book.
- `DELETE /books/{id}/categories/{categoryId}`: Remove a category from a book.

---

## Deliverables

1. **Codebase**: A Git repository with a clear `README.md` for setup instructions.
2. **Database Schema**: SQL scripts or migrations for creating the schema.
3. **API Documentation**: Include request/response examples and status codes.
4. **Tests**: Unit or integration tests for all core functionalities.

---

## Evaluation Criteria

1. **Code Quality**: Clean, modular, and maintainable code.
2. **API Design**: RESTful, intuitive, and consistent.
3. **Database Design**: Proper normalization and constraints.
4. **Error Handling**: Clear and meaningful error messages.
5. **Documentation**: Comprehensive and easy to follow.
6. **Testing**: Coverage for main scenarios.

---

## Bonus Features

1. **Many-to-Many Relationship**:
   - Implement the `BookCategory` join table to manage multiple categories per book.
   - Add endpoints to assign/remove categories for a book.

2. **Search and Filtering**:
   - Add advanced search functionality for books by multiple criteria (e.g., author, category, published date).

3. **Pagination**:
   - Implement pagination for list endpoints.

4. **Soft Deletes**:
   - Allow soft deletes for books and categories to retain historical data.

5. **Deployment**:
   - Deploy the API to a platform like AWS, Azure, or Heroku for demonstration.

---

## Example Workflows

### Creating a Category
```http
POST /categories
{
  "name": "Science Fiction"
}
