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

        // -------------------------------------------------------------------

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _removeAllTable();
            _createAllTable();
            _loadFakeData();
        }

        // -------------------------------------------------------------------

        /**
         * Supprime toutes les tables pour rénitialiser les données pour
         * la démonstration
         */
        private void _removeAllTable()
        {
            _database.DropTableAsync<Role>().Wait();
            _database.DropTableAsync<Utilisateur>().Wait();
            _database.DropTableAsync<ClientModel>().Wait();
            _database.DropTableAsync<ProjetModel>().Wait();
            _database.DropTableAsync<Plan>().Wait();
            _database.DropTableAsync<Devis>().Wait();
            _database.DropTableAsync<LigneDevis>().Wait();
            _database.DropTableAsync<Remise>().Wait();
            _database.DropTableAsync<DossierTechnique>().Wait();
            _database.DropTableAsync<TypeEtat>().Wait();
            _database.DropTableAsync<Module>().Wait();
            _database.DropTableAsync<CoupePrincipe>().Wait();
        }

        /**
         * Créé toutes les tables
         */
        private void _createAllTable()
        {
            _database.CreateTableAsync<Role>().Wait();
            _database.CreateTableAsync<Utilisateur>().Wait();
            _database.CreateTableAsync<ClientModel>().Wait();
            _database.CreateTableAsync<ProjetModel>().Wait();
            _database.CreateTableAsync<Plan>().Wait();
            _database.CreateTableAsync<Devis>().Wait();
            _database.CreateTableAsync<LigneDevis>().Wait();
            _database.CreateTableAsync<Remise>().Wait();
            _database.CreateTableAsync<DossierTechnique>().Wait();
            _database.CreateTableAsync<TypeEtat>().Wait();
            _database.CreateTableAsync<Module>().Wait();
            _database.CreateTableAsync<CoupePrincipe>().Wait();
        }

        /**
         * Charges toutes les fausses données
         */
        private void _loadFakeData()
        {
            _loadFakeDataClient();
            _loadFakeDataTypeEtat();
            _loadFakeDataCoupePrincipe();
        }

        /**
         * Création des faux clients
         */
        private void _loadFakeDataClient()
        {
            _database.InsertAllWithChildrenAsync(new [] {
                new ClientModel
                {
                    ID = 1,
                    Nom = "Chhouinard",
                    Prenom = "Sumner",
                    NumRue = "21",
                    Rue = "rue du Clair Bocage",
                    Ville = "LA VALETTE-DU-VAR",
                    CodePostal = "83160",
                    Email = "SumnerChouinard@rhyta.com",
                    Telephone = "0425177049",
                    Pays = "FRANCE",
                    Projets = new List<ProjetModel>()
                    {
                        new ProjetModel()
                        {
                            ClientId = 1,
                            Nom = "Projet #1"
                        },
                        new ProjetModel()
                        {
                            ClientId = 1,
                            Nom = "Projet #2"
                        }
                    }
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

        
        /**
         * Création des faux Type d'États
         */
        private void _loadFakeDataTypeEtat()
        {
            _database.InsertAllAsync(new[] {
                new TypeEtat
                {
                    Id = 1,
                    Nom = "Brouillon"
                },
                new TypeEtat
                {
                    Id = 2,
                    Nom = "En attente"
                },
                new TypeEtat
                {
                    Id = 3,
                    Nom = "Accepté"
                },
            });
        }

        private void _loadFakeDataCoupePrincipe()
        {
            _database.InsertAllAsync(new[] {
                new CoupePrincipe
                {
                    Reference = 1,
                    Nom = "CARRE 38m²",
                    Largeur = 615,
                    Longueur = 615,
                    PrixHT = 1235f,
                    QuantiteDefaut = 1
                },
                new CoupePrincipe
                {
                    Reference = 2,
                    Nom = "RECTANGLE 38m²",
                    Largeur = 750,
                    Longueur = 500,
                    PrixHT = 1655f,
                    QuantiteDefaut = 1
                },
                new CoupePrincipe
                {
                    Reference = 3,
                    Nom = "CARRE 57m²",
                    Largeur = 750,
                    Longueur = 750,
                    PrixHT = 1455f,
                    QuantiteDefaut = 1
                },
                new CoupePrincipe
                {
                    Reference = 4,
                    Nom = "RECTANGLE 57m²",
                    Largeur = 940,
                    Longueur = 600,
                    PrixHT = 1955f,
                    QuantiteDefaut = 1
                },
            }); ;
        }

        // -------------------------------------------------------------------


        // TODO: CREER UN SERVICE SPÉCIFIQUE POUR GÉRER LES PROJETS

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
