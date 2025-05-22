
## Smedley Group Assessment – Exam Hall Seating Algorithm

This C# console application solves a constrained exam hall seating problem using **backtracking**, with additional rules around **test assignment** and **special students**.

### Problem Overview

* 25 students (`A01` to `A25`) are to be seated in a 5×5 exam hall grid.
* Each student is assigned a test (T1–T5).
* Exactly **2 random students** are marked as `Special` and must take **T5**.
* All other students are assigned tests in a round-robin fashion from T1 to T4.
* **Constraint:** No two neighbouring students (including diagonals) can take the same test.

---

### Algorithm

* Uses **recursive backtracking** to place students in grid positions.
* Ensures adjacency rules are respected using an `IsValid` method.
* **Special students are sorted first** to reduce conflicts.
* Seating attempts are shuffled to avoid deterministic failure.
* Includes **retry logic** in case a valid arrangement isn't found immediately.

---

### Technologies

* **Language:** C# 11 / .NET 8+
* **Project Structure:**

  * Console App: `ExamHall`
  * Unit Tests: `ExamHall.Tests` using xUnit

---

### How to Run

```bash
git clone https://github.com/sk-uom-in/Smedley-Group-Assessment
cd Smedley-Group-Assessment
dotnet build
dotnet run --project ExamHall
```

---

### Run Unit Tests

```bash
dotnet test
```

Tests validate:

* Exactly 25 students are created
* Exactly 2 students are Special with test T5
* All students are assigned a position
* No neighbours share the same test

---

### Example Output

```
Seating Layout (Name | Test):

A01|T1     A02|T2     A03|T3     A04|T4     A05|T1     
A07|T3     A08|T4     A09|T1     A06|T2     A10*|T5     
A13|T1     A14|T2     A11|T3     A12|T4     A19|T3     
A16|T4     A15*|T5     A17|T1     A18|T2     A21|T1     
A25|T1     A22|T2     A20|T4     A23|T3     A24|T4     

* = Special student
```

---

### Project Structure

```
Smedley-Group-Assessment/
├── ExamHall/
│   ├── Models/
│   │   └── Student.cs
│   ├── Services/
│   │   ├── StudentFactory.cs
│   │   └── SeatingAssigner.cs
│   └── Program.cs
├── ExamHall.Tests/
│   ├── Models/StudentTests.cs
│   └── Services/...
└── Smedley-Group-Assessment.sln
```

---

### Author

**Sambbhav Khare**
🔗 [LinkedIn](https://www.linkedin.com/in/khare-sambbhav)
💻 [GitHub](https://github.com/sk-uom-in)



