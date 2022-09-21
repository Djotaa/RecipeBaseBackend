using RecipeBase_Backend.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.Commands
{
    public interface ISendMessage : ICommand<CreateMessageDto>
    {
    }
}
