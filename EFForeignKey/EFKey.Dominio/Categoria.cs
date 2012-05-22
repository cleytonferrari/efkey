namespace EFKey.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UnidadeDeMedidaId { get; set; }
        public UnidadeDeMedida UnidadeDeMedida { get; set; }
    }
}
