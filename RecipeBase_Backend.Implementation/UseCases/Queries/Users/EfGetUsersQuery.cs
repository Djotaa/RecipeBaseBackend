using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries.Users;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Get users";

        public string Description => "Ef get all users";

        public PagedResponse<UserDto> Execute(PagedSearch request)
        {
            var keyword = request.Keyword;

            var query = this.DbContext.Users.Where(x=>x.IsActive).AsQueryable();

            if (!String.IsNullOrWhiteSpace(keyword))
                query = query.Where(x => x.FullName.ToLower().Contains(keyword.ToLower()) || x.Username.ToLower().Contains(keyword.ToLower()) || x.Email.ToLower().Contains(keyword.ToLower()));

            var count = query.Count();

            var response = new PagedResponse<UserDto>(request, count);
            response.Items = query.Select(x => new UserDto
            {
                Id = x.Id,
                FullName = x.FullName,
                Username = x.Username,
                Email = x.Email,
                UseCaseIds = x.UseCases.Select(x=>x.UseCaseId).ToList()
            }).Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();

            return response;
        }
    }
}
