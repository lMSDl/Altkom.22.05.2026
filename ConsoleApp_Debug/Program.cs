using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; } = string.Empty;
    public int HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }
}

class Program
{
    static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "Anna", HoursWorked = 160, HourlyRate = 50 },
            new Employee { Name = "Tom", HoursWorked = 120, HourlyRate = 40 },
            new Employee { Name = "Kate", HoursWorked = 100, HourlyRate = 60 }
        };

        decimal totalPayroll = CalculatePayroll(employees);
        Console.WriteLine($"Total payroll: {totalPayroll}");

        var highestPaid = FindHighestPaidEmployee(employees);
        if (highestPaid != null)
        {
            Console.WriteLine($"Highest paid employee: {highestPaid.Name}");
        }
        else
        {
            Console.WriteLine("No employees available.");
        }

        PrintEmployee(employees, 0);
    }

    static decimal CalculatePayroll(IReadOnlyList<Employee> employees)
    {
        decimal total = 0;

        foreach (var employee in employees)
        {
            total += employee.HoursWorked * employee.HourlyRate;
        }

        return total;
    }

    static Employee? FindHighestPaidEmployee(IReadOnlyList<Employee> employees)
    {
        Employee? highestPaid = null;

        foreach (var employee in employees)
        {
            if (highestPaid == null ||
                employee.HoursWorked * employee.HourlyRate > highestPaid.HoursWorked * highestPaid.HourlyRate)
            {
                highestPaid = employee;
            }
        }

        return highestPaid;
    }

    static void PrintEmployee(IReadOnlyList<Employee> employees, int index)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees available.");
            return;
        }
        if (index < 0 || index >= employees.Count)
        {
            Console.WriteLine($"Invalid index: {index}. Must be between 0 and {employees.Count - 1}.");
            return;
        }
        Console.WriteLine($"Employee: {employees[index].Name}");
    }
}