using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using WebAPIRevisãoOng.Models;
using WebAPIRevisãoOng.Utils;

namespace WebAPIRevisãoOng.Service
{
    public class PetService
    {
        //propriedade do mongo, instalo a biblioteca MongoDB.Driver
        private readonly IMongoCollection<PetModel> _pet;
        //construtor
        public PetService(IDatabaseSettings dbSettings)
        {
            var pet = new MongoClient(dbSettings.ConnectionString);
            var db = pet.GetDatabase(dbSettings.DatabaseName);
            _pet = db.GetCollection<PetModel>(dbSettings.PetCollectionName);
        }
        #region Create
        public PetModel Create(PetModel pet)
        {
            _pet.InsertOne(pet);
            return pet;
        }
        #endregion

        #region Get
        //GetAll
        public List<PetModel> GetAllPet() => _pet.Find<PetModel>(petModel => true).ToList();

        //GetOnePetByChip
        public PetModel GetOnePetByChip(string chip) => _pet.Find<PetModel>(petModel=> petModel.Chip == chip).FirstOrDefault();
        #endregion

        #region Update
        public void Update(string chip, PetModel pet) => _pet.ReplaceOne(pet => pet.Chip == chip,pet);
    
        #endregion  
    }
}
