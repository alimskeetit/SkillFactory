class Program
{
    public static void Main()
    {
        SFGroupJoin();
    }

    public static void SFGroup()
    {
        var phoneBook = new List<Contact>();

        // добавляем контакты
        phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
        phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

        var grouping = phoneBook.GroupBy(c => c.email.Contains("example"));

        foreach (var item in grouping)
        {
            Console.WriteLine(item.Key);
            foreach (var x in item)
            {
                Console.WriteLine(x.email);
            }
        }
    }

    public static void SFJoin()
    {
        var departments = new List<Department>()
        {
           new Department() {Id = 1, Name = "Программирование"},
           new Department() {Id = 2, Name = "Продажи"}
        };

        var employees = new List<Employee>()
        {
           new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
           new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
           new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
           new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
        };

        var otdels = from emp in employees
                     join dep in departments on emp.DepartmentId equals dep.Id
                     select new
                     {
                         Name = emp.Name,
                         Department = dep.Name
                     };

        foreach (var item in otdels)
            Console.WriteLine(item.Name + " " + item.Department);
        {

        }
    }

    public static void SFGroupJoin()
    {
        var departments = new List<Department>()
           {
               new Department() {Id = 1, Name = "Программирование"},
               new Department() {Id = 2, Name = "Продажи"}
           };

        var employees = new List<Employee>()
           {
               new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
               new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
               new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
               new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
           };

        var newEmps = departments.GroupJoin(employees, d => d.Id, emp => emp.DepartmentId,
            (d, emps) => new
            {
                Name = d.Name,
                Employees = emps.Select(e => e.Name)
            });


        foreach (var item in newEmps)
        {
            Console.WriteLine(item.Name + ":");
            foreach (var emp in item.Employees)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();
        }
    }

    public static void SFZip()
    {

    }
}

internal class Employee
{
    public Employee()
    {
    }

    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }
}

internal class Department
{
    public Department()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; }
}

internal class Contact
{
    public string Name;
    public long phone;
    public string email;

    public Contact(string v1, long v2, string v3)
    {
        this.Name = v1;
        this.phone = v2;
        this.email = v3;
    }
}