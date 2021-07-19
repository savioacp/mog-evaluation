using Microsoft.EntityFrameworkCore;
using mog.Models;

namespace mog.Services
{
    public class MogContext : DbContext
    {
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClassesGrade> Grades { get; set; }

        public MogContext(DbContextOptions<MogContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                #region "Mock Data"
                Students.AddRange(new[]
                {
                    new Student {
                        Name = "Sávio",
                        Age = 16
                    },
                    new Student {
                        Name = "Juliana",
                        Age = 17
                    },
                    new Student {
                        Name = "Alberto",
                        Age = 18
                    },
                });

                Classes.AddRange(new[]
                {
                    new Classes {
                        Name = "Matemática",
                        Description = "A Matemática é a ciência que relaciona as práticas do cotidiano e a natureza ao raciocínio humano e à lógica numérica.",
                        TeacherName = "Márcia Xavier"
                    },
                    new Classes {
                        Name = "Física",
                        Description = "Física é a ciência que estuda a natureza e seus fenômenos em seus aspectos gerais. Analisa suas relações e propriedades, além de descrever e explicar a maior parte de suas consequências.",
                        TeacherName = "Enrique Chiquinho"
                    }
                });

                Grades.AddRange(new[]
                {
                    // Sávio: 
                    //   10 em matemática
                    new StudentClassesGrade {
                        StudentId = 1,
                        ClassId = 1,
                        Grade = 10,
                    },
                    //   8 em física
                    new StudentClassesGrade {
                        StudentId = 1,
                        ClassId = 2,
                        Grade = 8,
                    },
                    // Juliana:
                    //   10 em matemática
                    new StudentClassesGrade {
                        StudentId = 2,
                        ClassId = 1,
                        Grade = 10,
                    },
                    //   9 em física
                    new StudentClassesGrade {
                        StudentId = 2,
                        ClassId = 2,
                        Grade = 9,
                    },
                    // Alberto:
                    //   7 em matemática
                    new StudentClassesGrade {
                        StudentId = 3,
                        ClassId = 1,
                        Grade = 7,
                    },
                    //   6 em física
                    new StudentClassesGrade {
                        StudentId = 3,
                        ClassId = 2,
                        Grade = 6,
                    },
                });

                SaveChanges();
                #endregion
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Classes>()
                .ToTable("Classes");

            builder.Entity<Student>()
                .ToTable("Student");

            builder.Entity<StudentClassesGrade>()
                .HasOne(g => g.Class)
                .WithMany(c => c.Grades)
                .IsRequired();

            builder.Entity<StudentClassesGrade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .IsRequired();

            builder.Entity<StudentClassesGrade>()
                .ToTable("StudentClassesGrade");
        }
    }
}