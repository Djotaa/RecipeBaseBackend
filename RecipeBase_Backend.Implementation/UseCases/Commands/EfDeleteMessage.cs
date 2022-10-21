using RecipeBase_Backend.Application.Exceptions;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands
{
    public class EfDeleteMessage : EfUseCase, IDeleteMessage
    {
        public EfDeleteMessage(AppDbContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Delete message";

        public string Description => "Ef admin deletes messages";

        public void Execute(int request)
        {
            var message = DbContext.Messages.FirstOrDefault(x => x.IsActive && x.Id == request);

            if (message == null)
                throw new EntityNotFoundException();

            DbContext.Remove(message);
            DbContext.SaveChanges();
        }
    }
}
