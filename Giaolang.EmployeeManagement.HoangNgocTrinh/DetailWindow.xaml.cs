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
            if (!checkVar())
                return;
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
            this.Close();

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

        private bool checkVar()
        {
            if (string.IsNullOrWhiteSpace(EmployeeNameTextBox.Text))
            {
                MessageBox.Show("Employee Name Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (EmployeeNameTextBox.Text.Length <5 || EmployeeNameTextBox.Text.Length > 90)
            {
                MessageBox.Show("Employee Name Must >5 and <90 !!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            TextInfo textInfor = CultureInfo.CurrentCulture.TextInfo;

            string airConName = EmployeeNameTextBox.Text.Trim();

            airConName = textInfor.ToTitleCase(airConName.ToLower());
            EmployeeNameTextBox.Text = airConName;

            if (string.IsNullOrWhiteSpace(SalaryTextBox.Text))
            {
                MessageBox.Show("Salary Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            bool convertStatus = decimal.TryParse(SalaryTextBox.Text, out decimal salary);

            if (!convertStatus)
            {
                MessageBox.Show("Salary Must Be A Number!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (salary < 0)
            {
                MessageBox.Show("Quantity Must Greater Than 0!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (HireDateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Hire Date Is Required!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
