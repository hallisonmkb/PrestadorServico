namespace PrestadorServico.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PrestadorServico.DataContexts.PrestadorServicoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PrestadorServico.DataContexts.PrestadorServicoContext";
        }

        protected override void Seed(PrestadorServico.DataContexts.PrestadorServicoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
