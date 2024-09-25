using Lista6.Models;

namespace Lista6.Services
{
    public interface IPessoaRepository
    {
        public List<DadosPessoa> ObterTodasPessoas();

        public DadosPessoa ObterPessoaPorCpf(string cpf);

        public void Inserir(DadosPessoa novaPessoa);

        public bool Atualizar(string cpf, DadosPessoa pessoaAtualizada);

        public bool Remover(string cpf);

        public List<DadosPessoa> PessoaIMCBom();

        public List<DadosPessoa> PorNome(string nome);
    }
}
