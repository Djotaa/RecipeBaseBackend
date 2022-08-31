using RecipeBase_Backend.Application.Logging;
using RecipeBase_Backend.DataAccess;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using Mapster;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        public AppDbContext dbContext { get; set; }

        public EfUseCaseLogger(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search)
        {
            throw new NotImplementedException();
        }

        public void Log(UseCaseLog log)
        {
            this.dbContext.AuditLogs.Add(log.Adapt<AuditLog>());
            this.dbContext.SaveChanges();

            Console.WriteLine($"User: {log.Username} - UseCase: {log.UseCaseName}");

        }
    }
}
