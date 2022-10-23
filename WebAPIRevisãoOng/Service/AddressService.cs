using MongoDB.Driver;
using System.IO;
using System.Net;
using WebAPIRevisãoOng.Models;
using WebAPIRevisãoOng.Utils;

namespace WebAPIRevisãoOng.Service
{
    public class AddressService
    {
        private readonly IMongoCollection<AddressModel> _address;
        public AddressService(IDatabaseSettings dbSettings)
        {
            var address = new MongoClient(dbSettings.ConnectionString);
            var db = address.GetDatabase(dbSettings.DatabaseName);
            _address = db.GetCollection<AddressModel>(dbSettings.AddressCollectionName);
        }

        #region Get
        //método get que consome api já pronta(viacep)
        public string GetAddress(string cep)
        {
            HttpWebRequest request =(HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/"+cep+"/json");
            request.AllowAutoRedirect = false;
            HttpWebResponse checaServidor = (HttpWebResponse)request.GetResponse();
            Stream stream = checaServidor.GetResponseStream();
            if (stream == null) return null;
            StreamReader streamReader = new StreamReader(stream);
            string message = streamReader.ReadToEnd();
            return message;
        }
        #endregion

        #region Create
        public AddressModel Create(AddressModel address)
        {
            _address.InsertOne(address);
            return address;
        }
        #endregion
    }
}
