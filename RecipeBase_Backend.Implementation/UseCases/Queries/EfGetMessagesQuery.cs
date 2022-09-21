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
    public class EfGetMessagesQuery : EfUseCase, IGetMessagesQuery
    {
        public EfGetMessagesQuery(AppDbContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Ef get messages";

        public string Description => "Get all messages sent through contact form";

        public PagedResponse<MessageDto> Execute(PagedSearch request)
        {

            var query = this.DbContext.Messages.Where(x => x.IsActive).AsQueryable();

            var count = query.Count();

            var queryResponse = query.Skip((request.PageNo - 1) * request.PerPage).Take(request.PerPage).ToList();

            var messages = queryResponse.Select(x =>
            {
                var message = new MessageDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    CreatedAt = x.CreatedAt,
                    Message = x.MessageContent
                };
                return message;
            });

            var response = new PagedResponse<MessageDto>(request, count);
            response.Items = messages;

            return response;
        }
    }
}
