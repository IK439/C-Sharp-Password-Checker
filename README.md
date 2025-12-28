# Password Checker (C#)

A simple C# console application that validates user-entered passwords against modern security requirements and evaluates their overall strength.

## Features

- Enforces a minimum password length of 12 characters
- Requires uppercase, lowercase, numeric, and special characters
- Rejects passwords containing whitespace
- Detects weak patterns such as:
  - Repeated characters
  - Sequential characters (e.g. `abc`, `123`)
  - Common weak terms (e.g. `password`, `admin`)
- Provides a strength rating: **Excellent**, **Good**, **Fair**, or **Weak**

## How It Works

The program prompts the user to enter a password, checks it against required rules, and then performs additional risk-based analysis before reporting the password strength.

## Technologies Used

- C#
- .NET Console Application
- Regular Expressions (`System.Text.RegularExpressions`)

## Usage

1. Clone or download the repository
2. Open the project in Visual Studio or another C# IDE
3. Run the program
4. Enter a password when prompted to receive a strength evaluation

## Notes

This project is intended for learning purposes and demonstrates basic password validation and pattern detection logic.
