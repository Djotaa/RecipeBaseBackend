using RecipeBase_Backend.Domain;
using System.Collections.Generic;

namespace RecipeBase_Backend.Api.Core
{
    public class JwtAppUser : IAppUser
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public ICollection<int> UseCaseIds { get; set; }
    }


    public class AnonymousAppUser : IAppUser
    {
        public string Username => "(guest)";
        public int Id => 0;
        public ICollection<int> UseCaseIds => new List<int> { 1, 2, 3, 4 };
    }
}
