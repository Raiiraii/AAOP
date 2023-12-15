﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Views;

public partial class dbContext : DbContext
{
    public dbContext()
    {
    }

    public dbContext(DbContextOptions<dbContext> options)
        : base(options)
    {
    }
    //public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<user> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;uid=alvarez;pwd=Alvarez1019.;database=useraccount"); //<- change the login credentials according to your mysql connection account in your pc

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //save the info on the entered data to the db
        //for user account only
        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("useraccount");

            entity.Property(e => e.Id).HasColumnName("userID");
            entity.Property(e => e.FName)
                .HasMaxLength(45)
                .HasColumnName("userFname");
            entity.Property(e => e.LName)
                .HasMaxLength(45)
                .HasColumnName("userLname");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
            entity.Property(e => e.Contact)
                .HasMaxLength(45)
                .HasColumnName("userContact");
            entity.Property(e => e.Bday)
                .HasColumnType("Date")
                .HasColumnName("userBday");
        });