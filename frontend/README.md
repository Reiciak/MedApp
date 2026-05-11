# MedApp

## About MedApp

MedApp is a Flutter-based mobile application designed to display and manage patient medical data received from the backend service. The application communicates with the MedApp Backend API to retrieve patient information and medical results, providing healthcare professionals with a user-friendly interface to monitor patient conditions in real-time.

## Requirements

### Dart/Flutter Version
- **Flutter**: 3.0.0 or higher
- **Dart**: 3.0.0 or higher

### Required Plugins

The following plugins are required to run the application. They are defined in `pubspec.yaml`:

- `http` - For making HTTP requests to the backend API

## Installation & Setup

### Step 1: Prerequisites
Ensure you have Flutter and Dart installed on your system. Check your versions:
```bash
flutter --version
dart --version
```

### Step 2: Clone the Repository
```bash
git clone <repository-url>
cd MedApp/frontend
```

### Step 3: Get Dependencies
Install all required packages:
```bash
flutter pub get
```

### Step 4: Run the Application

```bash
flutter run -d <device>
```

**Available Devices:**
```
android      - Android device or emulator
ios          - iOS device or simulator
web          - Web browser
windows      - Windows desktop
macos        - macOS desktop
linux        - Linux desktop
```

To see a list of connected devices:
```bash
flutter devices
```

## Current Features

✅ **JSON Data Integration** - Reads and processes patient data from JSON files sent by the backend API

✅ **Patient List View** - Displays a comprehensive list of all patients with relevant medical information

✅ **Critical Condition Recognition System** - Automatically detects critical patient conditions and highlights affected patient tiles in red for immediate visibility

✅ **Real-time API Communication** - Establishes connection with the backend service to fetch latest patient and results data

## Planned Features

🔄 **Advanced Patient Filtering** - System to filter patients by multiple criteria including:
- PESEL (Polish national identity number)
- Surname
- First name
- Other relevant patient identifiers

🔄 **Enhanced Patient Condition Recognition** - Expansion of the condition detection system to include:
- Yellow color highlighting for warning/caution conditions
- Additional condition status categories (critical, warning, normal)
- Visual indicators for different severity levels

## Project Structure

- `lib/main.dart` - Application entry point
- `lib/models/` - Data models for patients and results
- `lib/screens/` - UI screens for different views
- `lib/services/` - API service for backend communication
