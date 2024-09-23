
using Lista6.Models;
using Lista6.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
    

namespace Lista6.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private static List<DadosPessoa> dadosPessoaList = new List<DadosPessoa>();

        public PessoaController(IActionResult pessoaRepository)
        {
            _pessoaRepository = (IPessoaRepository?)pessoaRepository;
        }

        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir(NovaPessoa dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pessoaRepository.Inserir(new DadosPessoa()
            {
               nome = dados.nome,
               cpf = dados.cpf,
               peso = dados.peso,
               altura = dados.altura
            });

            return Ok($"Aluno (a) {dados.nome} inserido com sucesso.");
        }

        [HttpDelete]
        [Route("Remover")]
        public IActionResult Remover(string cpf)
        {
            var pessoaPesquisada = dadosPessoaList.Where(a => a.cpf == cpf).FirstOrDefault();
        
            if(pessoaPesquisada is null)
            {
                return NotFound($"Aluno com cpf {cpf} não encontrado.");
            }

            dadosPessoaList.Remove(pessoaPesquisada);
            return NoContent();
        }


        [HttpPut]
        [Route("Atualizar/{cpf}")]
        public IActionResult Atualizar(string cpf, DadosPessoa pessoaAtualizada)
        {
            var pessoaPesquisada = dadosPessoaList.Where(a => a.cpf == cpf).FirstOrDefault();
        
            pessoaPesquisada.nome = pessoaAtualizada.nome;
            pessoaPesquisada.cpf =  pessoaAtualizada.cpf;
            pessoaPesquisada.peso = pessoaAtualizada.peso;
            pessoaPesquisada.altura = pessoaAtualizada.altura;
        
            return NoContent();
        }

        [HttpGet]
        [Route("ObterPorCpf")]

        public IActionResult ObterPorCpf(string cpf)
        {
            var pessoaPesquisada = _pessoaRepository.obterPessoaPorCpf(cpf);

            if(pessoaPesquisada is null)
            {
                return NotFound($"Pessoa com cpf {cpf} não encontrado.");
            }

            return Ok(pessoaPesquisada);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            return Ok(_pessoaRepository.obterTodasPessoas());
        }
    }
}
