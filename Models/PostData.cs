namespace PostApiDemo
{
    public class PostData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime AddedAt { get; set; }
        public string CourseName { get; set; }

        // Constructor to easily create new instances
        public PostData(string name, string email, DateTime addedAt, string courseName)
        {
            Name = name;
            Email = email;
            AddedAt = addedAt;
            CourseName = courseName;
        }
    }
}
