﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoApi;

public partial class ToDoDbContext : DbContext
{
    public ToDoDbContext()
    {
    }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

       => optionsBuilder.UseMySql("server=bubmcdnpmx2nzgzoxq2w-mysql.services.clever-cloud.com;user=ukbh35mphirq18xo;password=qUTJYGN6tYuY4WmS9w29;database=bubmcdnpmx2nzgzoxq2w", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("items");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
