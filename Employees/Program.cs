using Employees.Models;
using Newtonsoft.Json;

namespace Employees
{
    internal class Program
    {
    
        static void Main(string[] args)
        {
            // Создаем или считываем информацию о компании
            Company company;
            if (File.Exists(Constants.COMPANY_PATH))
            {
                try
                {
                    company = GetSavedCompanyInfo();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else
            {
                company = CreateNewCompany("ФСБЭ");
            }

            var defaultDepartment = company.GetDepartmentByName("Управление по управлению всеми управлениями");

            Employee muslim = new Employee("Муслим", 24, defaultDepartment);
            Employee khamzat = new Employee("Хьамзат", 35, defaultDepartment);

            company.HireEmployee(muslim);
            company.HireEmployee(khamzat);
            company.ListEmployees();

        }

        static Company CreateNewCompany(string name)
        {
            var company = new Company(name);
            var serializedCompany = JsonConvert.SerializeObject(company);
            File.WriteAllText(Constants.COMPANY_PATH, serializedCompany);

            return company;
        }
        private static Company GetSavedCompanyInfo()
        {
            var serializedCompany = File.ReadAllText(Constants.COMPANY_PATH);
            var company = JsonConvert.DeserializeObject<Company>(serializedCompany);
            if (company == null)
            {
                throw new Exception("Ошибка при считывании данных о компании");
            }

            return company;
        }


    }
}
