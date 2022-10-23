namespace WebAPIRevisãoOng.Utils
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string PersonCollectionName { get; set; }
        public string PetCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
    }
}
