using ProjetElective.modification;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;



namespace ProjetElective
{
    /// <summary>
    /// Logique d'interaction pour loginPage.xaml
    /// </summary>
    public partial class loginPage : Page
    {


        public loginPage()
        {
            InitializeComponent();

        }

        private async void connectionButton_Click(object sender, RoutedEventArgs e)
        {

            String role = "4";
            if (radioButtonDev.IsChecked == true)
            {
                role = "5";
            }
            else if (radioButtonFin.IsChecked == true)
            {
                role = "4";
            }

            try
            {
                var loginResponse = await Connection.Login(emailTextBox.Text, passwordTextBox.Password, role);
                userSearchForm page = new userSearchForm();
                this.Content = new Frame() { Content = page };
            }
            catch (Exception)
            {
                LbxerrorMessage.ItemsSource = new List<ErrorMessage>
                {
                    new ErrorMessage
                    {
                        ContentMessage = "Erreur de connection"
                    }
                };
            }
 
        }
    }
}
