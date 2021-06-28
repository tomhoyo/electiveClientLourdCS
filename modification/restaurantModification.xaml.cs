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
    /// Logique d'interaction pour restaurantModification.xaml
    /// </summary>
    public partial class restaurantModification : Page
    {
        User user;
        public restaurantModification(String id, String name, String address, String email)
        {
            InitializeComponent();

            user = new User("2", id, email, name, "", "", address, "");
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
            user = new User(user.role, user.id, emailTextBox.Text, nameTextBox.Text, user.firstname, user.lastname, addressTextBox.Text, user.iban);
            await Connection.ModifyAccount(user);

            restaurantModification page = new restaurantModification(user.id, user.name, user.address, user.email);
            this.Content = new Frame() { Content = page };
        }
        private void homePage(object sender, RoutedEventArgs e)
        {
            userSearchForm page = new userSearchForm();
            this.Content = new Frame() { Content = page };
        }
    }
}
