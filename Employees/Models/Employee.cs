namespace Employees.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Name { get;}
        public JobTitles JobTitle { get; set; }
        public Department Department { get; set; }
        public int Age { get; private set; }

        
        public Employee (string name, int age, Department department)
        {
            Name = name;
            Age = age;
            JobTitle = JobTitles.Intern;
            Department = department;
        }
    }
}
