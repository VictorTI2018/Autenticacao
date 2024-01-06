namespace Domain.Entities
{
    public class UserEntity(string nome,
        string email,
        string senha) : BaseEntity
    {
        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public string Senha { get; set; } = senha;
    }
}
