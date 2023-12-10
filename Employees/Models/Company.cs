using Newtonsoft.Json;

namespace Employees.Models
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; private set; }

        private List<Employee> _employees = new List<Employee>();
        private List<Department> _departments = new List<Department>();
      
        public Company(string name)
        {
            Name = name;
            if (!File.Exists(Constants.DEPARTMENTS_LIST_PATH))
            {
                NewDepartment("Управление по управлению всеми управлениями");
            }
            else
            {
                var departments = ReadDepartmentsData();
                _departments.AddRange(departments); 
            }
        }

        private List<Department> ReadDepartmentsData()
        {
            var serializedDepartments = File.ReadAllText(Constants.DEPARTMENTS_LIST_PATH);
            var departments = JsonConvert.DeserializeObject<List<Department>>(serializedDepartments);
            if (departments == null)
            {
                throw new Exception("Something went wrong");
            }
            return departments;
        }

        public void NewDepartment(string name)
        {
            var department = new Department(name);
            _departments.Add(department);

            var serializedDepartments = JsonConvert.SerializeObject(_departments);
            
            File.WriteAllText(Constants.DEPARTMENTS_LIST_PATH, serializedDepartments);
        }
        public Department GetDepartmentByName(string name)
        {
            return _departments.First(x => x.Name == name);
        }
        public void HireEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
        public void ListEmployees()
        {
            foreach(Employee e in _employees)
            {
                Console.WriteLine(e.Name);
            }
        }
    }
}
