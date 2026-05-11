
# Med App

## About MedApp
Med App is a server-side application designed to integrate and unify data from various medical laboratories. It provides a centralized API for accessing, managing, and processing laboratory results and patient information. The system aims to streamline data exchange between different labs, making it easier for healthcare providers to retrieve and analyze medical data from multiple sources in a consistent format.

## Current Features
✅ Read data from JSON files (laboratory results, patient information, etc.)

## Planned Features
🔄 Support file formats:
  - CSV
  - TXT
  - XML
🔄 Enhanced data validation and error handling

## JSON Schema

```json
{
  "patient_id": "string (unique identifier)",
  "patient_name": "string",
  "patient_surname": "string",
  "test_name": "string",
  "result": "double",
  "scale": "string"
}
```

## Requirements
- **C# version:** 10.0 or higher
- **.NET version:** .NET 6.0 or higher

## Project Structure & Technologies
- **Minimal API:** The project uses ASP.NET Core Minimal API for lightweight and efficient HTTP endpoints.
- **Directory Structure:**
  - `Controllers/` – API endpoint definitions
  - `Models/` – Data models (e.g., Patient, Result)
  - `Services/` – Business logic and data access (currently JSON)

## Recommended Plugins/Extensions
- [C# for Visual Studio Code (powered by OmniSharp)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) (for testing API endpoints)
- [NuGet Package Manager](https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager)

---


## How to Run the App

1. **Install .NET 6.0 or higher**
  - Download and install the .NET SDK from [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

2. **Navigate to the Backend directory**
  - Open a terminal and run:
    ```bash
    cd Backend
    ```

3. **Restore dependencies**
  - Run:
    ```bash
    dotnet restore
    ```

4. **Build the project**
  - Run:
    ```bash
    dotnet build
    ```

5. **Run the application**
  - Run:
    ```bash
    dotnet run
    ```

6. **Access the API**
  - By default, the API will be available at `http://localhost:5000` or as specified in the console output.

