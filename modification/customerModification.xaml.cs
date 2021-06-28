using ProjetElective.modification;
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

namespace ProjetElective
{
    /// <summary>
    /// Logique d'interaction pour customerModification.xaml
    /// </summary>
    public partial class customerModification : Page
    {
        User user;
        public customerModification(String id, String firstname, String lastname, String email, String address)
        {
            InitializeComponent();

            user = new User("1", id, email, "", firstname, lastname, address, "");
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
            user = new User(user.role, user.id, emailTextBox.Text, user.name, fistnameTextBox.Text, lastnameTextBox.Text, addressTextBox.Text, user.iban);
            await Connection.ModifyAccount(user);

            customerModification page = new customerModification(user.id, user.firstname, user.lastname, user.email, user.address);
            this.Content = new Frame() { Content = page };
        }

        private void homePage(object sender, RoutedEventArgs e)
        {
            userSearchForm page = new userSearchForm();
            this.Content = new Frame() { Content = page };
        }
    }
}
