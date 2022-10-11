class Emp
    {
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Desgination { get; set; }

    }

    class Employee
    {
        public static List<Emp> Employees { get; set; }
        public Employee()
        {
            Employees = new List<Emp>();

            var Ganesh = new Emp() { EmpId = Guid.NewGuid().ToString(), Name = "Ganesh", Desgination = "Lead" };
            var Kumar = new Emp() { EmpId = Guid.NewGuid().ToString(), Name = "Kumar", Desgination = "Tester" };
            Employees.Add(Ganesh);
            Employees.Add(Kumar);

        }

        public Emp AddEmployee(string name, string desgination)
        {
            var employee = new Emp() { EmpId = Guid.NewGuid().ToString(), Name = name, Desgination = desgination };
            Employees.Add(employee);

            return employee;
        }

        public bool DeleteEmployee(string empid)
        {
            try
            {
                var employee = Employees.Where(s => s.EmpId == empid).FirstOrDefault();

                if (employee == null) return false;

                Employees.Remove(employee);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Emp GetEmployee(string empid)
        {
            return Employees.Where(s => s.EmpId == empid).FirstOrDefault();
        }

        public List<Emp> ListEmployees()
        {
            return Employees;
        }

    }

    class Program
    {
        static Employee Employee { get; set; }
        static void Main(string[] args)
        {
            try
            {
                Employee = new Employee();

                List<Emp> employeeList = Employee.ListEmployees();

                if (employeeList == null) throw new Exception();

                Console.WriteLine("Students:");
                foreach (Emp employee in employeeList)
                {
                    Console.WriteLine("Id: " + employee.EmpId + ", Name: " + employee.Name + ", Desgination: " + employee.Desgination);
                }
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unrecognized command. Please try again.");
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }



    }
