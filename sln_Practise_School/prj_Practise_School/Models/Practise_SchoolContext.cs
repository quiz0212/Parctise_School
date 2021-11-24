using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class Practise_SchoolContext : DbContext
    {
        public Practise_SchoolContext()
        {
        }

        public Practise_SchoolContext(DbContextOptions<Practise_SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAbsent> TAbsents { get; set; }
        public virtual DbSet<TClass> TClasses { get; set; }
        public virtual DbSet<TClassMember> TClassMembers { get; set; }
        public virtual DbSet<TDepartment> TDepartments { get; set; }
        public virtual DbSet<TJobTitleIdToJobTitleName> TJobTitleIdToJobTitleNames { get; set; }
        public virtual DbSet<TLesonTime> TLesonTimes { get; set; }
        public virtual DbSet<TScore> TScores { get; set; }
        public virtual DbSet<TSemesterSubject> TSemesterSubjects { get; set; }
        public virtual DbSet<TSemesterSubjectTime> TSemesterSubjectTimes { get; set; }
        public virtual DbSet<TStudentSubject> TStudentSubjects { get; set; }
        public virtual DbSet<TSubject> TSubjects { get; set; }
        public virtual DbSet<TTeacherDept> TTeacherDepts { get; set; }
        public virtual DbSet<TUser> TUsers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=CSS1230V2W10;Initial Catalog=Practise_School;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<TAbsent>(entity =>
            {
                entity.HasKey(e => e.FIdIdentity);

                entity.ToTable("tAbsent");

                entity.HasIndex(e => new { e.FUserId, e.FStatus, e.FDay, e.FLesonTimeId }, "UK_tAbsent")
                    .IsUnique();

                entity.Property(e => e.FIdIdentity).HasColumnName("fId_Identity");

                entity.Property(e => e.FDay)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fDay")
                    .IsFixedLength(true);

                entity.Property(e => e.FLesonTimeId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fLesonTimeID")
                    .IsFixedLength(true);

                entity.Property(e => e.FSemesterSubjectId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fSemesterSubjectID")
                    .IsFixedLength(true);

                entity.Property(e => e.FStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fStatus")
                    .IsFixedLength(true);

                entity.Property(e => e.FUserId)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("fUserId")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FUser)
                    .WithMany(p => p.TAbsents)
                    .HasForeignKey(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAbsent_tUser");
            });

            modelBuilder.Entity<TClass>(entity =>
            {
                entity.HasKey(e => e.FClassId);

                entity.ToTable("tClass");

                entity.Property(e => e.FClassId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("fClassID")
                    .IsFixedLength(true);

                entity.Property(e => e.FDeptId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fDeptID")
                    .IsFixedLength(true);

                entity.Property(e => e.FSchoolYear).HasColumnName("fSchoolYear");

                entity.HasOne(d => d.FDept)
                    .WithMany(p => p.TClasses)
                    .HasForeignKey(d => d.FDeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tClass_tDepartment");
            });

            modelBuilder.Entity<TClassMember>(entity =>
            {
                entity.HasKey(e => e.FUserId)
                    .HasName("PK_tClassMember_1");

                entity.ToTable("tClassMember");

                entity.HasIndex(e => new { e.FUserId, e.FClassId }, "UK_tClassMember")
                    .IsUnique();

                entity.Property(e => e.FUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("fUserId")
                    .IsFixedLength(true);

                entity.Property(e => e.FClassId)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("fClassID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FClass)
                    .WithMany(p => p.TClassMembers)
                    .HasForeignKey(d => d.FClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tClassMember_tClass");

                entity.HasOne(d => d.FUser)
                    .WithOne(p => p.TClassMember)
                    .HasForeignKey<TClassMember>(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tClassMember_tUser");
            });

            modelBuilder.Entity<TDepartment>(entity =>
            {
                entity.HasKey(e => e.FDeptId);

                entity.ToTable("tDepartment");

                entity.Property(e => e.FDeptId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fDeptID")
                    .IsFixedLength(true);

                entity.Property(e => e.FDeptName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fDeptName");
            });

            modelBuilder.Entity<TJobTitleIdToJobTitleName>(entity =>
            {
                entity.HasKey(e => e.FJobTitleId);

                entity.ToTable("tJobTitleID_to_JobTitleName");

                entity.Property(e => e.FJobTitleId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fJobTitleID")
                    .IsFixedLength(true);

                entity.Property(e => e.FJobTitleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fJobTitleName");
            });

            modelBuilder.Entity<TLesonTime>(entity =>
            {
                entity.HasKey(e => e.FLesonTimeId);

                entity.ToTable("tLesonTime");

                entity.Property(e => e.FLesonTimeId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fLesonTimeID")
                    .IsFixedLength(true);

                entity.Property(e => e.FEndTime)
                    .HasColumnType("time(0)")
                    .HasColumnName("fEndTime");

                entity.Property(e => e.FStarTime)
                    .HasColumnType("time(0)")
                    .HasColumnName("fStarTime");
            });

            modelBuilder.Entity<TScore>(entity =>
            {
                entity.HasKey(e => e.FIdIdentity);

                entity.ToTable("tScore");

                entity.HasIndex(e => new { e.FUserId, e.FSemesterSubjectId }, "UK_tScore")
                    .IsUnique();

                entity.Property(e => e.FIdIdentity).HasColumnName("fId_Identity");

                entity.Property(e => e.FScore).HasColumnName("fScore");

                entity.Property(e => e.FSemesterSubjectId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fSemesterSubjectID")
                    .IsFixedLength(true);

                entity.Property(e => e.FUserId)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("fUserId")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FSemesterSubject)
                    .WithMany(p => p.TScores)
                    .HasForeignKey(d => d.FSemesterSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tScore_tSemesterSubject");

                entity.HasOne(d => d.FUser)
                    .WithMany(p => p.TScores)
                    .HasForeignKey(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tScore_tUser");
            });

            modelBuilder.Entity<TSemesterSubject>(entity =>
            {
                entity.HasKey(e => e.FSemesterSubjectId);

                entity.ToTable("tSemesterSubject");

                entity.Property(e => e.FSemesterSubjectId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fSemesterSubjectID")
                    .IsFixedLength(true);

                entity.Property(e => e.FClassRoom)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("fClassRoom")
                    .IsFixedLength(true);

                entity.Property(e => e.FNumberOfStudent).HasColumnName("fNumberOfStudent");

                entity.Property(e => e.FSchoolYear).HasColumnName("fSchoolYear");

                entity.Property(e => e.FSemester)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fSemester")
                    .IsFixedLength(true);

                entity.Property(e => e.FSubjectId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("fSubjectId")
                    .IsFixedLength(true);

                entity.Property(e => e.FUserId)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("fUserId")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FSubject)
                    .WithMany(p => p.TSemesterSubjects)
                    .HasForeignKey(d => d.FSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSemesterSubject_tSubject");

                entity.HasOne(d => d.FUser)
                    .WithMany(p => p.TSemesterSubjects)
                    .HasForeignKey(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSemesterSubject_tUser");
            });

            modelBuilder.Entity<TSemesterSubjectTime>(entity =>
            {
                entity.HasKey(e => e.FIdIdentity);

                entity.ToTable("tSemesterSubjectTime");

                entity.HasIndex(e => new { e.FSemesterSubjectId, e.FLesonTimeId, e.FDay }, "UK_tSemesterSubjectTime")
                    .IsUnique();

                entity.Property(e => e.FIdIdentity).HasColumnName("fId_Identity");

                entity.Property(e => e.FDay)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fDay")
                    .IsFixedLength(true);

                entity.Property(e => e.FLesonTimeId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fLesonTimeID")
                    .IsFixedLength(true);

                entity.Property(e => e.FSemesterSubjectId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fSemesterSubjectID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FLesonTime)
                    .WithMany(p => p.TSemesterSubjectTimes)
                    .HasForeignKey(d => d.FLesonTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSemesterSubjectTime_tLesonTime");

                entity.HasOne(d => d.FSemesterSubject)
                    .WithMany(p => p.TSemesterSubjectTimes)
                    .HasForeignKey(d => d.FSemesterSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSemesterSubjectTime_tSemesterSubject");
            });

            modelBuilder.Entity<TStudentSubject>(entity =>
            {
                entity.HasKey(e => e.FIdIdentity);

                entity.ToTable("tStudentSubject");

                entity.HasIndex(e => new { e.FUserId, e.FSemesterSubjectId }, "UK_tStudentSubject")
                    .IsUnique();

                entity.Property(e => e.FIdIdentity).HasColumnName("fId_Identity");

                entity.Property(e => e.FSemesterSubjectId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fSemesterSubjectID")
                    .IsFixedLength(true);

                entity.Property(e => e.FUserId)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("fUserId")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FSemesterSubject)
                    .WithMany(p => p.TStudentSubjects)
                    .HasForeignKey(d => d.FSemesterSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tStudentSubject_tSemesterSubject");

                entity.HasOne(d => d.FUser)
                    .WithMany(p => p.TStudentSubjects)
                    .HasForeignKey(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tStudentSubject_tUser");
            });

            modelBuilder.Entity<TSubject>(entity =>
            {
                entity.HasKey(e => e.FSubjectId);

                entity.ToTable("tSubject");

                entity.Property(e => e.FSubjectId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("fSubjectId")
                    .IsFixedLength(true);

                entity.Property(e => e.FCredits).HasColumnName("fCredits");

                entity.Property(e => e.FSubjectName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fSubjectName");
            });

            modelBuilder.Entity<TTeacherDept>(entity =>
            {
                entity.HasKey(e => e.FUserId);

                entity.ToTable("tTeacherDept");

                entity.Property(e => e.FUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("fUserId")
                    .IsFixedLength(true);

                entity.Property(e => e.FDeptId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fDeptID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FDept)
                    .WithMany(p => p.TTeacherDepts)
                    .HasForeignKey(d => d.FDeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tTeacherDept_tDepartment");

                entity.HasOne(d => d.FUser)
                    .WithOne(p => p.TTeacherDept)
                    .HasForeignKey<TTeacherDept>(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tTeacherDept_tUser");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.FUserId);

                entity.ToTable("tUser");

                entity.Property(e => e.FUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("fUserID")
                    .IsFixedLength(true);

                entity.Property(e => e.FAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FBirthday)
                    .HasColumnType("date")
                    .HasColumnName("fBirthday");

                entity.Property(e => e.FEmail)
                    .IsRequired()
                    .HasMaxLength(320)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FGender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fGender")
                    .IsFixedLength(true);

                entity.Property(e => e.FImage)
                    .HasMaxLength(30)
                    .HasColumnName("fImage");

                entity.Property(e => e.FJobTitleId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fJobTitleID")
                    .IsFixedLength(true);

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fName");

                entity.Property(e => e.FPassword)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fPhone")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FJobTitle)
                    .WithMany(p => p.TUsers)
                    .HasForeignKey(d => d.FJobTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tUser_tJobTitleID_to_JobTitleName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
