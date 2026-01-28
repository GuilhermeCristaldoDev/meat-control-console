# Meat Control Console

A real-world C# console application designed to manage meat registrations with file-based persistence.

This application was created to solve a **practical day-to-day need**: registering, maintaining, and updating meat data in a simple and reliable way, without relying on external systems or databases.

While the project also serves as a learning experience, it is **actively designed to be usable**, focusing on clarity, consistency, and correct handling of data.

---

## How to Run

1. Clone this repository  
2. Open the solution in **Visual Studio**  
3. Run the project  
4. Use the console menu to add, edit, list, or remove meat records  

---

## Why this application exists

In my daily routine, I needed a straightforward way to register and manage meat information, ensuring that data would persist between executions and could be easily updated or removed.

Instead of using spreadsheets or manual notes, I chose to build a **custom solution in C#**, applying backend fundamentals to a real scenario.

---

## Features

- Add meat records  
- List all registered meats  
- Edit meat information by ID  
- Remove meat records  
- Automatic ID generation  
- Data persistence using a local TXT file  

---

## Data Structure

Each meat record is stored using the following format:

ID;Name;Price

Example:

1;Picanha;89.90 2;Alcatra;59.50

This structure was chosen to keep the data human-readable while maintaining simplicity.

---

## Technologies

- C#  
- .NET Console Application  
- File I/O (`System.IO`)  
- Object-Oriented Programming  

---

## Design Decisions

- No database was used to keep the application lightweight and portable  
- TXT file persistence was chosen to reinforce file handling concepts and ensure transparency of stored data  
- Console-based interface allows fast interaction and easy testing  

---

## Future Improvements

- Stronger input validation  
- Refactoring and improved code organization  
- Replace TXT persistence with JSON  
- Migrate persistence to a database  
- Evolve the application into a Web-based solution or API  
- Package the application as a **standalone executable (.exe)** for easier distribution and usage without Visual Studio  

---

## Final Notes

This project reflects my approach to learning software development:  
**identify a real problem, build a functional solution, and continuously improve it**.

The application is intentionally simple, but built with real usage, distribution, and future evolution in mind.
