using Giaolang.EmployeeManagement.BLL.Services;
using Giaolang.EmployeeManagement.DAL.Entities;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Giaolang.EmployeeManagement.HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeService _EmployService = new();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow d = new DetailWindow();
            d.ShowDialog();
            FillDataGridEmpoyeeDataGrid(_EmployService.GetAllEmployee());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRecord? selected = EmployeeDataGrid.SelectedItem as EmployeeRecord;

            if (selected == null)
            {
                MessageBox.Show("Please Pick An Employee To Update!!!!","Invalid Employee!!",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DetailWindow d = new();
            d.EditedOne=selected;
            d.ShowDialog();
            FillDataGridEmpoyeeDataGrid(_EmployService.GetAllEmployee());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRecord? selected = EmployeeDataGrid.SelectedItem as EmployeeRecord;

            if (selected == null)
            {
                MessageBox.Show("Please Pick An Employee To Update!!!!", "Invalid Employee!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Are You Sure Delete This Employee???", "Confirm Delete???", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;
            _EmployService.DeleteEmployee(selected);
            FillDataGridEmpoyeeDataGrid(_EmployService.GetAllEmployee());

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.ItemsSource = _EmployService.GetAllEmployee();

        }

        private void FillDataGridEmpoyeeDataGrid(List<EmployeeRecord> list)
        {
            EmployeeDataGrid.ItemsSource = null;
            EmployeeDataGrid.ItemsSource = list;
        }
    }
}