namespace RecipeBase_Backend.Api.Core
{
    public class JwtSettings
    {
        public int Duration { get; set; }
        public string Issuer { get; set; }
        public string PrivateKey { get; set; }
    }
}
