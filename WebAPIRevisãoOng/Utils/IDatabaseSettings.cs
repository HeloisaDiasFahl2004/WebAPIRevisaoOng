namespace WebAPIRevisãoOng.Utils
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string PersonCollectionName { get; set; }
        string PetCollectionName { get; set; }
        string AddressCollectionName { get; set; }  
    }
}
