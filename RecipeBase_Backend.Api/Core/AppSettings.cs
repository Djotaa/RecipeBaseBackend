namespace RecipeBase_Backend.Api.Core
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public JwtSettings JwtConfig { get; set; }
        public string AzureStorageString { get; set; }
    }
}
