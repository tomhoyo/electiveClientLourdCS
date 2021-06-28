using Newtonsoft.Json.Linq;
using ProjetElective.Modification;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour userSearchForm.xaml
    /// </summary>
    public partial class userSearchForm : Page
    {
        String role;

        public userSearchForm()
        {
            InitializeComponent();
        }

        private void loginPage(object sender, RoutedEventArgs e)
        {
            loginPage page = new loginPage();
            this.Content = new Frame() { Content = page };
        }

        private async void rechercheClick_ButtonAsync(object sender, RoutedEventArgs e)
        {
            
            switch (roleComboBox.Text)
            {
                case "Client":
                    role = "1";
                    break;
                case "Restaurant":
                    role = "2";
                    break;
                case "Livreur":
                    role = "3";
                    break;
                case "Commercial":
                    role = "4";
                    break;
                case "Technicien":
                    role = "5";
                    break;
                default:
                    Console.WriteLine("default Case");
                    role = "1";
                    break;
            }

            var userListResponse = await Connection.SearchUsers(role, idTextBox.Text, emailTextBox.Text, NameTextBox.Text, firstnameTextBox.Text, lastnameTextBox.Text);


            String userDataStringJson = await userListResponse.Content.ReadAsStringAsync();
            JArray UserListjson = JArray.Parse(userDataStringJson);
            Console.WriteLine(UserListjson);
            List<User> listUser = new List<User>();

            foreach (JObject json in UserListjson)
            {
                listUser.Add(new User(
                    role,
                    (String)json["id"],
                    (String)json["email"], 
                    (String)json["name"], 
                    (String)json["firstname"], 
                    (String)json["lastname"], 
                    (String)json["address"], 
                    (String)json["iban"]));
            }
            LbxUserList.ItemsSource = listUser;

        }


        private void modifyUserButton_Click(object sender, RoutedEventArgs e)
        {


            User user = (User)((Button)e.Source).DataContext;

            Page page;
            switch (role)
            {
                case "1":
                    page = new customerModification(user.id, user.firstname, user.lastname, user.email, user.address);
                    break;
                case "2":

                    page = new restaurantModification(user.id, user.name, user.address, user.email);
                    break;
                case "3":

                    page = new deliverymanModification(user.id, user.firstname, user.lastname, user.email, user.iban);
                    break;
                case "4":

                    page = new salepersonModification(user.id, user.firstname, user.lastname, user.email);
                    break;
                case "5":

                    page = new developperModification(user.id, user.firstname, user.lastname, user.email);
                    break;
                default:
                    page = new customerModification(user.id, user.firstname, user.lastname, user.email, user.address);
                    break;
            }


            this.Content = new Frame() { Content = page };



        }
    }
}
