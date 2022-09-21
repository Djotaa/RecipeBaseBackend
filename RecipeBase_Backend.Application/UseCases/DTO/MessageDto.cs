using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.UseCases.DTO
{
    public class CreateMessageDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
    }

    public class MessageDto : CreateMessageDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
