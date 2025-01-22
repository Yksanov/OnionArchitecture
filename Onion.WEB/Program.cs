using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Application.Services;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;
using Onion.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
builder.Services.AddIdentity<MyUser, IdentityRole<int>>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ITrialLessonRepository, TrialLessonRepository>();
builder.Services.AddTransient<ITrialLessonService, TrialLessonService>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IBranchRepository, BranchRepository>();
builder.Services.AddTransient<IBranchService, BranchService>();
builder.Services.AddTransient<IClassroomRepository, ClassroomRepository>();
builder.Services.AddTransient<IClassroomService, ClassroomService>();
builder.Services.AddTransient<IRequestRepository, RequestRepository>();
builder.Services.AddTransient<IRequestService, RequestService>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IGroupTypeRepository, GroupTypeRepository>();
builder.Services.AddTransient<IGroupTypeService, GroupTypeService>();
builder.Services.AddTransient<ILessonNameRepository, LessonNameRepository>();
builder.Services.AddTransient<ILessonNameService, LessonNameService>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
builder.Services.AddTransient<IScheduleService, ScheduleService>();
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IOperationRepository, OperationRepository>();
builder.Services.AddTransient<IOperationService, OperationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Teacher}/{action=AllTeachers}/{id?}");

app.Run();