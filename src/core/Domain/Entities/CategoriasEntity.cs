namespace Domain.Entities
{
    public class CategoriasEntity(string nome,
        string descricao) : BaseEntity
    {
        public string Nome { get; set; } = nome;

        public string Descricao { get; set; } = descricao;
    }
}
