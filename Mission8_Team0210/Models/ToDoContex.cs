using System;
using Microsoft.EntityFrameworkCore;

namespace Mission8_Team0210.Models
{
    public class ToDoContex : DbContext
    {
        public ToDoContex(DbContextOptions<ToDoContex> options) : base (options)
        {
        }

        public DbSet<ToDoList> Lists { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Church"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Other"
                }
                );
            mb.Entity<ToDoList>().HasData(
                new ToDoList
                {
                    TaskId = 1,
                    Task = "Call mistering sisters!",
                    Date = "02/27/2023",
                    Quadrant = 2,
                    CategoryId = 4,
                    IsCompleted = false
                },
                new ToDoList
                {
                    TaskId = 2,
                    Task = "IS 413 Mission 8",
                    Date = "02/24/2023",
                    Quadrant = 1,
                    CategoryId = 2,
                    IsCompleted = false
                },
                new ToDoList
                {
                    TaskId = 3,
                    Task = "Call home for tuition money!",
                    Date = "02/26/2023",
                    Quadrant = 3,
                    CategoryId = 2,
                    IsCompleted = false
                },
                new ToDoList
                {
                    TaskId = 4,
                    Task = "Read through email from friends on mission",
                    Quadrant = 4,
                    CategoryId = 5,
                    IsCompleted = false
                }
                );
        }
    }
}

