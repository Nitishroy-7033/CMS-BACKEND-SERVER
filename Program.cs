using MongoDB.Driver;
using CollegeManagementSystem.Db;
using CollegeManagementSystem.Repository;
using CollegeManagementSystem.Repository.Interfaces;
using CollegeManagementSystem.Services;
using CollegeManagementSystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure MongoDB
builder.Services.Configure<DbConfigs>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb") ?? "mongodb://localhost:27017";
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<DbConfigs>(serviceProvider =>
{
    var databaseName = builder.Configuration.GetValue<string>("MongoDbSettings:DatabaseName") ?? "CollegeManagementDB";
    var connectionString = builder.Configuration.GetConnectionString("MongoDb") ?? "mongodb://localhost:27017";
    return new DbConfigs
    {
        ConnectionString = connectionString,
        DatabaseName = databaseName
    };
});

builder.Services.AddScoped<IDbContext, DbContext>();

// Register repositories
builder.Services.AddScoped<ICollegeRepository, CollegeRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IFeeStructureRepository, FeeStructureRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();

// Register services
builder.Services.AddScoped<ICollegeService, CollegeService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IFeeStructureService, FeeStructureService>();
builder.Services.AddScoped<IExamService, ExamService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "College Management System API",
        Version = "v1",
        Description = "A comprehensive API for managing colleges, courses, branches, students, subjects, fees, and exams",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "College Management System",
            Email = "admin@collegemanagement.com"
        }
    });

    // Enable XML comments for better API documentation
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "College Management System API v1");
        c.RoutePrefix = "swagger";
        c.DocumentTitle = "College Management System API Documentation";
        c.DefaultModelsExpandDepth(-1); // Hide schemas section by default
        c.DisplayRequestDuration();
        c.EnableTryItOutByDefault();
    });
}
else
{
    // Enable Swagger in production as well for this demo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "College Management System API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
