using Avaliacao.WorkinHub.Web.Migrations;
using Avaliacao.WorkinHub.Web.Models;
using System.Data.Entity;


namespace Avaliacao.WorkinHub.Web.DAL.Context
{
    public class WorkinHubContext : DbContext
    {
        public WorkinHubContext() : base("DefaultConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<WorkinHubContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorkinHubContext, Configuration>());


        }

        public DbSet<Pedido> Pedido { get; set; }
        
    }
}