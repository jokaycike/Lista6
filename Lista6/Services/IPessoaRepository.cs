using Lista6.Models;

namespace Lista6.Services
{
    public interface IPessoaRepository
    {
        public List<DadosPessoa> obterTodasPessoas();

        public DadosPessoa obterPessoaPorCpf(string cpf);

        public void Inserir(DadosPessoa novaPessoa);

        public bool Atualizar(string cpf, DadosPessoa pessoaAtualizada);
    
        public bool Remover(string cpf);
    }
}
