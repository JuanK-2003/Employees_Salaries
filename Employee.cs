using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_repaso
{
    class Employee
    {
        int noEmployee;
        string name;
        double salary;
        int hourMonth;
        string month;
        public double totalSalary { get; set; }

        public Employee(int noEmployee, string name, double salary, int hourMonth, string month)
        {
            this.noEmployee = noEmployee;
            this.name = name;
            this.salary = salary;
            this.hourMonth = hourMonth;
            this.month = month;
            this.totalSalary = salary * hourMonth;
        }
        public Employee()
        {

        }
        public void calculateSalary()
        {
            this.totalSalary = this.salary * this.hourMonth;
        }
        public int NoEmployee { get => noEmployee; set => noEmployee = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }
        public int HourMonth { get => hourMonth; set => hourMonth = value; }
        public string Month { get => month; set => month = value; }
    }
}
