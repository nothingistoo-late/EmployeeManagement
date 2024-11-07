using Giaolang.EmployeeManagement.BLL.Services;
using Giaolang.EmployeeManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Giaolang.EmployeeManagement.HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private EmployeeService _employeeService = new();

        public EmployeeRecord EditedOne { get; set; }

        public DetailWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRecord obj = new();
            if (EditedOne != null)
                obj.EmployeeId = int.Parse(EmployeeIdTextBox.Text);
            obj.EmployeeName = EmployeeNameTextBox.Text;
            obj.Salary = decimal.Parse(SalaryTextBox.Text);
            obj.HireDate = HireDateDatePicker.SelectedDate;

            if (EditedOne == null)
                _employeeService.CreateEmployee(obj);
            else
                _employeeService.UpdateEmployee(obj);
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (EditedOne != null)
            {
                EmployeeIdTextBox.Text = EditedOne.EmployeeId.ToString();
                EmployeeNameTextBox.Text = EditedOne.EmployeeName;
                SalaryTextBox.Text = EditedOne.Salary.ToString();
                HireDateDatePicker.SelectedDate = EditedOne?.HireDate;
            }
        }
    }
}
