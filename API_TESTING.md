# College Management System API Testing

This file contains sample API calls for testing the College Management System.

## Swagger UI Access

**Swagger URL**: `http://localhost:5298/swagger`

The Swagger UI provides interactive documentation where you can:
- View all available endpoints
- See request/response schemas
- Test API calls directly in the browser
- Download OpenAPI specification

## Enhanced Swagger Features

✅ **Comprehensive API Documentation**
- Detailed descriptions for all endpoints
- Request/response examples
- HTTP status code documentation
- Parameter descriptions

✅ **Interactive Testing**
- "Try it out" functionality enabled by default
- Request duration display
- Expandable response schemas

✅ **Professional Presentation**
- Custom title: "College Management System API"
- Contact information
- Version information
- Clean, organized interface

## Sample API Testing Workflow

### 1. Create a College
```http
POST /api/college
Content-Type: application/json

{
  "name": "MAHA COLLEGE",
  "address": "123 Education Street, Knowledge City",
  "establishedYear": 2000,
  "contactNumber": "+91-9876543210",
  "email": "info@mahacollege.edu"
}
```

### 2. Create a Course
```http
POST /api/course
Content-Type: application/json

{
  "name": "B.Tech",
  "durationYears": 4,
  "collegeId": "{{college_id_from_step_1}}"
}
```

### 3. Create a Branch
```http
POST /api/branch
Content-Type: application/json

{
  "name": "Computer Science Engineering",
  "courseId": "{{course_id_from_step_2}}"
}
```

### 4. Create Fee Structure
```http
POST /api/feestructure
Content-Type: application/json

{
  "branchId": "{{branch_id_from_step_3}}",
  "totalFee": 700000,
  "yearlyFee": 175000,
  "semesterFee": 87500,
  "currency": "INR"
}
```

### 5. Create Subjects
```http
POST /api/subject
Content-Type: application/json

{
  "name": "Data Structures and Algorithms",
  "code": "CS201",
  "branchId": "{{branch_id_from_step_3}}",
  "year": 2,
  "semester": 1,
  "credits": 4
}
```

### 6. Add a Student
```http
POST /api/student
Content-Type: application/json

{
  "name": "Rahul Kumar",
  "email": "rahul.kumar@student.mahacollege.edu",
  "phone": "+91-9876543211",
  "address": "456 Student Hostel, College Campus",
  "collegeId": "{{college_id_from_step_1}}",
  "courseId": "{{course_id_from_step_2}}",
  "branchId": "{{branch_id_from_step_3}}",
  "studentId": "MAHA2024CS001",
  "year": 2
}
```

### 7. Schedule an Exam
```http
POST /api/exam
Content-Type: application/json

{
  "name": "Mid-Semester Examination - Data Structures",
  "type": "Mid-Semester",
  "branchId": "{{branch_id_from_step_3}}",
  "subjectId": "{{subject_id_from_step_5}}",
  "year": 2,
  "semester": 1,
  "examDate": "2024-10-15T09:00:00Z",
  "durationMinutes": 180,
  "maxMarks": 100
}
```

## Key Swagger UI Features

### 📚 **Documentation**
- Each endpoint has detailed descriptions
- Parameters are clearly explained
- Response codes and their meanings are documented
- Request/response schemas are shown with examples

### 🧪 **Testing**
- Click "Try it out" to test any endpoint
- Fill in parameters and request body
- Execute requests directly from the browser
- See real-time responses with timing information

### 🔍 **Exploration**
- Browse all available endpoints organized by controller
- Expand/collapse sections for better navigation
- View model schemas and relationships
- Download OpenAPI specification for external tools

### 🎨 **User Experience**
- Clean, professional interface
- Responsive design
- Search functionality
- Keyboard shortcuts support

## Quick Access URLs

- **Swagger UI**: `http://localhost:5298/swagger`
- **OpenAPI JSON**: `http://localhost:5298/swagger/v1/swagger.json`
- **Health Check**: `http://localhost:5298/api/college` (GET all colleges)

## Available in Both Development and Production

The Swagger UI is configured to be available in both development and production environments, making it easy to test and document the API in any environment.

---

**Note**: Replace `{{variable_name}}` with actual IDs returned from previous API calls when testing the workflow.