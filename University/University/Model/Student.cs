using System.Text.Json.Serialization;

namespace University.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Class> Classes { get; set; } = [];
    }
}
