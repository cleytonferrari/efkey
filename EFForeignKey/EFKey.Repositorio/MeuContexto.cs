using System.Data.Entity;
using EFKey.Dominio;

namespace EFKey.Repositorio
{
    public class MeuContexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
