using Lista6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lista6.Services
{
    public class PessoaRepository : IPessoaRepository 
    {
        private static List<DadosPessoa> dadosPessoaList = new List<DadosPessoa>();
        public PessoaRepository() { }

        public void Inserir(DadosPessoa novaPessoa)
        {
            dadosPessoaList.Add(novaPessoa);
        }

        public bool Atualizar(string cpf, DadosPessoa pessoaAtualizada) 
        {
            var pessoaPesquisado = dadosPessoaList.Where(a => a.cpf == cpf).FirstOrDefault();
            if (pessoaPesquisado is null){
                return false;
            }
            pessoaPesquisado.nome = pessoaAtualizada.nome;
            pessoaPesquisado.cpf = pessoaAtualizada.cpf;
            pessoaPesquisado.peso = pessoaAtualizada.peso;
            pessoaPesquisado.altura = pessoaAtualizada.altura;

            return true;
        }

        public bool Remover(string cpf)
        {
            var pessoaPesquisado = dadosPessoaList.Where(a => a.cpf == cpf).FirstOrDefault();
            
            if (pessoaPesquisado is null)
            {
                return false;
            }
        }
        public List<DadosPessoa> obterTodasPessoas()
        {
            return dadosPessoaList;
        }

        public DadosPessoa obterPessoaPorCpf(string cpf)
        {
            return dadosPessoaList.Where(a => a.cpf == cpf).FirstOrDefault();
        }
    }
}
