using CollegeManagementSystem.Models;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Data
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            
            var collegeService = scope.ServiceProvider.GetRequiredService<ICollegeService>();
            var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
            var branchService = scope.ServiceProvider.GetRequiredService<IBranchService>();
            var subjectService = scope.ServiceProvider.GetRequiredService<ISubjectService>();
            var feeStructureService = scope.ServiceProvider.GetRequiredService<IFeeStructureService>();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
            var examService = scope.ServiceProvider.GetRequiredService<IExamService>();

            Console.WriteLine("Starting data seeding...");

            // Check if data already exists
            var existingColleges = await collegeService.GetAllCollegesAsync();
            if (existingColleges.Any())
            {
                Console.WriteLine("Data already exists. Skipping seeding.");
                return;
            }

            // Create Colleges
            var colleges = await SeedColleges(collegeService);
            Console.WriteLine($"Created {colleges.Count} colleges");

            // Create Courses
            var courses = await SeedCourses(courseService, colleges);
            Console.WriteLine($"Created {courses.Count} courses");

            // Create Branches
            var branches = await SeedBranches(branchService, courses);
            Console.WriteLine($"Created {branches.Count} branches");

            // Create Fee Structures
            var feeStructures = await SeedFeeStructures(feeStructureService, branches);
            Console.WriteLine($"Created {feeStructures.Count} fee structures");

            // Create Subjects
            var subjects = await SeedSubjects(subjectService, branches);
            Console.WriteLine($"Created {subjects.Count} subjects");

            // Create Students
            var students = await SeedStudents(studentService, colleges, courses, branches);
            Console.WriteLine($"Created {students.Count} students");

            // Create Exams
            var exams = await SeedExams(examService, branches, subjects);
            Console.WriteLine($"Created {exams.Count} exams");

            Console.WriteLine("Data seeding completed successfully!");
        }

        private static async Task<List<College>> SeedColleges(ICollegeService collegeService)
        {
            var collegeData = new[]
            {
                new { Name = "MAHA COLLEGE OF ENGINEERING", Address = "123 Tech Park, Bangalore, Karnataka 560001", EstablishedYear = 1995, ContactNumber = "+91-80-12345678", Email = "info@mahacollege.edu.in" },
                new { Name = "STELLAR INSTITUTE OF TECHNOLOGY", Address = "456 Knowledge City, Hyderabad, Telangana 500032", EstablishedYear = 2000, ContactNumber = "+91-40-87654321", Email = "admissions@stellartech.edu.in" },
                new { Name = "APEX UNIVERSITY", Address = "789 Education Boulevard, Mumbai, Maharashtra 400001", EstablishedYear = 1988, ContactNumber = "+91-22-11223344", Email = "contact@apexuniversity.edu.in" },
                new { Name = "PREMIER ENGINEERING COLLEGE", Address = "321 Innovation Drive, Chennai, Tamil Nadu 600001", EstablishedYear = 2005, ContactNumber = "+91-44-55667788", Email = "info@premiereng.edu.in" },
                new { Name = "ROYAL TECHNICAL INSTITUTE", Address = "654 Science City, Pune, Maharashtra 411001", EstablishedYear = 1998, ContactNumber = "+91-20-99887766", Email = "admin@royaltech.edu.in" }
            };

            var colleges = new List<College>();
            foreach (var data in collegeData)
            {
                var request = new Models.RequestModels.CreateCollegeRequest
                {
                    Name = data.Name,
                    Address = data.Address,
                    EstablishedYear = data.EstablishedYear,
                    ContactNumber = data.ContactNumber,
                    Email = data.Email
                };
                
                var college = await collegeService.CreateCollegeAsync(request);
                colleges.Add(college);
            }

            return colleges;
        }

        private static async Task<List<Course>> SeedCourses(ICourseService courseService, List<College> colleges)
        {
            var courseData = new[]
            {
                new { Name = "Bachelor of Technology (B.Tech)", DurationYears = 4 },
                new { Name = "Master of Technology (M.Tech)", DurationYears = 2 },
                new { Name = "Bachelor of Computer Applications (BCA)", DurationYears = 3 },
                new { Name = "Master of Computer Applications (MCA)", DurationYears = 2 },
                new { Name = "Bachelor of Science (B.Sc)", DurationYears = 3 },
                new { Name = "Master of Science (M.Sc)", DurationYears = 2 },
                new { Name = "Bachelor of Business Administration (BBA)", DurationYears = 3 },
                new { Name = "Master of Business Administration (MBA)", DurationYears = 2 }
            };

            var courses = new List<Course>();
            foreach (var college in colleges)
            {
                // Each college offers 4-6 courses
                var coursesToCreate = courseData.Take(new Random().Next(4, 7));
                
                foreach (var data in coursesToCreate)
                {
                    var request = new Models.RequestModels.CreateCourseRequest
                    {
                        Name = data.Name,
                        DurationYears = data.DurationYears,
                        CollegeId = college.Id
                    };
                    
                    var course = await courseService.CreateCourseAsync(request);
                    courses.Add(course);
                }
            }

            return courses;
        }

        private static async Task<List<Branch>> SeedBranches(IBranchService branchService, List<Course> courses)
        {
            var branchData = new Dictionary<string, string[]>
            {
                ["Bachelor of Technology (B.Tech)"] = new[] 
                { 
                    "Computer Science Engineering", 
                    "Electrical Engineering", 
                    "Mechanical Engineering", 
                    "Civil Engineering", 
                    "Electronics & Communication Engineering",
                    "Information Technology",
                    "Chemical Engineering",
                    "Aeronautical Engineering"
                },
                ["Master of Technology (M.Tech)"] = new[] 
                { 
                    "Computer Science & Engineering", 
                    "VLSI Design", 
                    "Structural Engineering", 
                    "Machine Design",
                    "Power Systems"
                },
                ["Bachelor of Computer Applications (BCA)"] = new[] 
                { 
                    "Software Development", 
                    "Database Management", 
                    "Web Technologies" 
                },
                ["Master of Computer Applications (MCA)"] = new[] 
                { 
                    "Software Engineering", 
                    "Data Science", 
                    "Cyber Security" 
                },
                ["Bachelor of Science (B.Sc)"] = new[] 
                { 
                    "Computer Science", 
                    "Mathematics", 
                    "Physics", 
                    "Chemistry" 
                },
                ["Master of Science (M.Sc)"] = new[] 
                { 
                    "Computer Science", 
                    "Data Analytics", 
                    "Applied Mathematics" 
                },
                ["Bachelor of Business Administration (BBA)"] = new[] 
                { 
                    "Finance", 
                    "Marketing", 
                    "Human Resources" 
                },
                ["Master of Business Administration (MBA)"] = new[] 
                { 
                    "Finance", 
                    "Marketing", 
                    "Operations", 
                    "Human Resources" 
                }
            };

            var branches = new List<Branch>();
            foreach (var course in courses)
            {
                if (branchData.ContainsKey(course.Name))
                {
                    var branchNames = branchData[course.Name];
                    foreach (var branchName in branchNames)
                    {
                        var request = new Models.RequestModels.CreateBranchRequest
                        {
                            Name = branchName,
                            CourseId = course.Id
                        };
                        
                        var branch = await branchService.CreateBranchAsync(request);
                        branches.Add(branch);
                    }
                }
            }

            return branches;
        }

        private static async Task<List<FeeStructure>> SeedFeeStructures(IFeeStructureService feeStructureService, List<Branch> branches)
        {
            var feeStructures = new List<FeeStructure>();
            var random = new Random();

            // Fee ranges based on course types
            var feeRanges = new Dictionary<string, (decimal min, decimal max)>
            {
                ["Computer Science"] = (600000, 800000),
                ["Engineering"] = (400000, 700000),
                ["Science"] = (200000, 400000),
                ["Business"] = (300000, 500000),
                ["Technology"] = (500000, 750000)
            };

            foreach (var branch in branches)
            {
                decimal totalFee;
                
                // Determine fee based on branch type
                if (branch.Name.Contains("Computer Science") || branch.Name.Contains("Information Technology"))
                    totalFee = random.Next(600000, 800001);
                else if (branch.Name.Contains("Engineering"))
                    totalFee = random.Next(400000, 700001);
                else if (branch.Name.Contains("Science") || branch.Name.Contains("Mathematics"))
                    totalFee = random.Next(200000, 400001);
                else if (branch.Name.Contains("Business") || branch.Name.Contains("BBA") || branch.Name.Contains("MBA"))
                    totalFee = random.Next(300000, 500001);
                else
                    totalFee = random.Next(350000, 600001);

                var request = new Models.RequestModels.CreateFeeStructureRequest
                {
                    BranchId = branch.Id,
                    TotalFee = totalFee,
                    YearlyFee = totalFee / 4, // Assuming 4 years for calculation
                    SemesterFee = totalFee / 8, // 8 semesters
                    Currency = "INR"
                };
                
                var feeStructure = await feeStructureService.CreateFeeStructureAsync(request);
                feeStructures.Add(feeStructure);
            }

            return feeStructures;
        }

        private static async Task<List<Subject>> SeedSubjects(ISubjectService subjectService, List<Branch> branches)
        {
            var subjectTemplates = new Dictionary<string, Dictionary<int, Dictionary<int, string[]>>>
            {
                ["Computer Science"] = new Dictionary<int, Dictionary<int, string[]>>
                {
                    [1] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Mathematics I", "Physics", "Basic Electrical Engineering", "Programming in C", "English Communication" },
                        [2] = new[] { "Mathematics II", "Chemistry", "Engineering Mechanics", "Data Structures", "Technical Writing" }
                    },
                    [2] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Mathematics III", "Computer Organization", "Database Management Systems", "Object Oriented Programming", "Discrete Mathematics" },
                        [2] = new[] { "Operating Systems", "Computer Networks", "Software Engineering", "Web Technologies", "Theory of Computation" }
                    },
                    [3] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Algorithms Analysis", "Machine Learning", "Compiler Design", "Mobile Application Development", "Computer Graphics" },
                        [2] = new[] { "Artificial Intelligence", "Cyber Security", "Cloud Computing", "Big Data Analytics", "Human Computer Interaction" }
                    },
                    [4] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Advanced Algorithms", "Distributed Systems", "Project Management", "Blockchain Technology", "IoT Applications" },
                        [2] = new[] { "Capstone Project", "Industry Internship", "Research Methodology", "Entrepreneurship", "Professional Ethics" }
                    }
                },
                ["Engineering"] = new Dictionary<int, Dictionary<int, string[]>>
                {
                    [1] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Engineering Mathematics I", "Engineering Physics", "Basic Civil Engineering", "Engineering Drawing", "Environmental Studies" },
                        [2] = new[] { "Engineering Mathematics II", "Engineering Chemistry", "Basic Mechanical Engineering", "Workshop Technology", "Communication Skills" }
                    },
                    [2] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Engineering Mathematics III", "Strength of Materials", "Thermodynamics", "Fluid Mechanics", "Material Science" },
                        [2] = new[] { "Engineering Mathematics IV", "Machine Design", "Heat Transfer", "Manufacturing Processes", "Industrial Engineering" }
                    },
                    [3] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Advanced Engineering", "Control Systems", "Power Systems", "Digital Electronics", "Microprocessors" },
                        [2] = new[] { "Project Engineering", "Quality Control", "Automation", "Renewable Energy", "Advanced Materials" }
                    },
                    [4] = new Dictionary<int, string[]>
                    {
                        [1] = new[] { "Advanced Design", "Research Project", "Industrial Training", "Management Principles", "Safety Engineering" },
                        [2] = new[] { "Final Year Project", "Seminar", "Professional Practice", "Innovation Management", "Global Engineering" }
                    }
                }
            };

            var subjects = new List<Subject>();
            var random = new Random();

            foreach (var branch in branches)
            {
                Dictionary<int, Dictionary<int, string[]>>? template = null;
                
                if (branch.Name.Contains("Computer") || branch.Name.Contains("IT") || branch.Name.Contains("Software"))
                    template = subjectTemplates["Computer Science"];
                else
                    template = subjectTemplates["Engineering"];

                foreach (var year in template.Keys)
                {
                    foreach (var semester in template[year].Keys)
                    {
                        var subjectNames = template[year][semester];
                        foreach (var subjectName in subjectNames)
                        {
                            var request = new Models.RequestModels.CreateSubjectRequest
                            {
                                Name = subjectName,
                                Code = GenerateSubjectCode(subjectName, year, semester),
                                BranchId = branch.Id,
                                Year = year,
                                Semester = semester,
                                Credits = random.Next(3, 5) // 3-4 credits
                            };
                            
                            var subject = await subjectService.CreateSubjectAsync(request);
                            subjects.Add(subject);
                        }
                    }
                }
            }

            return subjects;
        }

        private static async Task<List<Student>> SeedStudents(IStudentService studentService, List<College> colleges, List<Course> courses, List<Branch> branches)
        {
            var students = new List<Student>();
            var random = new Random();

            // Indian names for realistic data
            var firstNames = new[]
            {
                "Aarav", "Vivaan", "Aditya", "Vihaan", "Arjun", "Sai", "Reyansh", "Ayaan", "Krishna", "Ishaan",
                "Ananya", "Diya", "Priya", "Kavya", "Aanya", "Sara", "Aadhya", "Riya", "Myra", "Kiara",
                "Rohan", "Aryan", "Karthik", "Rahul", "Aditya", "Vikram", "Siddharth", "Nikhil", "Abhishek", "Varun",
                "Sneha", "Pooja", "Meera", "Nisha", "Divya", "Shreya", "Neha", "Anjali", "Preeti", "Swati",
                "Dev", "Dhruv", "Harsh", "Jay", "Karan", "Manav", "Neil", "Om", "Pranav", "Ravi",
                "Aditi", "Bhavya", "Deepika", "Garima", "Isha", "Jiya", "Khushi", "Lakshmi", "Mahika", "Navya"
            };

            var lastNames = new[]
            {
                "Sharma", "Verma", "Gupta", "Kumar", "Singh", "Patel", "Joshi", "Shah", "Mehta", "Agarwal",
                "Yadav", "Mishra", "Pandey", "Tiwari", "Srivastava", "Chopra", "Malhotra", "Kapoor", "Arora", "Bansal",
                "Rajput", "Chauhan", "Thakur", "Nair", "Iyer", "Reddy", "Rao", "Krishnan", "Pillai", "Menon",
                "Bhat", "Kulkarni", "Desai", "Jain", "Aggarwal", "Saxena", "Goel", "Bhardwaj", "Chandra", "Sinha"
            };

            var cities = new[]
            {
                "Mumbai", "Delhi", "Bangalore", "Hyderabad", "Chennai", "Pune", "Kolkata", "Ahmedabad", "Jaipur", "Lucknow",
                "Kanpur", "Nagpur", "Indore", "Bhopal", "Visakhapatnam", "Patna", "Vadodara", "Ghaziabad", "Ludhiana", "Coimbatore"
            };

            // Create 200 students distributed across colleges and branches
            for (int i = 1; i <= 200; i++)
            {
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = lastNames[random.Next(lastNames.Length)];
                var fullName = $"{firstName} {lastName}";
                
                var college = colleges[random.Next(colleges.Count)];
                var collegeCourses = courses.Where(c => c.CollegeId == college.Id).ToList();
                
                if (!collegeCourses.Any()) continue;
                
                var course = collegeCourses[random.Next(collegeCourses.Count)];
                var courseBranches = branches.Where(b => b.CourseId == course.Id).ToList();
                
                if (!courseBranches.Any()) continue;
                
                var branch = courseBranches[random.Next(courseBranches.Count)];
                var city = cities[random.Next(cities.Length)];
                
                var studentId = GenerateStudentId(college.Name, course.Name, i);
                var year = random.Next(1, course.DurationYears + 1);

                var request = new Models.RequestModels.CreateStudentRequest
                {
                    Name = fullName,
                    Email = $"{firstName.ToLower()}.{lastName.ToLower()}@student.{college.Name.Replace(" ", "").ToLower()}.edu.in",
                    Phone = $"+91-{random.Next(70, 100)}{random.Next(10000000, 99999999)}",
                    Address = $"{random.Next(1, 999)}, {GenerateAreaName()}, {city} - {random.Next(400001, 600000)}",
                    CollegeId = college.Id,
                    CourseId = course.Id,
                    BranchId = branch.Id,
                    StudentId = studentId,
                    Year = year
                };
                
                var student = await studentService.CreateStudentAsync(request);
                students.Add(student);
                
                // Progress indicator
                if (i % 50 == 0)
                {
                    Console.WriteLine($"Created {i} students...");
                }
            }

            return students;
        }

        private static async Task<List<Exam>> SeedExams(IExamService examService, List<Branch> branches, List<Subject> subjects)
        {
            var exams = new List<Exam>();
            var random = new Random();
            var examTypes = new[] { "Mid-Semester", "End-Semester", "Internal Assessment", "Practical Exam" };

            foreach (var branch in branches)
            {
                var branchSubjects = subjects.Where(s => s.BranchId == branch.Id).ToList();
                
                foreach (var subject in branchSubjects)
                {
                    // Create 2-3 exams per subject per year
                    var examCount = random.Next(2, 4);
                    
                    for (int i = 0; i < examCount; i++)
                    {
                        var examType = examTypes[i % examTypes.Length];
                        var examDate = DateTime.UtcNow.AddDays(random.Next(-30, 90)); // Past 30 days to next 90 days
                        
                        var request = new Models.RequestModels.CreateExamRequest
                        {
                            Name = $"{examType} - {subject.Name}",
                            Type = examType,
                            BranchId = branch.Id,
                            SubjectId = subject.Id,
                            Year = subject.Year,
                            Semester = subject.Semester,
                            ExamDate = examDate,
                            DurationMinutes = examType.Contains("Practical") ? 180 : random.Next(120, 181), // 2-3 hours
                            MaxMarks = examType == "Internal Assessment" ? 50 : 100
                        };
                        
                        var exam = await examService.CreateExamAsync(request);
                        exams.Add(exam);
                    }
                }
            }

            return exams;
        }

        private static string GenerateSubjectCode(string subjectName, int year, int semester)
        {
            var words = subjectName.Split(' ');
            var code = string.Join("", words.Take(2).Select(w => w.Substring(0, Math.Min(2, w.Length)).ToUpper()));
            return $"{code}{year}{semester}{new Random().Next(1, 10)}";
        }

        private static string GenerateStudentId(string collegeName, string courseName, int index)
        {
            var collegeCode = string.Join("", collegeName.Split(' ').Take(2).Select(w => w.Substring(0, 1).ToUpper()));
            var courseCode = courseName.Contains("B.Tech") ? "BT" : 
                           courseName.Contains("M.Tech") ? "MT" : 
                           courseName.Contains("BCA") ? "BCA" : 
                           courseName.Contains("MCA") ? "MCA" : 
                           courseName.Contains("B.Sc") ? "BSC" : 
                           courseName.Contains("M.Sc") ? "MSC" : 
                           courseName.Contains("BBA") ? "BBA" : "MBA";
            
            return $"{collegeCode}{courseCode}{DateTime.Now.Year}{index:D3}";
        }

        private static string GenerateAreaName()
        {
            var areas = new[]
            {
                "MG Road", "Brigade Road", "Koramangala", "Indiranagar", "Jayanagar", "BTM Layout", "Electronic City",
                "Whitefield", "Marathahalli", "Sarjapur Road", "HSR Layout", "JP Nagar", "Banashankari", "Rajajinagar",
                "Malleshwaram", "Basavanagudi", "Commercial Street", "Cunningham Road", "Richmond Road", "Residency Road"
            };
            
            return areas[new Random().Next(areas.Length)];
        }
    }
}