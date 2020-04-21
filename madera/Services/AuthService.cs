using madera.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace madera.Services
{
    public class AuthService : IAuthService
    {
        /**
         * Client HTTP
         */
        private readonly HttpClient _client;

        /**
         * URL de l'API
         */
        private readonly Uri BaseUri;

        //--------------------------------------------------------------------

        /**
         * Constructeur
         */
        public AuthService()
        {
            BaseUri = new Uri("https://apicoulet.com/api/");
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        //--------------------------------------------------------------------

        /**
         * Authentification de l'utilisateur
         * @param Utilisateur utilisateur
         * @return Task<HttpStatusCode>
         */
        public async Task<HttpStatusCode> Login(AuthModel authModel)
        {
            var json    = JsonConvert.SerializeObject(authModel);
            var content = new StringContent( json , Encoding.UTF8, "application/json");
            var uri     = new Uri( BaseUri, "login" );

            var response = await _client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var jsonData = (JObject)JsonConvert.DeserializeObject(result);

                try
                {
                    await SecureStorage.SetAsync("password", authModel.utilisateur_password);
                    await SecureStorage.SetAsync("token", jsonData["data"]["token"].ToString());
                    await SecureStorage.SetAsync("user", jsonData["data"]["user"].ToString());
                }
                catch
                {
                    // TODO: Gestion des erreurs en cas de non accès du dossier en écriture
                }
            }
            return response.StatusCode;
        }
    }
}
