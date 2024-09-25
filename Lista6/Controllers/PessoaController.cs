
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
        public PessoaController(IPessoaRepository pessoaRepository)
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

            var novaPessoa = new DadosPessoa
            {
               Nome = dados.Nome,
               Cpf = dados.Cpf,
               Peso = dados.Peso,
               Altura = dados.Altura
            };

            _pessoaRepository.Inserir(novaPessoa);

            return Ok($"Aluno (a) {dados.Nome} inserido com sucesso.");
        }

        [HttpDelete("remover/{cpf}")]
        public IActionResult Remover(string cpf)
        {
            if (!_pessoaRepository.Remover(cpf))
            {
                return NotFound($"Aluno com CPF {cpf} não encontrado.");
            }

            return NoContent();
        }


        [HttpPut("atualizar/{cpf}")]
        public IActionResult Atualizar(string cpf, DadosPessoa pessoaAtualizada)
        {
            if (!_pessoaRepository.Atualizar(cpf, pessoaAtualizada))
            {
                return NotFound($"Aluno com CPF {cpf} não encntrado");
            }
            return NoContent();
        }

        
        [HttpGet("ObterPorCpf")]

        public IActionResult ObterPorCpf(string cpf)
        {
            var pessoa = _pessoaRepository.ObterPessoaPorCpf(cpf);

            if(pessoa == null)
            {
                return NotFound($"Pessoa com cpf {cpf} não encontrado.");
            }

            return Ok(pessoa);
        }

        
        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            return Ok(_pessoaRepository.ObterTodasPessoas());
        }

        
        [HttpGet("pessoasIMCBom")]

        public IActionResult PessoaIMCBom()
        {
            var pessoasIMCBom = _pessoaRepository.PessoaIMCBom();
            return Ok(pessoasIMCBom);
        }

        [HttpGet("porNome/{nome}")]
        public IActionResult PorNome(string nome)
        {
            var pessoas = _pessoaRepository.PorNome(nome);
            return Ok(pessoas);
        }
    }
}
