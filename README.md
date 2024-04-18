# SQL File Scanner

## Overview
This SQL File Scanner is a .NET 6 console application that scans SQL files in a specified directory, counts the number of lines in each file, and generates a CSV file summarizing these details. The CSV file is uniquely named with a timestamp to avoid overwriting previous scans.

## Prerequisites
- .NET 6 SDK: Ensure that .NET 6 SDK is installed on your system. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/6.0).

## Installation
To set up this project, follow these steps:

1. Clone the repository or download the source code.
2. Navigate to the project directory in a command prompt or terminal.

## Usage
To run the application, follow these steps:

1. Open a command prompt or terminal.
2. Navigate to the project directory.
3. Build the project:
   ```bash
   dotnet build
   dotnet run
   Provide the Path to Scan
Output
The application will create a CSV file in the same directory as the SQL files. The filename will include a timestamp to ensure uniqueness. The CSV file includes the following columns:

Sl.No.: Serial number of the file.
FileName: Name of the SQL file.
NumberOfLines: Number of lines in the SQL file.
Path: Path to the SQL file.
An additional row at the end of the CSV will display the total number of lines counted across all files.
