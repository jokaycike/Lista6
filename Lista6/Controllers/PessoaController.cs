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
        public PessoaController(IActionResult pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
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

        [HttpPut]
        [Route("Atualizar/{cpf}")]
        public IActionResult Atualizar(string cpf, DadosPessoa pessoaAtualizada)
        {
            var pessoaPesquisada = dados
        }
    }
}
