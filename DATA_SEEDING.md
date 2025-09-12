# Data Seeding Guide

This guide explains how to populate your College Management System with realistic dummy data including 200+ students.

## What Data Gets Created

### 🏛️ **Colleges** (5 colleges)
- MAHA COLLEGE OF ENGINEERING (Bangalore)
- STELLAR INSTITUTE OF TECHNOLOGY (Hyderabad)
- APEX UNIVERSITY (Mumbai)
- PREMIER ENGINEERING COLLEGE (Chennai)
- ROYAL TECHNICAL INSTITUTE (Pune)

### 📚 **Courses** (8 types per college)
- Bachelor of Technology (B.Tech) - 4 years
- Master of Technology (M.Tech) - 2 years
- Bachelor of Computer Applications (BCA) - 3 years
- Master of Computer Applications (MCA) - 2 years
- Bachelor of Science (B.Sc) - 3 years
- Master of Science (M.Sc) - 2 years
- Bachelor of Business Administration (BBA) - 3 years
- Master of Business Administration (MBA) - 2 years

### 🎯 **Branches** (8+ per course type)
**B.Tech Branches:**
- Computer Science Engineering
- Electrical Engineering
- Mechanical Engineering
- Civil Engineering
- Electronics & Communication Engineering
- Information Technology
- Chemical Engineering
- Aeronautical Engineering

**M.Tech Branches:**
- Computer Science & Engineering
- VLSI Design
- Structural Engineering
- Machine Design
- Power Systems

### 📖 **Subjects** (20+ per branch)
**Year-wise and semester-wise subjects including:**
- Mathematics I, II, III, IV
- Programming languages (C, Java, Python)
- Core engineering subjects
- Specialized subjects based on branch
- Project work and internships

### 💰 **Fee Structures**
**Realistic fee ranges:**
- Computer Science/IT: ₹6-8 Lakhs
- Engineering: ₹4-7 Lakhs
- Science: ₹2-4 Lakhs
- Business: ₹3-5 Lakhs

### 👨‍🎓 **Students** (200 students)
**Realistic Indian names and data:**
- Names: Aarav Sharma, Ananya Patel, Rohan Kumar, etc.
- Email: firstname.lastname@student.collegename.edu.in
- Phone: +91-XXXXXXXXXX
- Addresses: Real Indian cities and areas
- Student IDs: College/Course code + Year + Number

### 📝 **Exams** (2-3 per subject)
- Mid-Semester Exams
- End-Semester Exams
- Internal Assessments
- Practical Exams

## How to Seed Data

### Method 1: Using API Endpoint (Recommended)

1. **Start the application:**
   ```bash
   dotnet run
   ```

2. **Open Swagger UI:**
   ```
   http://localhost:5298/swagger
   ```

3. **Use the Data Seed Controller:**
   - Find `DataSeed` controller in Swagger
   - Click on `POST /api/DataSeed/seed`
   - Click "Try it out"
   - Click "Execute"

4. **Monitor Progress:**
   The seeding process will show progress in the console:
   ```
   Starting data seeding...
   Created 5 colleges
   Created 25 courses
   Created 150 branches
   Created 150 fee structures
   Created 1200 subjects
   Created 50 students...
   Created 100 students...
   Created 150 students...
   Created 200 students...
   Created 2400 exams
   Data seeding completed successfully!
   ```

5. **Check Statistics:**
   - Use `GET /api/DataSeed/stats` to see database statistics
   - This shows counts of all created entities

### Method 2: Programmatic Seeding on Startup

If you want to automatically seed data when the application starts, add this to your `Program.cs`:

```csharp
// After app.Build() and before app.Run()
using (var scope = app.Services.CreateScope())
{
    try
    {
        await CollegeManagementSystem.Data.DataSeeder.SeedDataAsync(scope.ServiceProvider);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Data seeding failed: {ex.Message}");
    }
}
```

## Sample Data Details

### Student Data Examples:
```json
{
  "name": "Aarav Sharma",
  "email": "aarav.sharma@student.mahacollege.edu.in",
  "phone": "+91-9876543210",
  "address": "123, MG Road, Bangalore - 560001",
  "studentId": "MABT2024001",
  "collegeId": "college_id",
  "courseId": "btech_course_id",
  "branchId": "cse_branch_id",
  "year": 2
}
```

### College Data Examples:
```json
{
  "name": "MAHA COLLEGE OF ENGINEERING",
  "address": "123 Tech Park, Bangalore, Karnataka 560001",
  "establishedYear": 1995,
  "contactNumber": "+91-80-12345678",
  "email": "info@mahacollege.edu.in"
}
```

## Data Relationships

The seeded data maintains proper relationships:

```
College → Courses → Branches → Students
                    ↓
                 Subjects → Exams
                    ↓
              Fee Structures
```

## Verification Steps

After seeding, verify the data:

1. **Check Colleges:**
   ```
   GET /api/college
   ```

2. **Check Students:**
   ```
   GET /api/student
   ```

3. **Check Students by College:**
   ```
   GET /api/student/college/{collegeId}
   ```

4. **Check Subjects by Branch:**
   ```
   GET /api/subject/branch/{branchId}
   ```

5. **Check Fee Structure:**
   ```
   GET /api/feestructure/branch/{branchId}
   ```

## Features of the Seeded Data

### ✅ **Realistic Data**
- Authentic Indian names and locations
- Proper email formats and phone numbers
- Real engineering course structures
- Appropriate fee structures

### ✅ **Proper Relationships**
- Students properly assigned to colleges, courses, and branches
- Subjects organized by year and semester
- Fee structures linked to branches
- Exams scheduled for subjects

### ✅ **Comprehensive Coverage**
- Multiple colleges across different cities
- Various course types and durations
- Different branches and specializations
- 200+ students distributed across institutions

### ✅ **Data Consistency**
- Student IDs follow proper naming conventions
- Email addresses match student and college names
- Course durations and year assignments are logical
- Fee structures vary by course type appropriately

## Troubleshooting

### If seeding fails:
1. Ensure MongoDB is running
2. Check database connection in `appsettings.json`
3. Verify all services are properly registered
4. Check console for specific error messages

### If duplicate data:
The seeder checks for existing data and skips seeding if colleges already exist.

### Performance:
Seeding 200 students with all related data takes approximately 2-3 minutes depending on system performance.

---

**Note:** The seeded data is perfect for testing and demonstration purposes. All generated data follows realistic patterns while being completely fictional.