using Employees.Models;

namespace Employees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var company = new Company("ФСБЭ");
            var uwuDept = new Department("Управление по управлению всеми управлениями");
            Employee muslim = new Employee("Муслим", 24, uwuDept);
            Employee khamzat = new Employee("Хьамзат", 35, uwuDept);

            company.HireEmployee(muslim);
            company.HireEmployee(khamzat);
            company.ListEmployees();

        }
    }
}
