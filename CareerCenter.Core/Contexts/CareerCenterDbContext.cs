using CareerCenter.Core.Models;
using CareerCenter.Core.Permissions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CareerCenter.Core.Contexts
{
    public class CareerCenterDbContext : IdentityDbContext<User, Role, int>
    {
       
        public CareerCenterDbContext(DbContextOptions<CareerCenterDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
        .HasData(
            new Role
            { 
                Id=1,
                DisplayName="Администратор",
                NormalizedName="Администратор",
                Name = BasicPermissions.Admin
            },
             new Role
             {
                 Id=2,
                 DisplayName = "Модератор",
                 NormalizedName = "Модератор",
                 Name = BasicPermissions.Moderator
             },
            new Role
            { 
                Id=3,
                DisplayName="Студент",
                NormalizedName= "Студент",
                Name = BasicPermissions.Student
            },
           
            new Role
            { 
                Id=4,
                DisplayName="Преподователь",
                NormalizedName= "Преподователь",
                Name = BasicPermissions.Teacher
            },
            new Role
            { 
                Id=5,
                DisplayName="Партнер",
                NormalizedName= "Партнер",
                Name = BasicPermissions.Partner
            }
            
        );
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id=1,
                UserName = "Administrator",
                NormalizedUserName = "Administrator",
                Email = "test@test.com",
                NormalizedEmail = "test@test.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Test.1234"),
                //SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Announcement> Announcements { get; set; }//объявлении
        public DbSet<Article> Articles { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<FaqCategory> FaqCategories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PartnerCategory> PartnerCategories { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<RegulationCategory> RegulationCategories { get; set; }
        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<NotableStudent> NotableStudents { get; set; }
        public DbSet<SlideShow> SlideShows { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyCategory> VacancyCategories { get; set; }
        public DbSet<AnnouncementCategory> AnnouncementCategories { get; set; }
    }
}
