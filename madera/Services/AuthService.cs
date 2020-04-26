using madera.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;

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
                JObject jsonData = (JObject)JsonConvert.DeserializeObject(result);

                try
                {
                    /**
                     * L'API PHP ne contient pas le prénom et nom de l'utilisateur
                     */
                    Utilisateur utilisateur = new Utilisateur
                    {
                        Id = (long) jsonData["data"]["user"]["utilisateur_id"],
                        Email = (string) jsonData["data"]["user"]["utilisateur_email"],
                        Nom = "Loutre",
                        Prenom = "Patrick"
                    };

                    await SecureStorage.SetAsync("token", jsonData["data"]["token"].ToString());
                    await SecureStorage.SetAsync("user", JsonConvert.SerializeObject(utilisateur));
                }
                catch
                {
                    // TODO: Gestion des erreurs en cas de non accès du dossier en écriture
                }
            }
            return response.StatusCode;
        }

        //--------------------------------------------------------------------

        /**
         * Retourne l'utilisateur authentifié
         */
        public async Task<Utilisateur> GetUtilisateurAsync()
        {
            try
            {
                string json = await SecureStorage.GetAsync("user");
                return JsonConvert.DeserializeObject<Utilisateur>(json);
            } catch
            {
                // TODO: Gestion des erreurs en cas de non accès au dossier en lecture
                return null;
            }
        }

        //--------------------------------------------------------------------

        /**
         * Retourne le token de l'utilisateur authentifié
         */
         public async Task<string> GetTokenAsync()
         {
            try
            {
                return await SecureStorage.GetAsync("token");
            }
            catch
            {
                // TODO: Gestion des erreurs en cas de non accès au dossier en lecture
                return null;
            }
        }
    }
}