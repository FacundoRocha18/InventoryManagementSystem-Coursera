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

![alt text](<public/Inventory System Flowchart.jpg>)

- Created using Miro.

### Transition to pseudocode

| Flowchart Block                              | Pseudocode Step                          |
|---------------------------------------------|------------------------------------------|
| Start                                        | Start                                    |
| Display Main Menu                           | Display Main Menu                        |
| Prompt the User to select an option         | Prompt user for menu option              |
| Validate Menu Selection                     | Validate selected menu option            |
| Is Menu Selection Valid?                    | If menu option is valid                  |
| Display error message                       | Show "Invalid option" error              |
| Select Menu Option                          | Read selected menu option                |
| User selects "Add Product"                  | If user selects "Add Product"            |
| Prompt for Product Name, Price, Stock       | Prompt user for product details          |
| Validate Product Data                       | Validate product name, price, and stock  |
| Is Product Data Valid?                      | If product data is valid                 |
| Add Product to Inventory                    | Add product to inventory                 |
| Validate Operation Success                  | Validate product was added successfully  |
| Was Operation Successful?                   | If add was successful                    |
| Display success message                     | Show success message                     |
| User selects "Remove Product"               | If user selects "Remove Product"         |
| Prompt for Product Name                     | Prompt user for product name             |
| Validate Product Name                       | Validate that product name is valid      |
| Is Product Name Valid?                      | If product name is valid                 |
| Remove Product from Inventory               | Remove product from inventory            |
| Validate Operation Success                  | Validate product was removed successfully|
| Was Operation Successful?                   | If removal was successful                |
| Display success message                     | Show success message                     |
| User selects "Update Stock"                 | If user selects "Update Stock"           |
| Prompt for Product Name & new Stock         | Prompt user for product name and stock   |
| Validate Product Name & new Stock           | Validate product name and new stock      |
| Are Product Name & new Stock valid?         | If both are valid                        |
| Update Product Stock in Inventory           | Update product stock in inventory        |
| Validate Operation Success                  | Validate stock update success            |
| Was Operation Successful?                   | If update was successful                 |
| Display success message                     | Show success message                     |
| User selects "View Products"                | If user selects "View Products"          |
| Validate Inventory Not Empty                | Check if inventory is empty              |
| Is Inventory Empty?                         | If inventory is empty                    |
| Display Empty Inventory Message             | Show "No products" message               |
| Display All Products in Inventory           | Show full list of products               |
| User selects "Exit App"                     | If user selects "Exit App"               |
| Display Exit Message                        | Show exit message                        |
| Exit the Application                        | Exit program                             |
| End                                          | End                                      |

### Pseudocode

```plaintext

START

WHILE condition is true:

  DISPLAY "Inventory Management System"
  DISPLAY "1. Add Product"
  DISPLAY "2. Remove Product"
  DISPLAY "3. Update Stock"
  DISPLAY "4. View Products"
  DISPLAY "0. Exit"

  PROMPT "Select an option (1-5)"
  READ userInput

  IF the option is not valid:
    DISPLAY "Error: The selected option is invalid. Choose another one."
  END IF

  Switch(Menu Selection)
        Case 1:
            PROMPT "Please enter the Product Name:"
            READ productName
            PROMPT "Please enter the Product Price:
            READ productPrice
            PROMPT "Please enter the Product Stock:"
            READ productStock

            IF productName is not valid:
              DISPLAY "Error: The product name is not valid."
            END IF

            IF productPrice is not valid:
              DISPLAY "Error: The product price is not valid."
            END IF

            IF productStock is not valid:
              DISPLAY "Error: The product stock is not valid."
            END IF

            Add Product to Inventory

            IF product is not in inventory list:
              DISPLAY "Error: An error occurred with the operation."              
            END IF
            
            DISPLAY "Success: Operation successful."
            Break

        Case 2:
            Prompt the User for Product Name
            Validate Product Name
            If Product Name is Valid:
                Remove Product from Inventory
                Validate Operation Success
                If Operation was Successful:
                    DISPLAY success message
                Else:
                    DISPLAY error message
            Else:
                DISPLAY error message
            Break

        Case 3:
            Prompt the User for Product Name & new Stock
            Validate Product Name & new Stock
            If Product Name & new Stock are Valid:
                Update Product Stock in Inventory
                Validate Operation Success
                If Operation was Successful:
                    DISPLAY success message
                Else:
                    DISPLAY error message
            Else:
                DISPLAY error message
            Break

        Case 4:
            Validate Inventory Not Empty
            If Inventory is Empty:
                DISPLAY Empty Inventory Message
            Else:
                DISPLAY All Products in Inventory
            Break

        Case 0:
            DISPLAY Exit message
            Exit the application
            Break

        Default:
            DISPLAY "Error: Invalid option. Plase enter a valid option..."
            Break

END WHILE

END

```

### Tasks

A detailed checklist of development tasks per module will be included here.

### Code Components

WIP

## 4. Technology Stack

- Language: C#
- Platform: .NET Console App
- IDE: Visual Studio Code
