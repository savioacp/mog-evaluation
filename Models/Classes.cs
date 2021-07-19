using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace mog.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TeacherName { get; set; }

        [JsonIgnore]
        public ICollection<StudentClassesGrade> Grades { get; set; }
    }
}