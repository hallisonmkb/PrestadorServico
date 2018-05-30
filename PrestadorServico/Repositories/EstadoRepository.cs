using System.Collections.ObjectModel;
using PrestadorServico.Models;

namespace PrestadorServico.Repositories
{
    public class EstadoRepository
    {
        public ObservableCollection<EstadoModels> Estados = new ObservableCollection<EstadoModels>
        {
            new EstadoModels { Nome = "Acre", Sigla = "AC" },
            new EstadoModels { Nome = "Alagoas", Sigla = "AL" },
            new EstadoModels { Nome = "Amapá", Sigla = "AP" },
            new EstadoModels { Nome = "Amazonas", Sigla = "AM" },
            new EstadoModels { Nome = "Bahia", Sigla = "BA" },
            new EstadoModels { Nome = "Ceará", Sigla = "CE" },
            new EstadoModels { Nome = "Distrito Federal", Sigla = "DF" },
            new EstadoModels { Nome = "Espírito Santo", Sigla = "ES" },
            new EstadoModels { Nome = "Goiás", Sigla = "GO" },
            new EstadoModels { Nome = "Maranhão", Sigla = "MA" },
            new EstadoModels { Nome = "Mato Grosso", Sigla = "MT" },
            new EstadoModels { Nome = "Mato Grosso do Sul", Sigla = "MS" },
            new EstadoModels { Nome = "Minas Gerais", Sigla = "MG" },
            new EstadoModels { Nome = "Pará", Sigla = "PA" },
            new EstadoModels { Nome = "Paraíba", Sigla = "PB" },
            new EstadoModels { Nome = "Paraná", Sigla = "PR" },
            new EstadoModels { Nome = "Pernambuco", Sigla = "PE" },
            new EstadoModels { Nome = "Piauí", Sigla = "PI" },
            new EstadoModels { Nome = "Rio de Janeiro", Sigla = "RJ" },
            new EstadoModels { Nome = "Rio Grande do Norte", Sigla = "RN" },
            new EstadoModels { Nome = "Rio Grande do Sul", Sigla = "RS" },
            new EstadoModels { Nome = "Rondônia", Sigla = "RO" },
            new EstadoModels { Nome = "Roraima", Sigla = "RR" },
            new EstadoModels { Nome = "Santa Catarina", Sigla = "SC" },
            new EstadoModels { Nome = "São Paulo", Sigla = "SP" },
            new EstadoModels { Nome = "Sergipe", Sigla = "SE" },
            new EstadoModels { Nome = "Tocantins", Sigla = "TO" }
        };
    }
}