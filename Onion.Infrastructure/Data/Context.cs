using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;

namespace Onion.Infrastructure.Data;

public class Context : IdentityDbContext<MyUser, IdentityRole<int>, int>
{
    public DbSet<MyUser> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupType> GroupTypes { get; set; }
    public DbSet<LessonName> LessonNames { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<TrialLesson> TrialLessons { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<OperationType> OperationTypes { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }
}