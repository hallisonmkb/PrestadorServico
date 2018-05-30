using PrestadorServico.Models;
using System.Data.Entity;

namespace PrestadorServico.DataContexts
{
    public class PrestadorServicoContext : DbContext
    {
        public PrestadorServicoContext() : base("PrestadorServicoDb") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PrestadorServicoContext,
                PrestadorServico.Migrations.Configuration>("PrestadorServicoDb"));
        }
        public virtual DbSet<ClienteModels> Clientes { get; set; }
        public virtual DbSet<FornecedorModels> Fornecedores { get; set; }
        public virtual DbSet<ServicoModels> Servicos { get; set; }
        public virtual DbSet<UsuarioModels> Usuarios { get; set; }

        //PM> enable-migrations -EnableAutomaticMigrations:$true
        //PM> Update-Database -Verbose -Force
    }
}