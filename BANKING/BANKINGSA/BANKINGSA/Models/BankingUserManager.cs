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

        public async Task<Banking_User> Add(User_Model _User)
        {
            try
            {
                // TODO: use POST to add a book
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(Url + "auth/register",
                    new StringContent(
                        JsonConvert.SerializeObject(_User),
                        Encoding.UTF8, "application/json"));

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
            try
            {
                // TODO: use POST to add a book
                Banking_User _User = new Banking_User
                {
                    Email = User,
                    Password = Pass
                };

                HttpClient client = new HttpClient();
                var response = await client.PostAsync(Url + "auth/login/",
                    new StringContent(
                        JsonConvert.SerializeObject(_User),
                        Encoding.UTF8, "application/json"));

                return JsonConvert.DeserializeObject<Banking_User>(
                    await response.Content.ReadAsStringAsync());
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Banking_BankAccount>> GetAllAccounts()
        {
            // TODO: use GET to retrieve books
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(Url+ "BankAccount");
            return JsonConvert.DeserializeObject<IEnumerable<Banking_BankAccount>>(result);
        }

        public async Task<IEnumerable<Banking_Transfer>> GetAllTransfers()
        {
            // TODO: use GET to retrieve books
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(Url + "transfer");
            return JsonConvert.DeserializeObject<IEnumerable<Banking_Transfer>>(result);
        }

        public async Task<IEnumerable<Banking_Service>> GetAllServices()
        {
            // TODO: use GET to retrieve books
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(Url + "service");
            return JsonConvert.DeserializeObject<IEnumerable<Banking_Service>>(result);
        }
    }
}
