using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_repaso
{
    public partial class Form1 : Form
    {
        List<Employee> employees = new List<Employee>();
        string reportFiles = "Report.txt";
        string employeeFiles = "Employee.txt";
        string salaryFiles = "Salary.txt";
        public Form1()
        {
            InitializeComponent();
            textEmployee.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        // A method is created to be able to store only the user's information
        public void writeEmployee()
        {
            List<Dictionary<string, string>> Employee = new List<Dictionary<string, string>>();
            foreach (var employee in employees)
            {
                var employeeTemp = new Dictionary<string, string>();
                employeeTemp.Add("ID", employee.NoEmployee.ToString());
                employeeTemp.Add("name", employee.Name);
                employeeTemp.Add("salary", employee.Salary.ToString());
                Employee.Add(employeeTemp);
            }
            string json = JsonConvert.SerializeObject(Employee);
            using (StreamWriter sr = new StreamWriter(employeeFiles))
            {
                sr.Write(json);
            }
        }
        // A method is created to be able to store only the hours worked of the user
        public void writeSalary()
        {
            List<Dictionary<string, string>> salaries = new List<Dictionary<string, string>>();
            foreach (var employee in employees)
            {
                var salaryTemp = new Dictionary<string, string>();
                salaryTemp.Add("ID", employee.NoEmployee.ToString());
                salaryTemp.Add("hoursMonth", employee.HourMonth.ToString());
                salaryTemp.Add("month", employee.Month);
                salaries.Add(salaryTemp);
            }
            string json = JsonConvert.SerializeObject(salaries);
            using (StreamWriter sr = new StreamWriter(salaryFiles))
            {
                sr.Write(json);
            }
        }
        // A text file of the complete reports is created
        public void filesReport ()
        {
            if(File.Exists(reportFiles))
            {
                File.Delete(reportFiles);
            }
            StreamWriter writer = new StreamWriter(reportFiles);
            string json = JsonConvert.SerializeObject(employees);
            writer.Write(json);
            writer.Close();
        }
        public void readReport()
        {
            if (File.Exists(reportFiles))
            {
                StreamReader read = new StreamReader(reportFiles);
                employees = JsonConvert.DeserializeObject<List<Employee>>(read.ReadToEnd());
                read.Close();
            }
            else
            {
                this.employees = new List<Employee>();
            }
        }

        private void showData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = employees;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //==================== ADD EMPLOYEEE =======================
            Employee employeeTemp = new Employee();
            employeeTemp.NoEmployee = int.Parse(textEmployee.Text); 
            employeeTemp.Name = textName.Text;
            employeeTemp.Salary = double.Parse(textSalary.Text);
            employeeTemp.HourMonth = int.Parse(textWorked.Text);
            employeeTemp.Month = textMonth.Text;
            employeeTemp.calculateSalary();
            employees.Add(employeeTemp);
            //Add employee in combobox
            comboBox1.Items.Add(employeeTemp.NoEmployee);
            // The text file functions are called
            this.filesReport();
            this.writeEmployee();
            this.writeSalary();
            //==========================================================
            textEmployee.Text = "";
            textName.Text = "";
            textSalary.Text = "";
            textWorked.Text = "";
            textMonth.Text = "";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var employee in employees)
            {
                if(employee.NoEmployee == int.Parse(comboBox1.SelectedItem.ToString()))
                {
                    labelNo.Text = "No. employee:\t" + employee.NoEmployee.ToString();
                    labelName.Text = "Name employee:\t" + employee.Name;
                    labelSalary.Text = "Total salary:\t" + employee.totalSalary.ToString();
                }
            }
        }
    }
}