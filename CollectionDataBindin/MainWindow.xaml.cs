using System.Collections.ObjectModel;
using System.ComponentModel;
using ChangeNotificationSample;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CollectionDataBinding
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            DataContext = users;
        }
        private void LoadUsers()
        {
            users = new ObservableCollection<User>();
            users.Add(new User() { Name = "Gloria Trevi" });
            users.Add(new User() { Name = "Potacsio" });
            users.Add(new User() { Name = "Muy bueno con arroz blanco" });

            usersListBox.ItemsSource = users;

            //usersListBox.ItemsSource = users;
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(userTextBox.Text))
            {
                User user = new User() { Name = "Nuevo usuario" };
                users.Add(user);
                usersListBox.SelectedItem = user;
                UpdateView();
            }
        }

        private void changeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                User user = usersListBox.SelectedItem as User;
                user.Name = userTextBox.Text;
                usersListBox.SelectedItem = user;
                UpdateView();
            }
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                users.Remove(usersListBox.SelectedItem as User);
                //userTextBox.Text = ""; 
                UpdateView();
            }
        }
        private void UpdateView()
        {
            usersListBox.Items.Refresh();
            if (users.Count > 0)
            {
                deleteUserButton.IsEnabled = true;
                changeUserButton.IsEnabled = true;
            }
            else
            {
                usersListBox.SelectedIndex = -1;
                deleteUserButton.IsEnabled = false;
                changeUserButton.IsEnabled = false;
            }

        }
    }
}