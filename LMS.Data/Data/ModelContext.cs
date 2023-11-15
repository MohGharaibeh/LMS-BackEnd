using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LMS.Data.Data;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Plancourse> Plancourses { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userassignment> Userassignments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle("DATA SOURCE=DESKTOP-P1MURAO:1522/xe;USER ID=c##test;PASSWORD=123;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##TEST")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.Assignmentid).HasName("SYS_C008465");

            entity.ToTable("ASSIGNMENT");

            entity.Property(e => e.Assignmentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ASSIGNMENTID");
            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Deadline)
                .HasColumnType("DATE")
                .HasColumnName("DEADLINE");
            entity.Property(e => e.Grade)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("GRADE");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Sectionid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SECTIONID");

            entity.HasOne(d => d.Section).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.Sectionid)
                .HasConstraintName("SYS_C008466");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Attendenceid).HasName("SYS_C008468");

            entity.ToTable("ATTENDANCE");

            entity.Property(e => e.Attendenceid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ATTENDENCEID");
            entity.Property(e => e.Absente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABSENTE");
            entity.Property(e => e.Attendancedate)
                .HasColumnType("DATE")
                .HasColumnName("ATTENDANCEDATE");
            entity.Property(e => e.Sectionid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SECTIONID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Section).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.Sectionid)
                .HasConstraintName("SYS_C008469");

            entity.HasOne(d => d.User).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008470");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("SYS_C008451");

            entity.ToTable("COURSE");

            entity.Property(e => e.Courseid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Enrollmentid).HasName("SYS_C008472");

            entity.ToTable("ENROLLMENT");

            entity.Property(e => e.Enrollmentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ENROLLMENTID");
            entity.Property(e => e.Ispassed)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ISPASSED");
            entity.Property(e => e.Sectionid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SECTIONID");
            entity.Property(e => e.Totalmark)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("TOTALMARK");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Section).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.Sectionid)
                .HasConstraintName("SYS_C008474");

            entity.HasOne(d => d.User).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008473");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.Periodid).HasName("SYS_C008443");

            entity.ToTable("PERIOD");

            entity.Property(e => e.Periodid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PERIODID");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Startdate)
                .HasColumnType("DATE")
                .HasColumnName("STARTDATE");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.Planid).HasName("SYS_C008448");

            entity.ToTable("PLAN");

            entity.Property(e => e.Planid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PLANID");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Programid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PROGRAMID");

            entity.HasOne(d => d.Program).WithMany(p => p.Plans)
                .HasForeignKey(d => d.Programid)
                .HasConstraintName("SYS_C008449");
        });

        modelBuilder.Entity<Plancourse>(entity =>
        {
            entity.HasKey(e => e.Plancourseid).HasName("SYS_C008453");

            entity.ToTable("PLANCOURSE");

            entity.Property(e => e.Plancourseid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PLANCOURSEID");
            entity.Property(e => e.Courseid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Ordernumber)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ORDERNUMBER");
            entity.Property(e => e.Planid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PLANID");
            entity.Property(e => e.Prerequest)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PREREQUEST");
            entity.Property(e => e.Startdate)
                .HasColumnType("DATE")
                .HasColumnName("STARTDATE");

            entity.HasOne(d => d.Course).WithMany(p => p.Plancourses)
                .HasForeignKey(d => d.Courseid)
                .HasConstraintName("SYS_C008455");

            entity.HasOne(d => d.Plan).WithMany(p => p.Plancourses)
                .HasForeignKey(d => d.Planid)
                .HasConstraintName("SYS_C008454");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Programid).HasName("SYS_C008445");

            entity.ToTable("PROGRAM");

            entity.Property(e => e.Programid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PROGRAMID");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Periodid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PERIODID");

            entity.HasOne(d => d.Period).WithMany(p => p.Programs)
                .HasForeignKey(d => d.Periodid)
                .HasConstraintName("SYS_C008446");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("SYS_C008441");

            entity.ToTable("ROLE");

            entity.Property(e => e.Roleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Sectionid).HasName("SYS_C008461");

            entity.ToTable("SECTION");

            entity.Property(e => e.Sectionid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SECTIONID");
            entity.Property(e => e.Courseid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Time)
                .HasColumnType("DATE")
                .HasColumnName("TIME");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.Courseid)
                .HasConstraintName("SYS_C008462");

            entity.HasOne(d => d.User).WithMany(p => p.Sections)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008463");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("SYS_C008457");

            entity.ToTable("USERS");

            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Planid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PLANID");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLEID");

            entity.HasOne(d => d.Plan).WithMany(p => p.Users)
                .HasForeignKey(d => d.Planid)
                .HasConstraintName("SYS_C008459");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("SYS_C008458");
        });

        modelBuilder.Entity<Userassignment>(entity =>
        {
            entity.HasKey(e => e.Userassignmentid).HasName("SYS_C008476");

            entity.ToTable("USERASSIGNMENT");

            entity.Property(e => e.Userassignmentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERASSIGNMENTID");
            entity.Property(e => e.Assignmentid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ASSIGNMENTID");
            entity.Property(e => e.Mark)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("MARK");
            entity.Property(e => e.Submitcontent)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("SUBMITCONTENT");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Userassignments)
                .HasForeignKey(d => d.Assignmentid)
                .HasConstraintName("SYS_C008477");

            entity.HasOne(d => d.User).WithMany(p => p.Userassignments)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008478");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
