# Comprehensive Code Project Development

## 1. Design Challenge Review

  This project is part of the Microsoft Back-end Developer Certification in Coursera.

  Chosen Design Challenge: **Inventory Management System**.

  Key requirements overview:

- Create a console application.

- The users should be able to:

  - Add new products (name, price, stock).

  - Update stock (sold/restocked).

  - View all products and their stock.

  - Remove products from inventory.

## 2. Project Requirements and Objectives

### Functional Requirements

- Add new products with name, price, and stock quantity.
- Update stock when products are sold or restocked.
- View all products and their stock levels.
- Remove products from inventory.

### Non-Functional Requirements

- Performance:
  - Operations like adding, updating, or deleting products should complete instantly.
  - Startup time should be under 1 second.
- Reliability:
  - Validate user inputs to ensure the data is correct and avoid issues.
- Maintainability:
  - The code should be modular, easy to read, maintain and upgrade.
- Usability:
  - The app should have clear prompts and a menu system.
  - The app should have easy navigation with number-based menu choices.
  - The app should have helpful error messages and confirmations.

### Main Objectives

- Build a working console app that meets all functional and non-functional requirements.
- Demonstrate understanding of control structures, methods, and data structures.

## 3. Design Outline

### Overall Goal

Develop an inventory management system where the user can manage products through the console.

### Major functions

- Product Management: Creating, updating, and removing product data.
- Stock Operations: Handling inventory quantity changes like sells, restock, etc.
- System Navigation: User interface and input flow.

### Major functions break-down
  
- **Program** (Entry Point):
  - **Purpose**: It will be the central controller for the app.
  - **Responsibilities**:
    - Starts the application.
    - Calls the UI component to display the main menu.
    - Coordinates actions between the different modules.
    - Loops until the user chooses to exit.

- **UserInterface**:
  - **Purpose**: Handles all input/output interactions with the user.
  - **Responsibilities**:
    - Display menus and prompts.
    - Collect and validate user input.
    - Display results, error messages, and confirmation messages.
    - Improve usability with clear messages and menu navigation.

- **Product**:
  - **Purpose**: Represents individual product data and logic.
  - **Responsibilities**:
    - Store product properties like name, price, and stock.
    - Validate values (e.g., non-negative stock or price).

- **Inventory**
  - **Purpose**: Manages the collection of products.
  - **Responsibilities**:
    - Add new products.
    - Find, update, or remove products by name or ID.
    - Adjust stock levels based on user actions.
    - List all products with current stock and pricing.
    - Prevent duplicate products or invalid operations.

### Modules

#### Each core function will be developed as an independent module

- UserInterface
- Inventory
- Product

#### The main core functions will be tied together by the main class

- Program

### Flow Chart / Diagram

#### This will include a class diagram outlining the relationships between Program, UserInterface, Product, and Inventory modules

![alt text](<public/Inventory System Flowchart.jpg>)

- Created using Miro.

### Transition to pseudocode

WIP

### Pseudocode

WIP

### Tasks

A detailed checklist of development tasks per module will be included here.

### Code Components

WIP

## 4. Technology Stack

- Language: C#
- Platform: .NET Console App
- IDE: Visual Studio Code
