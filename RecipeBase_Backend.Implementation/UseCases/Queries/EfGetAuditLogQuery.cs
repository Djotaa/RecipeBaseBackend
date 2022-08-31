using MapsterMapper;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.Application.UseCases.DTO.Searches;
using RecipeBase_Backend.Application.UseCases.Queries;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Queries
{
    public class EfGetAuditLogQuery : EfUseCase, IGetAuditLog
    {
        public EfGetAuditLogQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Get Audit Log";

        public string Description => "Search through Audit Logs and see user actions";

        public PagedResponse<AuditLogDto> Execute(PagedAuditLogSearch request)
        {
            var keyword = request.Keyword;

            var query = this.DbContext.AuditLogs.AsQueryable();

            if (!String.IsNullOrWhiteSpace(keyword))
                query = query.Where(x => x.UseCaseName.ToLower().Contains(keyword.ToLower()) || x.Username.ToLower().Contains(keyword.ToLower()));

            if (!String.IsNullOrWhiteSpace(request.Username))
                query = query.Where(x => x.Username.ToLower().Contains(request.Username.ToLower()));

            if (!String.IsNullOrWhiteSpace(request.UseCaseName))
                query = query.Where(x => x.UseCaseName.ToLower().Contains(request.UseCaseName.ToLower()));

            if (request.DateFrom != null)
                query = query.Where(x => x.ExecutedAt > request.DateFrom);

            if (request.DateTo != null)
                query = query.Where(x => x.ExecutedAt < request.DateTo);

            var count = query.Count();

            var response = new PagedResponse<AuditLogDto>(request, count);

            response.Items = query.Select(x => new AuditLogDto
            {
                UseCaseName = x.UseCaseName,
                Username = x.Username,
                UserId = x.UserId,
                ExecutedAt = x.ExecutedAt,
                Data = x.Data,
                IsAuthorized = x.IsAuthorized,
                Id = x.Id
            }).Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();

            return response;
        }
    }
}
