# College Management System API

A simple Backend Server for College Management System built with C# .NET 8 and MongoDB.

## Features

- **College Management**: Create, read, update, and delete colleges
- **Course Management**: Manage courses offered by colleges (B.tech, M.tech, etc.)
- **Branch Management**: Manage branches within courses (Electrical, CS, Mechanical, etc.)
- **Student Management**: Add students to colleges, courses, and branches
- **Subject Management**: Manage subjects for each branch with year and semester
- **Fee Management**: Manage fee structures for each branch
- **Exam Management**: Schedule and manage exams for subjects

## Technology Stack

- **Backend**: C# .NET 8 Web API
- **Database**: MongoDB
- **Architecture**: Repository Pattern with Service Layer

## Prerequisites

- .NET 8 SDK
- MongoDB (local or cloud instance)

## Setup Instructions

1. **Clone the repository** (if applicable)

2. **Install MongoDB** (if not already installed)
   - Local: Download from [MongoDB website](https://www.mongodb.com/try/download/community)
   - Or use MongoDB Atlas (cloud)

3. **Configure Database Connection**
   - Update `appsettings.json` with your MongoDB connection string
   - Default: `mongodb://localhost:27017`
   - Database name: `CollegeManagementDB`

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**
   - Navigate to `https://localhost:5001/swagger` or `http://localhost:5000/swagger`

## API Endpoints

### College Management
- `GET /api/college` - Get all colleges
- `GET /api/college/{id}` - Get college by ID
- `POST /api/college` - Create new college
- `PUT /api/college/{id}` - Update college
- `DELETE /api/college/{id}` - Delete college
- `GET /api/college/search?name={name}` - Search colleges by name

### Course Management
- `GET /api/course` - Get all courses
- `GET /api/course/{id}` - Get course by ID
- `POST /api/course` - Create new course
- `DELETE /api/course/{id}` - Delete course
- `GET /api/course/college/{collegeId}` - Get courses by college

### Branch Management
- `GET /api/branch` - Get all branches
- `GET /api/branch/{id}` - Get branch by ID
- `POST /api/branch` - Create new branch
- `DELETE /api/branch/{id}` - Delete branch
- `GET /api/branch/course/{courseId}` - Get branches by course

### Student Management
- `GET /api/student` - Get all students
- `GET /api/student/{id}` - Get student by ID
- `POST /api/student` - Create new student
- `PUT /api/student/{id}` - Update student
- `DELETE /api/student/{id}` - Delete student
- `GET /api/student/college/{collegeId}` - Get students by college
- `GET /api/student/branch/{branchId}` - Get students by branch
- `GET /api/student/student-id/{studentId}` - Get student by student ID

### Subject Management
- `GET /api/subject` - Get all subjects
- `GET /api/subject/{id}` - Get subject by ID
- `POST /api/subject` - Create new subject
- `DELETE /api/subject/{id}` - Delete subject
- `GET /api/subject/branch/{branchId}` - Get subjects by branch
- `GET /api/subject/branch/{branchId}/year/{year}/semester/{semester}` - Get subjects by year and semester

### Fee Management
- `GET /api/feestructure` - Get all fee structures
- `GET /api/feestructure/{id}` - Get fee structure by ID
- `POST /api/feestructure` - Create new fee structure
- `DELETE /api/feestructure/{id}` - Delete fee structure
- `GET /api/feestructure/branch/{branchId}` - Get fee structure by branch

### Exam Management
- `GET /api/exam` - Get all exams
- `GET /api/exam/{id}` - Get exam by ID
- `POST /api/exam` - Create new exam
- `DELETE /api/exam/{id}` - Delete exam
- `GET /api/exam/branch/{branchId}` - Get exams by branch
- `GET /api/exam/subject/{subjectId}` - Get exams by subject
- `GET /api/exam/branch/{branchId}/year/{year}/semester/{semester}` - Get exams by year and semester

## Sample Data Flow

1. **Create a College**
   ```json
   POST /api/college
   {
     "name": "MAHA COLLEGE",
     "address": "123 Main St, City",
     "establishedYear": 2000,
     "contactNumber": "+1234567890",
     "email": "info@mahacollege.edu"
   }
   ```

2. **Create a Course**
   ```json
   POST /api/course
   {
     "name": "B.Tech",
     "durationYears": 4,
     "collegeId": "college_id_from_step_1"
   }
   ```

3. **Create a Branch**
   ```json
   POST /api/branch
   {
     "name": "Electrical Engineering",
     "courseId": "course_id_from_step_2"
   }
   ```

4. **Create Fee Structure**
   ```json
   POST /api/feestructure
   {
     "branchId": "branch_id_from_step_3",
     "totalFee": 400000,
     "yearlyFee": 100000,
     "semesterFee": 50000,
     "currency": "INR"
   }
   ```

5. **Create Subjects**
   ```json
   POST /api/subject
   {
     "name": "Mathematics",
     "code": "MATH101",
     "branchId": "branch_id_from_step_3",
     "year": 1,
     "semester": 1,
     "credits": 4
   }
   ```

6. **Add a Student**
   ```json
   POST /api/student
   {
     "name": "John Doe",
     "email": "john.doe@example.com",
     "phone": "+1234567890",
     "address": "456 Student St, City",
     "collegeId": "college_id_from_step_1",
     "courseId": "course_id_from_step_2",
     "branchId": "branch_id_from_step_3",
     "studentId": "STU001",
     "year": 1
   }
   ```

7. **Schedule an Exam**
   ```json
   POST /api/exam
   {
     "name": "Mid-term Mathematics",
     "type": "Mid-term",
     "branchId": "branch_id_from_step_3",
     "subjectId": "subject_id_from_step_5",
     "year": 1,
     "semester": 1,
     "examDate": "2024-03-15T10:00:00Z",
     "durationMinutes": 180,
     "maxMarks": 100
   }
   ```

## Project Structure

```
CollegeManagementSystem/
├── Controllers/           # API Controllers
├── Db/                   # Database configuration
├── Models/               # Entity models
│   └── RequestModels/    # Request DTOs
├── Repository/           # Repository pattern implementation
│   └── Interfaces/       # Repository interfaces
├── Services/             # Business logic layer
│   └── Interfaces/       # Service interfaces
├── Program.cs            # Application entry point
└── appsettings.json      # Configuration
```

## Notes

- MongoDB ObjectId is used as the primary key for all entities
- All timestamps are stored in UTC
- Simple validation - no complex business rules implemented
- RESTful API design principles followed
- Repository pattern with service layer for separation of concerns

## Development

To extend the system:
1. Add new models in the `Models` folder
2. Create corresponding repository interfaces and implementations
3. Create service interfaces and implementations
4. Add controllers for API endpoints
5. Register new services in `Program.cs`