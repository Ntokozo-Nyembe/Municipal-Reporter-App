# Municipal-Reporter-App

## 1. Overview  

The **Municipal Reporter App** is a Windows Forms application built using **C# (.NET Framework)**.  
This part (Part 3) focuses on the Service Request Status using Advanced Data Structures (NewFully Implemented in This Version)

This version includes:  
- AVL Tree search for fast request lookup
- A new Service Request Status form 
- Tracking progress of municipal service requests
- Clean UI improvements and error handling

---

## 2. System Requirements  

- **Operating System:** Windows 10 or later  
- **IDE:** Visual Studio 2019 / 2022 with *“.NET Desktop Development”* workload installed  
- **Framework:** .NET Framework 4.7.2 or higher  

---

## 3. How to Compile  

1. Open the solution file:  
   ```bash
   MunicipalReporterApp.sln

 In Visual Studio.

2. From the menu, select:

-Build → Build Solution

-Or press Ctrl + Shift + B.

3. If successful, the executable (MunicipalReporterApp.exe) will be created in:

- \bin\Debug\

- or \bin\Release\

## 4. How to Run

- Option A (Recommended):
Press F5 (Run with Debugging) or Ctrl + F5 (Run without Debugging) in Visual Studio.

- Option B:
--Navigate to: \bin\Debug\ 
--and double-click: MunicipalReporterApp.exe

## 5. How to Use

5.1 Main Menu

When you launch the app, you will see three buttons:
-Report Issues  (active)
-Local Events and Announcements  (active)
-Service Request Status (active - New)

5.2 Reporting an Issue
-Click Report Issues.
-Enter the Location of the problem.
-Select a Category from the dropdown (e.g., Roads, Water, Sanitation).
-Type a detailed Description of the issue.
-(Optional) Click Attach Files to upload supporting images or documents.
-Click Submit to log the issue.
-A confirmation message will appear.
-Use Back to Main Menu to return.

5.3 Local Events and Announcements
-Search Events: Filter by Category or Date.
-Clear Filters: Resets the search results.
-Recommended for You: Displays a summary of upcoming or related events.
-Back to Main Menu: Returns to the home screen.

5.4 Service Request Status
This module allows residents to track the progress of municipal service requests using advanced data structures for fast searching.

How it Works:
- Each service request is stored in an AVL Tree (RequestsByNumber), ensuring:
  - O(log n) search time
  - Fast results even with large datasets
- Data is auto-generated when the application starts
- Request numbers begin from 1000

How to Use It:
- Click Service Request Status
- Enter a valid Request Number (e.g., 1000, 1001, 1002…)
- Click Find
- If found, details will appear in a table:
  - Request Number
  - Customer Name
  - Service Type
  - Date Submitted
  - Status (Submitted → Assigned → In Progress → Awaiting Parts → Completed)
- If not found, you will see: "Request not found."
- Use Back to Main Menu to exit

## 6. Features Implemented in Part 3

Advanced Data Structures 
- Basic Tree Implementation
- Binary Tree
- Binary Search Tree
- AVL Tree for search-by-number indexing (core structure used)
- Red-Black Tree (structure included in project)

Graphs, Heaps & Traversal 
- Included in solution to meet POE requirements:
- Simple Graph
- Graph Traversal (DFS)
- Minimum Spanning Tree (Kruskal’s)
- Min-Heap (priority queue structure)

These structures simulate backend processes municipalities may use to route or prioritise requests.

UI Implementation
- Clean form layout
- Search bar with validation
- Dynamic DataGridView
- Error Handling with try–catch
