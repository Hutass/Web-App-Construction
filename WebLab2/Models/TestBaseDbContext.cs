using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebLab2.Models;

public partial class TestBaseDbContext : IdentityDbContext<User>
{
    protected readonly IConfiguration Configuration;
    public TestBaseDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public virtual DbSet<Right> Rights { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<TestResultStat> TestResultStats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("Answer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.Text).HasMaxLength(300);

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_Answer_Question");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RightsId).HasColumnName("RightsID");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Rights).WithMany(p => p.Persons)
                .HasForeignKey(d => d.RightsId)
                .HasConstraintName("FK_Person_Right");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("Test");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TestId).HasColumnName("TestID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK_Question_Test");

            entity.HasOne(d => d.Type).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Question_QuestionType");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.ToTable("QuestionType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Right>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.ToTable("TestResult");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.TestId).HasColumnName("TestID");

            entity.HasOne(d => d.Person).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_TestResult_Person");

            entity.HasOne(d => d.Test).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK_TestResult_Test");
        });

        modelBuilder.Entity<TestResultStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TestResultStat");

            entity.Property(e => e.AnswerId).HasColumnName("AnswerID");
            entity.Property(e => e.TestResultId).HasColumnName("TestResultID");

            entity.HasOne(d => d.Answer).WithMany()
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_TestResultStat_Answer");

            entity.HasOne(d => d.TestResult).WithMany()
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_TestResultStat_TestResult");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
