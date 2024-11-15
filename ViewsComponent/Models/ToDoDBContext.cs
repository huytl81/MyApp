﻿using Microsoft.EntityFrameworkCore;

namespace ViewsComponent.Models;

public class ToDoDbContext(DbContextOptions<ToDoDbContext> options) : DbContext(options)
{
    //public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    //{
    //}
    public DbSet<TodoItem>? ToDo { get; set; }

    //The following code is used to seed the DB.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        for (int i = 0; i < 9; i++)
        {
            modelBuilder.Entity<TodoItem>().HasData(
               new TodoItem
               {
                   Id = i + 1,
                   IsDone = i % 3 == 0,
                   Name = "Task " + (i + 1),
                   Priority = i % 5 + 1
               });
        }
    }
}
