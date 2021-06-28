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

namespace ProjetElective.modification
{
    /// <summary>
    /// Logique d'interaction pour developperModification.xaml
    /// </summary>
    public partial class developperModification : Page
    {
        User user;
        public developperModification(String id, String firstname, String lastname, String email)
        {
            InitializeComponent();

            user = new User("5", id, email, "", firstname, lastname, "", "");
            LbxUser.ItemsSource = new List<User>
            {
                user
            };
        }


        private async void SupprButton_Click(object sender, RoutedEventArgs e)
        {
            await Connection.DeleteAccount(user.role, user.id);

            userSearchForm page = new userSearchForm();
            this.Content = new Frame() { Content = page };
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            user = new User(user.role, user.id, emailTextBox.Text, user.name, fistnameTextBox.Text, lastnameTextBox.Text, user.address, user.iban);
            await Connection.ModifyAccount(user);

            developperModification page = new developperModification(user.id, user.firstname, user.lastname, user.email);
            this.Content = new Frame() { Content = page };
        }

        private void homePage(object sender, RoutedEventArgs e)
        {
            userSearchForm page = new userSearchForm();
            this.Content = new Frame() { Content = page };
        }
    }
}
