# SpaceMissionPathfinder


A pathfinding challenge implemented in C#, featuring:
- Grid parsing
- BFS shortest-path search
- Multiple astronauts (S1, S2, S3…)
- Obstacles (X), open cells (O), and a final destination (F)
- Automatic test framework with deterministic and random tests
- Visualized maps and paths

This project was developed as part of a coding assignment.

------------------------------------------------------------

FEATURES

✔ Pathfinding (BFS)
Finds the shortest path from each astronaut to the final destination.

✔ Deterministic Tests
Fixed maps with predefined expected results.

✔ Randomized Tests (Fuzz Testing)
Random map generator to stress-test BFS.

✔ Path Visualization
Shows:
- Original map
- Computed path
- Rendered grid with highlighted path

✔ Clean Architecture
Models/
Services/
Views/
Tests/

------------------------------------------------------------

RUNNING TESTS

Run in test mode:
dotnet run true

Run in normal mode:
dotnet run

------------------------------------------------------------

PROJECT STRUCTURE

Models/
Services/
Views/
Tests/
Program.cs
SpaceMission.csproj
README.md

------------------------------------------------------------

TECHNOLOGIES

- C# 12
- .NET 8
- Console rendering
- BFS graph search
- Custom test framework

------------------------------------------------------------

CONTACT

Konstantin Andonov
kosetoit@gmail.com
