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
            _database.DropTableAsync<Plancher>().Wait();
            _database.DropTableAsync<Toiture>().Wait();
            _database.DropTableAsync<Panneau>().Wait();
            _database.DropTableAsync<Bardage>().Wait();
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
            _database.CreateTableAsync<Plancher>().Wait();
            _database.CreateTableAsync<Toiture>().Wait();
            _database.CreateTableAsync<Panneau>().Wait();
            _database.CreateTableAsync<Bardage>().Wait();
        }

        /**
         * Charges toutes les fausses données
         */
        private void _loadFakeData()
        {
            _loadFakeDataClient();
            _loadFakeDataTypeEtat();
            _loadFakeDataCoupePrincipe();
            _loadFakeDataPlancher();
            _loadFakeDataToiture();
            _loadFakeDataPanneau();
            _loadFakeDataBardage();
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
                }
            });
        }

        /**
         * Création des coupes de principes
         */
        private void _loadFakeDataCoupePrincipe()
        {
            _database.InsertAllAsync(new[] {
                new CoupePrincipe
                {
                    Reference = "MAD-38-A",
                    Nom = "CARRE 38m²",
                    Largeur = 615,
                    Longueur = 615,
                    PrixHT = 1235f,
                    QuantiteDefaut = 1
                },
                new CoupePrincipe
                {
                    Reference = "MAD-38-B",
                    Nom = "RECTANGLE 38m²",
                    Largeur = 750,
                    Longueur = 500,
                    PrixHT = 1655f,
                    QuantiteDefaut = 1
                },
                new CoupePrincipe
                {
                    Reference = "MAD-57-A",
                    Nom = "CARRE 57m²",
                    Largeur = 750,
                    Longueur = 750,
                    PrixHT = 1455f,
                    QuantiteDefaut = 1
                },
                new CoupePrincipe
                {
                    Reference = "MAD-57-B",
                    Nom = "RECTANGLE 57m²",
                    Largeur = 940,
                    Longueur = 600,
                    PrixHT = 1955f,
                    QuantiteDefaut = 1
                }
            });
        }

        /**
         * Création des planchers
         */
        private void _loadFakeDataPlancher()
        {
            _database.InsertAllAsync(new[] { 
                new Plancher
                {
                    Reference = "MAD-PB-38B",
                    Nom = "Plancher Bois",
                    PrixHT = 500,
                    QuantiteDefaut = 1
                },
                new Plancher
                {
                    Reference = "MAD-PSP",
                    Nom = "Plancher: Solution personelle",
                    PrixHT = 0,
                    QuantiteDefaut = 1
                }
            });
        }

        /**
         * Création des toitures
         */
         private void _loadFakeDataToiture()
         {
            _database.InsertAllAsync(new[]
            {
                new Toiture
                {
                    Reference = "MAD-CA30-38-B",
                    Nom = "Charpente Traditionnelle deux pentes à 30°",
                    PrixHT = 10000,
                    QuantiteDefaut = 1
                },                
                new Toiture
                {
                    Reference = "MAD-FP30-38-B",
                    Nom = "Charpente Traditionnelle deux pentes à 50°",
                    PrixHT = 12000,
                    QuantiteDefaut = 1
                },                
                new Toiture
                {
                    Reference = "MAD-CA20-38-B",
                    Nom = "Charpente Traditionnelle deux pentes à 20°",
                    PrixHT = 8000,
                    QuantiteDefaut = 1
                },                
                new Toiture
                {
                    Reference = "MAD-FP20-38-B",
                    Nom = "Charpente Traditionnelle deux pentes à 40°",
                    PrixHT = 11000,
                    QuantiteDefaut = 1
                }
            });
        }

        /**
         * Création des panneaux
         */
        private void _loadFakeDataPanneau()
        {
            _database.InsertAllAsync(new[]
            {
                new Panneau
                {
                    Reference = "MAD-PM01-PP",
                    Nom = "Panneau plein sans ouverture",
                    PrixHT = 150,
                    QuantiteDefaut = 1,
                },
                new Panneau
                {
                    Reference = "MAD-PM02-PS",
                    Nom = "Panneau ouverture porte simple",
                    PrixHT = 300,
                    QuantiteDefaut = 1
                },               
                new Panneau
                {
                    Reference = "MAD-PM03-FS",
                    Nom = "Panneau ouverture fenêtre simple",
                    PrixHT = 400,
                    QuantiteDefaut = 1
                },                
                new Panneau
                {
                    Reference = "MAD-PM04-FDS",
                    Nom = "Panneau ouverture fenêtre double S",
                    PrixHT = 500,
                    QuantiteDefaut = 1
                }
            });
        }

        /**
         * Création des bardages
         */
        private void _loadFakeDataBardage()
        {
            _database.InsertAllAsync(new[]
            {
                new Bardage
                {
                    Reference = "MAD-BM-01-PSN-38-B",
                    Nom = "Bardage C3 pin sylvestre naturel",
                    PrixHT = 1200,
                    QuantiteDefaut = 1
                },
                new Bardage
                {
                    Reference = "MAD-BM02-FCE-38-B",
                    Nom = "Bardage pour finition crépis",
                    PrixHT = 1800,
                    QuantiteDefaut = 1
                },
                new Bardage
                {
                    Reference = "MAD-BM03-PPC-38-B",
                    Nom = "Bardage pré-peint en usine",
                    PrixHT = 2500,
                    QuantiteDefaut = 1
                },                
                new Bardage
                {
                    Reference = "MAD-BM04-BSP",
                    Nom = "Bardage: Solution personelle",
                    PrixHT = 0,
                    QuantiteDefaut = 1
                }
            });
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
