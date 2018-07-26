using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BANKINGSA.Models
{
    class BankingUserManager
    {
        const string Url = "http://banking-ucenfotec-api.azurewebsites.net/api/v1/"; // URL del Servicio RESTful
        private string _authorizationKey; // Esta aplicación utiliza un método de autenticación por llave.

        /*
         * Inicializa el objeto HttpClient con los valores por defecto para poder realizar la autenticación del servicio
         * y envíandolo dentro del Header del HTTPMessageRequest.
         */
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            if (string.IsNullOrEmpty(_authorizationKey))
            {
                _authorizationKey = await client.GetStringAsync(Url + "login");
                _authorizationKey = _authorizationKey.Trim('"');
            }

            client.DefaultRequestHeaders.Add("Authorization", _authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<Banking_User> Add(User_Model _User)
        {
            try
            {
                // TODO: use POST to add a book

                HttpClient client = new HttpClient();
                var response = await client.PostAsJsonAsync(Url + "/Auth/Register", _User);
                /*var response = await client.PostAsync(Url+"/Auth/Register",
                    new StringContent(
                        JsonConvert.SerializeObject(_User),
                        Encoding.UTF8, "application/json"));*/

                return JsonConvert.DeserializeObject<Banking_User>(
                    await response.Content.ReadAsStringAsync());
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Banking_User> Login(string User, string Pass)
        {
            // TODO: use POST to add a book
            Banking_User _User = new Banking_User
            {
                Email = User,
                Password = Pass
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(Url + "/Auth/Login/",
                new StringContent(
                    JsonConvert.SerializeObject(_User),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Banking_User>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
