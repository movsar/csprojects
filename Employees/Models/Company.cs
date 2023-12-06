namespace Employees.Models
{
    internal class Company
    {
        public List<Employee> Employees { get; }
        public string Name { get; private set; }
        public void HireEmployee (Employee employee)
        {
            Employees.Add(employee);
        }
        public Company(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }
        public void ListEmployees()
        {
            foreach(Employee e in Employees)
            {
                Console.WriteLine(e.Name);
            }
        }
    }
}
