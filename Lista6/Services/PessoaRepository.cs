using Lista6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lista6.Services
{
    public class PessoaRepository : IPessoaRepository 
    {
        private static List<DadosPessoa> dadosPessoaList = new List<DadosPessoa>();

        public List<DadosPessoa> ObterTodasPessoas()
        {
            return dadosPessoaList;
        }
        public DadosPessoa ObterPessoaPorCpf(string cpf)
        {
            return dadosPessoaList.FirstOrDefault(p => p.Cpf == cpf);

        }

        public void Inserir(DadosPessoa novaPessoa)
        {
            dadosPessoaList.Add(novaPessoa);
        }



        public bool Atualizar(string cpf, DadosPessoa pessoaAtualizada) 
        {
            var pessoaExistente = dadosPessoaList.Find(p => p.Cpf == cpf);
            if (pessoaExistente != null) 
            {
                pessoaExistente.Nome = pessoaAtualizada.Nome;
                pessoaExistente.Cpf = pessoaAtualizada.Cpf;
                pessoaExistente.Peso = pessoaAtualizada.Peso;
                pessoaExistente.Altura = pessoaAtualizada.Altura;
                return true;
            }
            return false;
        }

        public bool Remover(string cpf)
        {
            var pessoaExistente = dadosPessoaList.Find(p => p.Cpf == cpf);
            
            if (pessoaExistente != null)
            { 
                dadosPessoaList.Remove(pessoaExistente);
                return true;
            }
            return false;
        }

        public List<DadosPessoa> PessoaIMCBom()
        {
            return dadosPessoaList
                            .Where(p => (p.Peso / (p.Altura * p.Altura)) >= 18 && (p.Peso / (p.Altura * p.Altura)) < 24)
                            .ToList();
        }

        public List<DadosPessoa> PorNome(string nome)
        {
            return dadosPessoaList
                .Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToList();

        }
    }
}
