## Space Management Software

This project is a comprehensive Space Management Software developed using **C# .NET Framework**, featuring both a desktop and web application. The web application is built using **ASP.NET RazorPages**, and the database is hosted on **Microsoft SQL Server**.

### Account Types
The software supports three account types:
- **Admin**: Responsible for managing accounts and users.
- **Employee**: Empowered to add and track Satellites, Space Stations, and potentially hazardous space debris. This includes automatic orbit and trajectory calculations, as well as collision prediction.
- **Guest**: Can observe or report issues within the application.

### Desktop Application Features
The desktop application offers the following features:
- Full CRUD operations for objects in the proximity of earth.
- Automatic orbit calculation and collision prediction utilizing vectorial positions relative to the center of the earth.
- Automatic parameter calculation and options to view an object and its blueprint (if it is a launched satellite or space station).
- Advanced searching and filtering for space objects and users on the admin side.
- Communication path determination inspired by the StarLink trailer, with the application of advanced algorithms to determine the shortest path for signal travel from communication satellite A to B. This involves efficiently utilizing other communication satellites in between A and B, while accounting for the movement of all satellites during message transmission.
- Live simulation achieved via multithreading and constant updating of the database information.

### Web Application Features
The web application offers the following features:
- Fully responsive and visually appealing design.
- Account control and security measures.
- Visual representation of space objects relative to the earth's map using OpenStreetMaps.
- User lists for efficient management.

### Documentation
The app's development has been thoroughly documented, including:
- Architectural choices with a 3-layered design respecting SOLID principles.
- Database modeling with a table-per-type approach.
- Activity diagram for one algorithmic flow.
- User Requirement Specifications (URS), Test Plan, and Test Report based on the URS.
- UML class diagram for the backend.

A comprehensive list of features and screenshots of the application in use can be found in the "Documentation/Docs_as_pdf/URS.pdf" file.

### Disclaimer
It is important to note that this application does not utilize NASA API or similar services for the objects. Instead, employees make use of a direct create flow within the desktop app for adding new objects.
