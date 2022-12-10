namespace MVCRazorValidation.Models
{
    public class User
    {
        public string Name { get; set; }
        public string? Family { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ShabaNumber { get; set; }
        public Address Address { get; set; }
        public List<Course> Courses { get; set; }
    }

    public class Address
    {
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
    }

    public class Course
    {
        public string CourseName { get; set; }
        public int Score { get; set; }
    }
}
