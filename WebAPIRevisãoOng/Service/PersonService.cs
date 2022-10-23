using MongoDB.Driver;
using System.Collections.Generic;
using WebAPIRevisãoOng.Models;
using WebAPIRevisãoOng.Utils;

namespace WebAPIRevisãoOng.Service
{
    public class PersonService
    {
        private readonly IMongoCollection<PersonModel> _person;
        public PersonService(IDatabaseSettings dbSettings)
        {
            var person = new MongoClient(dbSettings.ConnectionString);
            var db = person.GetDatabase(dbSettings.DatabaseName);
            _person = db.GetCollection<PersonModel>(dbSettings.PersonCollectionName);
        }
        public PersonModel Create(PersonModel person)
        {
            _person.InsertOne(person);
            return person;
        }
        public List<PersonModel> Get() => _person.Find<PersonModel>(person => true).ToList();
        public PersonModel GetOnePersonById(string id) => _person.Find<PersonModel>(person => person.Id == id).FirstOrDefault();
    
    }
}