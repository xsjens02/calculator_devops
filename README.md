Calculator_DevOps

![Image](https://github.com/user-attachments/assets/ea96d3ff-2c6d-4df6-8591-393919bf1022)

🚀 Live Demo

You can visit the staging server and test the application here: 

http://79.76.48.213:3000

This is a school project focused on DevOps and CI/CD pipelines.

The CI/CD pipeline is structured into three main stages:


1️⃣ ----- Code Integration & Quality Assurance -----

    Automated code integration to ensure stability and correctness.
    
    Unit tests, code coverage, and mutation testing.
    
    Static code analysis using SonarQube.


2️⃣ ----- Automated Deployment to Staging -----

    The full application is deployed to a staging server.
    
    Database migrations are handled using Flyway, ensuring version control and automatic setup of required tables.


3️⃣ ----- Testing & Performance Assurance -----

    End-to-end testing using TestCafe.
    
    Load testing with K6 to ensure performance under stress.


🛠️ ----- Tech Stack -----

    Backend: REST API (Node.js/Express)
    
    Frontend: React Client
    
    Database: MariaDB


📌 ----- Features -----

This project implements a calculator with two modes:

    Simple Calculator – Executes calculations without caching.
    
    Cached Calculator – Stores previous calculations to improve performance.


Both calculators support:

✔️ Basic arithmetic operations (+, -, *, /)

✔️ Prime number checking

✔️ Factorial calculations
