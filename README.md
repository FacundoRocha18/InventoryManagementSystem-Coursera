# Comprehensive Code Project Development

## 1. Design Challenge Review

This project is part of the Microsoft Back-end Developer Certification in Coursera.

Chosen Design Challenge: **Inventory Management System**.

### Key Requirements Overview

* Console-based application
* User features:

  * Add new products (name, price, stock)
  * Update stock (sell/restock)
  * View all products and stock levels
  * Remove products from inventory

## 2. Project Requirements and Objectives

### Functional Requirements

* Add new products with name, price, and stock quantity
* Update stock through selling or restocking
* View all products and their current stock
* Remove products from inventory

### Non-Functional Requirements

* **Performance**: Instant operation and startup under 1 second
* **Reliability**: Validate all user inputs
* **Maintainability**: Modular and clean codebase
* **Usability**: Clear prompts, number-based menu, and helpful feedback

### Main Objectives

* Deliver a console app that meets requirements
* Demonstrate control structures, methods, and data abstraction

## 3. Design Outline

### Overall Goal

Enable users to manage products through a simple, responsive console UI.

### Major Functional Areas

* **Product Management**: Create, remove, inspect product objects
* **Stock Management**: Track and adjust inventory through sales and restocks
* **UI Navigation**: Prompt user inputs and route to appropriate logic

### Module Breakdown

#### Program (Main Controller)

* Entry point, application loop
* Delegates to UI and service methods

#### UserInterface Module

* Handles all prompts and outputs
* Validates input and delegates parsing
* Displays errors and confirmations

#### Product Domain Model

* Domain model with properties and behaviors
* Includes `Sell()` and `Restock()` logic with `ValidationResult`

#### Inventory Management

* In-memory product store
* Responsible for lookups, additions, removals

#### ProductService Logic

* Coordinates inventory and product logic
* Exposes high-level operations like `SellProductByName`, `RestockProductByName`

#### Validation Logic

* Centralized validation logic for names, prices, stock, menu input
* Uses `ValidationResult<T>` for consistent error/value handling

### Flow Chart / Diagram

![Inventory Flowchart](<public/Inventory System Flowchart.jpg>)

### Transition to Pseudocode

| Flowchart Block | Pseudocode Step                          |
| --------------- | ---------------------------------------- |
| Start           | Start                                    |
| Display Menu    | Display Menu                             |
| Select Option   | Prompt + Validate Menu Selection         |
| Add Product     | Prompt name/price/stock, validate, add   |
| Remove Product  | Prompt name, validate, remove            |
| Update Stock    | Prompt name & quantity, validate, update |
| View Products   | Display list or empty message            |
| Exit App        | Display exit message, end program        |

### Pseudocode

#### Program (Main Application Loop)

```plaintext
START

WHILE application is running:
  DISPLAY Main Menu
  PROMPT user for menu option
  VALIDATE menu option

  SWITCH user option:
    CASE 1: Handle Add Product
    CASE 2: Handle Remove Product
    CASE 3: Handle Update Stock
    CASE 4: Handle View Products
    CASE 0: Exit
    DEFAULT: DISPLAY error message

END WHILE

END
```

#### UserInterface

```plaintext
DisplayWelcome:
  Clear console
  Print welcome banner with separators

DisplayMainMenu:
  Print menu options (1 to 5, and 0 for Exit)

DisplayProductList(products):
  Print product table header
  For each product in the list:
    Print name, price, stock in table format

DisplayError(error):
  Print separator
  Print "Error: " + error message or "Unknown error occurred"
  Print separator

DisplaySuccess(message):
  Print separator
  Print "Success: " + message
  Print separator

PromptForMenuOption:
  Loop:
    Prompt user to select an option
    Read input
    Validate input using IsValidMenuOption
    If invalid: show error and repeat
    Else: break loop
  Return parsed input as integer

PromptForProductDetails:
  Prompt for product name (with uniqueness check)
  Prompt for product price
  Prompt for product stock
  Return ProductInput with collected values

PromptForProductName:
  Return result from generic Prompt with message and IsValidProductName validation

PromptForProductPrice:
  Return result from generic Prompt with message and IsValidPrice validation

PromptForProductStock:
  Return result from generic Prompt with message and IsValidStock validation

PromptForRestockAmount:
  Return result from generic Prompt with message and IsValidStock validation

PromptForQuantity:
  Return result from generic Prompt with message and IsValidQuantity validation

PromptAndValidateProductName:
  Loop:
    Prompt for name
    If IsUniqueProductName is invalid: show error and repeat
    Else: return name

Prompt(message, validate, fallbackError):
  Loop:
    Display message
    Read input
    Validate input using validate function
    If invalid: show error and repeat
    Else: return validated value
```

#### Product

```plaintext
Initialize Product with name, price, stock:
  Set Name = name
  Set Price = price
  Set Stock = stock

Restock(amount):
  If amount <= 0:
    Return invalid result with message "Restock amount must be greater than 0"
  Increase Stock by amount
  Return valid result

Sell(quantity):
  If quantity <= 0:
    Return invalid result with message "Quantity must be greater than zero"
  If quantity > Stock:
    Return invalid result with message "Not enough stock available"
  Decrease Stock by quantity
  Return valid result
```

#### Inventory

```plaintext
FUNCTION AddProduct(product):
  ADD product to internal list

FUNCTION RemoveProduct(product):
  REMOVE product from list

FUNCTION GetProductByName(name):
  RETURN first match from list by name (case-insensitive)

FUNCTION GetProducts():
  RETURN read-only list of products
```

#### ProductService

```plaintext
FUNCTION Build(input):
  RETURN new Product with name, price, and stock from input

FUNCTION FindByName(name):
  RETURN Inventory.FindProductByName(name)

FUNCTION IsDuplicate(product):
  RETURN TRUE if Inventory.FindProductByName(product.Name) is not null
  ELSE FALSE

FUNCTION TryAdd(product):
  CALL Inventory.AddProduct(product)
  RETURN TRUE if Inventory.FindProductByName(product.Name) is not null
  ELSE FALSE

FUNCTION TryRemove(product):
  CALL Inventory.RemoveProduct(product)
  RETURN TRUE if Inventory.FindProductByName(product.Name) is null
  ELSE FALSE

FUNCTION RestockProductByName(name, amount):
  product = Inventory.FindProductByName(name)
  IF product is null THEN RETURN ValidationResult invalid ("Product not found")
  CALL product.Restock(amount)
  RETURN result from Restock

FUNCTION SellProductByName(name, quantity):
  product = Inventory.FindProductByName(name)
  IF product is null THEN RETURN ValidationResult invalid ("Product not found")
  CALL product.Sell(quantity)
  RETURN result from Sell
```

#### Validation

```plaintext
FUNCTION IsValidMenuOption(input):
  IF input is null OR empty THEN RETURN invalid ("Option cannot be empty")
  IF input contains non-digit characters THEN RETURN invalid ("Option must contain only digits")
  IF input cannot be parsed as integer THEN RETURN invalid ("Option must be a valid number")
  IF parsed value not in range 0–5 THEN RETURN invalid ("Option out of range")
  RETURN valid with parsed integer

FUNCTION IsValidProductName(input):
  IF input is null OR empty THEN RETURN invalid ("Name cannot be empty")
  COUNT digits in input
  IF digit count > 3 THEN RETURN invalid ("Name contains too many numbers")
  IF input length < 3 OR > 75 THEN RETURN invalid ("Name length out of bounds")
  IF input contains characters other than letters, digits, spaces THEN RETURN invalid ("Name contains invalid characters")
  RETURN valid with input string

FUNCTION IsUniqueProductName(name):
  IF any product in inventory has same name (case-insensitive) THEN RETURN invalid ("Product already exists")
  RETURN valid with name

FUNCTION IsValidPrice(input):
  IF input is null OR empty THEN RETURN invalid ("Price cannot be empty")
  IF input contains non-digit characters THEN RETURN invalid ("Price cannot contain letters or special characters")
  IF input cannot be parsed as double THEN RETURN invalid ("Price must be a valid number")
  IF price < 0 OR > 1,000,000 THEN RETURN invalid ("Price out of range")
  RETURN valid with parsed double

FUNCTION IsValidStock(input):
  IF input is null OR empty THEN RETURN invalid ("Stock cannot be empty")
  IF input contains non-digit characters THEN RETURN invalid ("Stock must contain only digits")
  IF input cannot be parsed as int THEN RETURN invalid ("Stock must be a valid number")
  IF stock < 0 OR > 10,000 THEN RETURN invalid ("Stock out of range")
  RETURN valid with parsed int

FUNCTION IsValidQuantity(input):
  IF input is null OR empty THEN RETURN invalid ("Quantity cannot be empty")
  IF input cannot be parsed as int THEN RETURN invalid ("Quantity must be a number")
  IF quantity <= 0 THEN RETURN invalid ("Quantity must be greater than zero")
  IF quantity > 10,000 THEN RETURN invalid ("Quantity exceeds the allowed maximum")
  RETURN valid with parsed int
```

#### Validation Result

```plaintext
ValidationResult:
  Properties:
    IsValid: boolean
    ErrorMessage: optional string

ValidationResult<T> (generic version):
  Properties:
    IsValid: boolean
    ErrorMessage: optional string
    Value: optional value of type T
```

## 4. Technology Stack

* **Language**: C#
* **Platform**: .NET Console Application
* **IDE**: Visual Studio Code

## 5. Future Improvements

* Add support for product search
* Introduce unit testing
* Export inventory to file
* Add categories or tags for filtering

## 6. Tasks (Module-Level)

* Implement domain models and service logic ✅
* Centralize validation with generic result ✅
* Refactor UI prompts for reusability ✅
* Build application loop with menu routing ✅
* Structure project with feature-based folders ✅
