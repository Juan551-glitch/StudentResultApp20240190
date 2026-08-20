# StudentResultApp
[![CI/CD](https://github.com/lusuJR/StudentResultApp/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/lusuJR/StudentResultApp/actions)

## AZ-400 GitHub Actions CI/CD Demo Project

StudentResultApp is a modern ASP.NET Core MVC application developed as part of an AZ-400 DevOps demonstration project.  
The application manages student academic results while showcasing industry-standard DevOps practices using GitHub Actions, automated testing, and CI/CD pipelines.

## Project Objectives

This project demonstrates:
- GitHub Version Control
- Branching and Pull Requests
- Continuous Integration (CI)
- Continuous Deployment (CD)
- Automated Unit Testing
- Selenium UI Automated Testing
- Build Validation Pipelines
- DevOps Best Practices
- Others

## Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC | Web Application Framework |
| C# | Backend Development |
| SQL Server | Database |
| Entity Framework Core | ORM |
| Git & GitHub | Version Control |
| GitHub Actions | CI/CD Automation |
| MSTest | Unit Testing |
| Selenium | UI Automation Testing |
| Azure VM | Self-Hosted Build Agent |

##  Features
- Student Management
- Result Management
- Responsive User Interface
- Automated Testing
- GitHub Actions Workflow
- CI/CD Pipeline Integration
- Professional MVC Architecture

##  Automated Testing
The project includes:

### Unit Testing
- Validation Testing
- Business Logic Testing
- Controller Testing

### Selenium UI Testing
- Browser Automation
- UI Validation
- End-to-End Testing

##  DevOps Workflow
The following DevOps practices were implemented:
1. Feature Branch Creation
2. Pull Request Workflow
3. Build Validation
4. Automated Test Execution
5. CI/CD Pipeline Automation
6. Deployment Using Self-Hosted Agent VM

##  Project Structure
<img width="419" height="656" alt="image" src="https://github.com/user-attachments/assets/13e18020-9d2c-426f-8fca-a669614efa32" />

##  GitHub Actions Pipeline
The pipeline automatically:
* Builds the application
* Restores dependencies
* Runs Unit Tests
* Runs Selenium Tests
* Validates Pull Requests
* Prepares deployment artifacts

##  Demo Purpose
This project was created for:
* AZ-400 DevOps demonstrations
* CI/CD practical implementation
* DevOps classroom training
* GitHub Actions learning
* Azure DevOps concepts demonstration

## Azure SQL configuration

The application reads its Azure SQL connection string from `DefaultConnection`.
In Azure App Service, configure either a connection string named
`DefaultConnection` or an application setting named `DefaultConnection` containing
the Azure SQL connection string. `StudentResultsDB` remains supported as a fallback.
Do not commit credentials to `appsettings.json`.

For local development, use .NET user secrets:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=tcp:<server>.database.windows.net,1433;Initial Catalog=StudentResultsDB;User ID=<user>;Password=<password>;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
```

The database must contain `dbo.StudentResults` with the schema supplied for this
project.

### Passwordless Azure SQL access

When `DefaultConnection` uses `Authentication=Active Directory Default`, no SQL
username or password is supplied. Enable the App Service's **system-assigned
managed identity**, configure a Microsoft Entra administrator for the Azure SQL
server, and connect to `StudentResultsDB` as that administrator to run:

```sql
CREATE USER [<your-app-service-name>] FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER [<your-app-service-name>];
ALTER ROLE db_datawriter ADD MEMBER [<your-app-service-name>];
```

The App Service must also be able to reach the Azure SQL server through its
network/firewall configuration.

##  Author

**Lusukama Selemani**

Microsoft Certified Trainer (MCT)

Azure & DevOps Engineer

##  Notes
This is a demonstration and educational project developed for DevOps learning and practical implementation purposes.


