## Dapper Blog

This repository contains a complete project of a blog developed in .NET 7 (.NET Core 7) using Dapper for communication with the database.

## Project Description

This project is an example of how to build a blog with all essential functionalities, using Dapper for accessing and manipulating data in the database.

## Features

### Core Entities

- Categories: Organization of articles into different topics.
- Articles: Main blog posts.
- Comments: Feedback and discussions on the articles.
- Tags: Keywords associated with articles to improve search and organization.
- ArticleTag: Many-to-many relationship between articles and tags.

### Table Relationships

Using Dapper, relationships between tables are implemented:

- One-to-Many: Relationship between categories and articles, where one category can have multiple articles.
- Many-to-Many: Relationship between articles and tags, managed through the ArticleTag entity.

### Authentication and Authorization

- Cookie-based Authentication: Implementation of cookie-based authentication to manage user sessions.
- Authorization: Protection of controllers and views to ensure that only authenticated users can access certain functionalities.

### User Management

- User Registration: Functionality for new users to register on the blog.
- Existing User Validation: Verification of user existence in the database during registration.
- User Login and Access: Allows users to authenticate into the system.
- Password Encryption: Use of encryption techniques to secure user passwords.
- Logout: Allows users to securely log out of their accounts.

### User Interface and Layout

- Dynamic Slider Layout: Implementation of a dynamic slider that loads content from the database, using Bootstrap 5 for a responsive and modern design.
- Frontend Plugin Installation: Integration of various plugins to enhance the user experience:
  - Datatables.js: For dynamic tables and advanced search.
  - Toastr: Stylish and customizable pop-up notifications.
  - SweetAlerts: Attractive and user-friendly modal alerts.
  - TinyMCE: Rich text editor for article creation and editing.

### Project Organization

- Division into Areas: Structuring the project into areas within .NET 7 for better code organization and separation of concerns.
- File Upload: Implementation of functionality to allow users to upload files and images associated with articles.

### Backend and Database Communication

- Use of Dapper: Dapper is used as a micro ORM to access and manipulate data in the database efficiently and with low overhead.


### Additional Features

- Access to All Source Files: The project includes all necessary source files to understand and extend the functionality of the blog.
