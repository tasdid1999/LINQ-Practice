namespace LinqPractice
{

    public class Program
    {
        public static void Main(String[] args)
        {

            var list = new List<Employee>()
            {
                new Employee(10,"A"),
                new Employee(20,"B"),
                new Employee(30,"C"),
                new Employee(15,"A"),
                new Employee(25,"B"),
                new Employee(3, "C"),

            };

            //AverageAgeOfEmployeeInEachComapny(list);

            // CountNumberOfEmployeeInEachCompany(list);
            OldestAgeOfEmployeeInEachCompany(list);

        }
        public static void AverageAgeOfEmployeeInEachComapny(List<Employee> list)
        {

            var result = list.GroupBy(x => x.Company)
                             .ToDictionary(grp => grp.Key, grp => Convert.ToInt32(grp.Average(emp => emp.Age)));

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

        }
        public static void CountNumberOfEmployeeInEachCompany(List<Employee> list)
        {


            var result = list.GroupBy(x => x.Company)
                             .ToDictionary(grp => grp.Key, grp => grp.Count());

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

        }
        public static void OldestAgeOfEmployeeInEachCompany(List<Employee> list)
        {


            var result = list.GroupBy(x => x.Company)
                             .ToDictionary(grp => grp.Key, grp => grp.MaxBy(emp => emp.Age));

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value.Age}");
            }

        }
        public class Employee
        {
            public int Age { get; set; }
            public string Company { get; set; }

            public Employee(int age, string company)
            {
                this.Age = age;
                this.Company = company;
            }
        }

    }



}

