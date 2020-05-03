using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using madera.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace madera.Services
{
    public class Database
    {
        public readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            /**
             * Pour la démonstration toutes les tables sont supprimées et
             * recréer avec des fausses données afin qu'il n'y ai pas de données parasite
             */
            // Suppression de toutes les tables
            _database.DropTableAsync<Role>().Wait();
            _database.DropTableAsync<Utilisateur>().Wait();
            _database.DropTableAsync<ClientModel>().Wait();
            _database.DropTableAsync<ProjetModel>().Wait();
            _database.DropTableAsync<Devis>().Wait();
            _database.DropTableAsync<Remise>().Wait();
            _database.DropTableAsync<DossierTechnique>().Wait();
            _database.DropTableAsync<TypeEtat>().Wait();
            _database.DropTableAsync<Plan>().Wait();
            _database.DropTableAsync<Module>().Wait();

            // Création des tables
            _database.CreateTableAsync<Role>().Wait();
            _database.CreateTableAsync<Utilisateur>().Wait();
            _database.CreateTableAsync<ClientModel>().Wait();
			_database.CreateTableAsync<ProjetModel>().Wait();
            _database.CreateTableAsync<Devis>().Wait();
            _database.CreateTableAsync<Remise>().Wait();
            _database.CreateTableAsync<DossierTechnique>().Wait();
            _database.CreateTableAsync<TypeEtat>().Wait();
            _database.CreateTableAsync<Plan>().Wait();
            _database.CreateTableAsync<Module>().Wait();

            _loadFakeData();
        }

        private void _loadFakeData()
        {
            _loadFakeClient();
        }

        private void _loadFakeClient()
        {
            _database.InsertAllAsync(new [] {
                new ClientModel
                {
                    Nom = "Chhouinard",
                    Prenom = "Sumner",
                    NumRue = "21",
                    Rue = "rue du Clair Bocage",
                    Ville = "LA VALETTE-DU-VAR",
                    CodePostal = "83160",
                    Email = "SumnerChouinard@rhyta.com",
                    Telephone = "0425177049",
                    Pays = "FRANCE"
                },                
                new ClientModel
                {
                    Nom = "Bonsaint",
                    Prenom = "Philippine",
                    NumRue = "29",
                    Rue = "Place de la Gare",
                    Ville = "COLOMBES",
                    CodePostal = "92700",
                    Email = "PhilippineBonsaint@rhyta.com",
                    Telephone = "0128620574",
                    Pays = "FRANCE"
                },                
                new ClientModel
                {
                    Nom = "Asselin",
                    Prenom = "Somer",
                    NumRue = "51",
                    Rue = "rue des Chaligny",
                    Ville = "NICE",
                    CodePostal = "06000",
                    Email = "SomerAsselin@dayrep.com",
                    Telephone = "0440710306",
                    Pays = "FRANCE"
                },
                new ClientModel
                {
                    Nom = "Bérard",
                    Prenom = "Eglantine",
                    NumRue = "49",
                    Rue = "rue Adolphe Wurtz",
                    Ville = "LE PUY-EN-VELAY",
                    CodePostal = "43000",
                    Email = "EglantineBerard@jourrapide.com",
                    Telephone = "0412684333",
                    Pays = "FRANCE"
                }
            });
        }

        public Task<List<ProjetModel>> GetAllProjetsAsync()
        {
            return _database.GetAllWithChildrenAsync<ProjetModel>();
        }

        public Task<int> SaveProjetAsync(ProjetModel projet)
        {
            return _database.InsertAsync(projet);
        }
    }
}
