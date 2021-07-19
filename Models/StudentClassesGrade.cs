using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mog.Models
{
    public class StudentClassesGrade
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassId { get; set; }
        public Classes Class { get; set; }
    }
}