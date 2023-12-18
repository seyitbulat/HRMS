﻿Imports System
Imports System.Collections.Generic
Imports Microsoft.EntityFrameworkCore

Namespace Models
    Partial Public Class HrmsContext
        Inherits DbContext


        Public Overridable Property Candidates As DbSet(Of Candidate)

        Public Overridable Property Departments As DbSet(Of Department)

        Public Overridable Property Employees As DbSet(Of Employee)

        Public Overridable Property Interviews As DbSet(Of Interview)

        Public Overridable Property Leaves As DbSet(Of Leaf)

        Public Overridable Property LeavesTypes As DbSet(Of LeavesType)

        Public Overridable Property PerformanceReviews As DbSet(Of PerformanceReview)

        Public Overridable Property Positions As DbSet(Of Position)

        Public Overridable Property Salaries As DbSet(Of Salary)

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            'TODO /!\ To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R04PVQ3\SQLEXPRESS; Initial Catalog=HRMS; Integrated Security=true; TrustServerCertificate=True")
        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.Entity(Of Candidate)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Applicationdate).
                        HasColumnType("date").
                        HasColumnName("APPLICATIONDATE")
                    entity.Property(Function(e) e.Appliedpositionid).HasColumnName("APPLIEDPOSITIONID")
                    entity.Property(Function(e) e.Firstname).
                        IsRequired().
                        HasMaxLength(50).
                        HasColumnName("FIRSTNAME")
                    entity.Property(Function(e) e.Lastname).
                        IsRequired().
                        HasMaxLength(50).
                        HasColumnName("LASTNAME")
                    entity.Property(Function(e) e.Resumelink).
                        HasMaxLength(50).
                        HasColumnName("RESUMELINK")

                    entity.HasOne(Function(d) d.Appliedposition).WithMany(Function(p) p.Candidates).
                        HasForeignKey(Function(d) d.Appliedpositionid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_Candidates_Positions")
                End Sub)

            modelBuilder.Entity(Of Department)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Departmentname).
                        IsRequired().
                        HasMaxLength(100).
                        HasColumnName("DEPARTMENTNAME")
                    entity.Property(Function(e) e.Managerid).HasColumnName("MANAGERID")

                    entity.HasOne(Function(d) d.Manager).WithMany(Function(p) p.Departments).
                        HasForeignKey(Function(d) d.Managerid).
                        HasConstraintName("FK_Departments_Employees")
                End Sub)

            modelBuilder.Entity(Of Employee)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Birthdate).
                        HasColumnType("date").
                        HasColumnName("BIRTHDATE")
                    entity.Property(Function(e) e.Departmanid).HasColumnName("DEPARTMANID")
                    entity.Property(Function(e) e.Email).
                        IsRequired().
                        HasMaxLength(100).
                        HasColumnName("EMAIL")
                    entity.Property(Function(e) e.Firstname).
                        IsRequired().
                        HasMaxLength(50).
                        HasColumnName("FIRSTNAME")
                    entity.Property(Function(e) e.Gender).HasColumnName("GENDER")
                    entity.Property(Function(e) e.Hiredate).
                        HasColumnType("date").
                        HasColumnName("HIREDATE")
                    entity.Property(Function(e) e.Lastname).
                        IsRequired().
                        HasMaxLength(50).
                        HasColumnName("LASTNAME")
                    entity.Property(Function(e) e.Managerid).HasColumnName("MANAGERID")
                    entity.Property(Function(e) e.Phonenumber).
                        HasMaxLength(15).
                        HasColumnName("PHONENUMBER")
                    entity.Property(Function(e) e.Positionid).HasColumnName("POSITIONID")

                    entity.HasOne(Function(d) d.Departman).WithMany(Function(p) p.Employees).
                        HasForeignKey(Function(d) d.Departmanid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_Employees_Departments")

                    entity.HasOne(Function(d) d.Manager).WithMany(Function(p) p.InverseManager).
                        HasForeignKey(Function(d) d.Managerid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_Employees_Employees2")

                    entity.HasOne(Function(d) d.Position).WithMany(Function(p) p.Employees).
                        HasForeignKey(Function(d) d.Positionid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_Employees_Positions")
                End Sub)

            modelBuilder.Entity(Of Interview)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Candidateid).HasColumnName("CANDIDATEID")
                    entity.Property(Function(e) e.Interviewdate).
                        HasColumnType("date").
                        HasColumnName("INTERVIEWDATE")
                    entity.Property(Function(e) e.Interviewerid).HasColumnName("INTERVIEWERID")
                    entity.Property(Function(e) e.Interviewnotes).
                        HasMaxLength(1000).
                        HasColumnName("INTERVIEWNOTES")
                    entity.Property(Function(e) e.Interviewoutcome).
                        HasMaxLength(50).
                        HasColumnName("INTERVIEWOUTCOME")

                    entity.HasOne(Function(d) d.Candidate).WithMany(Function(p) p.Interviews).
                        HasForeignKey(Function(d) d.Candidateid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_Interviews_Candidates")

                    entity.HasOne(Function(d) d.Interviewer).WithMany(Function(p) p.Interviews).
                        HasForeignKey(Function(d) d.Interviewerid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_Interviews_Employees")
                End Sub)

            modelBuilder.Entity(Of Leaf)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Employeeid).HasColumnName("EMPLOYEEID")
                    entity.Property(Function(e) e.Enddate).
                        HasColumnType("date").
                        HasColumnName("ENDDATE")
                    entity.Property(Function(e) e.Leavetypeid).HasColumnName("LEAVETYPEID")
                    entity.Property(Function(e) e.Startdate).
                        HasColumnType("date").
                        HasColumnName("STARTDATE")
                    entity.Property(Function(e) e.Status).
                        HasMaxLength(50).
                        HasColumnName("STATUS")

                    entity.HasOne(Function(d) d.Employee).WithMany(Function(p) p.Leaves).
                        HasForeignKey(Function(d) d.Employeeid).
                        HasConstraintName("FK_Leaves_Employees")

                    entity.HasOne(Function(d) d.Leavetype).WithMany(Function(p) p.Leaves).
                        HasForeignKey(Function(d) d.Leavetypeid).
                        HasConstraintName("FK_Leaves_LeavesTypes")
                End Sub)

            modelBuilder.Entity(Of LeavesType)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK_LeavesType")

                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Description).
                        HasMaxLength(500).
                        HasColumnName("DESCRIPTION")
                    entity.Property(Function(e) e.Typename).
                        IsRequired().
                        HasMaxLength(50).
                        HasColumnName("TYPENAME")
                End Sub)

            modelBuilder.Entity(Of PerformanceReview)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Comments).
                        HasMaxLength(1000).
                        HasColumnName("COMMENTS")
                    entity.Property(Function(e) e.Employeeid).HasColumnName("EMPLOYEEID")
                    entity.Property(Function(e) e.Reviewdate).
                        HasColumnType("date").
                        HasColumnName("REVIEWDATE")
                    entity.Property(Function(e) e.Reviewerid).HasColumnName("REVIEWERID")
                    entity.Property(Function(e) e.Score).HasColumnName("SCORE")

                    entity.HasOne(Function(d) d.Employee).WithMany(Function(p) p.PerformanceReviewEmployees).
                        HasForeignKey(Function(d) d.Employeeid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_PerformanceReviews_Employees")

                    entity.HasOne(Function(d) d.Reviewer).WithMany(Function(p) p.PerformanceReviewReviewers).
                        HasForeignKey(Function(d) d.Reviewerid).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK_PerformanceReviews_Employees1")
                End Sub)

            modelBuilder.Entity(Of Position)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Description).
                        HasMaxLength(500).
                        HasColumnName("DESCRIPTION")
                    entity.Property(Function(e) e.Positiontitle).
                        IsRequired().
                        HasMaxLength(100).
                        HasColumnName("POSITIONTITLE")
                    entity.Property(Function(e) e.Salarygrade).HasColumnName("SALARYGRADE")
                End Sub)

            modelBuilder.Entity(Of Salary)(
                Sub(entity)
                    entity.Property(Function(e) e.Id).HasColumnName("ID")
                    entity.Property(Function(e) e.Basesalary).
                        HasColumnType("decimal(10, 2)").
                        HasColumnName("BASESALARY")
                    entity.Property(Function(e) e.Bonus).
                        HasColumnType("decimal(10, 0)").
                        HasColumnName("BONUS")
                    entity.Property(Function(e) e.Deductions).
                        HasColumnType("decimal(10, 0)").
                        HasColumnName("DEDUCTIONS")
                    entity.Property(Function(e) e.Effectivedate).
                        HasColumnType("date").
                        HasColumnName("EFFECTIVEDATE")
                    entity.Property(Function(e) e.Employeeid).HasColumnName("EMPLOYEEID")

                    entity.HasOne(Function(d) d.Employee).WithMany(Function(p) p.Salaries).
                        HasForeignKey(Function(d) d.Employeeid).
                        HasConstraintName("FK_Salaries_Employees")
                End Sub)

            OnModelCreatingPartial(modelBuilder)
        End Sub

        Partial Private Sub OnModelCreatingPartial(modelBuilder As ModelBuilder)
        End Sub
    End Class
End Namespace
