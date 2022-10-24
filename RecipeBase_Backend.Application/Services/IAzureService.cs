using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Application.Services
{
    public interface IAzureService
    {
        string Upload(Stream fileSream, string fileName, string contentType);
        void Delete(string fileName);
    }
}
