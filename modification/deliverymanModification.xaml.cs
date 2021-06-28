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

namespace ProjetElective.Modification
{
    /// <summary>
    /// Logique d'interaction pour deliverymanModifiaction.xaml
    /// </summary>
    public partial class deliverymanModification : Page
    {

        User user;
        public deliverymanModification(String id, String firstname, String lastname, String email, String iban)
        {
            InitializeComponent();

            user = new User("3", id, email, "", firstname, lastname, "", iban);
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
            user = new User(user.role, user.id, emailTextBox.Text, user.name, fistnameTextBox.Text, lastnameTextBox.Text, user.address, ibanTextBox.Text);
            await Connection.ModifyAccount(user);

            deliverymanModification page = new deliverymanModification(user.id, user.firstname, user.lastname, user.email, user.iban);
            this.Content = new Frame() { Content = page };
        }

        private void homePage(object sender, RoutedEventArgs e)
        {
            userSearchForm page = new userSearchForm();
            this.Content = new Frame() { Content = page };
        }
    }
}
