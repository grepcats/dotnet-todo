﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options)
     : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

      //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         //   => optionsBuilder
         //   .UseMySql(@"Server=localhost;Port=8889;database=todolist;uid=root;pwd=root");
    }
}
