namespace WebApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public ICollection<Group> Groups { get; set; } = null!;
    }
}
