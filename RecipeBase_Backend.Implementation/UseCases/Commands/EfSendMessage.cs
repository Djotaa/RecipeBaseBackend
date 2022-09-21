using FluentValidation;
using RecipeBase_Backend.Application.UseCases.Commands;
using RecipeBase_Backend.Application.UseCases.DTO;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using RecipeBase_Backend.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.UseCases.Commands
{
    public class EfSendMessage : EfUseCase, ISendMessage
    {
        private MessageValidator messageValidator;
        public EfSendMessage(AppDbContext context, MessageValidator validator) : base(context)
        {
            this.messageValidator = validator;
        }

        public int Id => 23;

        public string Name => "Ef send message";

        public string Description => "Users send messages";

        public void Execute(CreateMessageDto request)
        {
            this.messageValidator.ValidateAndThrow(request);

            var message = new Message
            {
                Email = request.Email,
                FullName = request.FullName,
                MessageContent = request.Message
            };

            DbContext.Messages.Add(message);
            DbContext.SaveChanges();
        }
    }
}
