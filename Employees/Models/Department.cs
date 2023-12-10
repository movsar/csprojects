namespace Employees.Models
{
    public class Department
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; private set; }
        public Department(string name)
        {
            Name = name;
        }
        
    }
}
