using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace mog.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public ICollection<StudentClassesGrade> Grades { get; set; }
    }
}