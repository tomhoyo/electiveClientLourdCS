using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjetElective
{
    static class Connection
    {

        private static string apiURL = "http://localhost:3000";

        public async static Task<HttpResponseMessage> Login(String email, String password, String userRole)
        {
            using (HttpClient client = new HttpClient())
            {
                String myJson = JsonConvert.SerializeObject(new
                {
                    email = email,
                    password = password
                });

                HttpResponseMessage response = null;
                try
                {
                    response = await client.PostAsync(apiURL + "/User/login/" + userRole, new StringContent(myJson, Encoding.UTF8, "application/json"));
                }
                catch (Exception e)
                {

                }
                
                return response;
            }
        }

        public async static Task<HttpResponseMessage> SearchUsers(String role, String id, String email, String name, String firstname, String lastname)
        {

            using (HttpClient client = new HttpClient())
            {
                String myJson = JsonConvert.SerializeObject(new
                {
                    id = id,
                    email = email,
                    name = name,
                    firstname = firstname,
                    lastname = lastname
                });

                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync(apiURL + "/user/" + role);
                }
                catch (Exception e)
                {

                }

                return response;
            }
        }

        public async static Task<HttpResponseMessage> DeleteAccount(String role, String id)
        {

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = null;
                try
                {
                    response = await client.DeleteAsync(apiURL + "/User/" + role + "/" + id);
                }
                catch (Exception e)
                {

                }

                return response;
            }
        }

        public async static Task<HttpResponseMessage> ModifyAccount(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                String myJson = JsonConvert.SerializeObject(new
                {
                    id = user.id,
                    email = user.email,
                    name = user.name,
                    firstname = user.firstname,
                    lastname = user.lastname,
                    address = user.address,
                    iban = user.iban
                });

                HttpResponseMessage response = null;
                try
                {
                    response = await client.PutAsync(apiURL + "/User/" + user.role + "/" + user.id, new StringContent(myJson, Encoding.UTF8, "application/json"));
                }
                catch (Exception e)
                {

                }

                return response;
            }
        }
    }
}
