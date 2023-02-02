using FluentValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private static readonly List<Livro> Livros = new()
        {
            new Livro()
            {
                Titulo = "Teste",
                Descricao = "Teste"
            }
        };

        private readonly ILogger<LivroController> _logger;

        public LivroController(ILogger<LivroController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "cadastra-livro")]
        public IActionResult Cadastra([FromBody] Livro livro)
        {
            if(ModelState.IsValid)
            {
                Livros.Add(livro);
                return Ok("Cadastrado com sucesso");
            }
            else
            {
                var erros = ModelState.Values.SelectMany(e => e.Errors);

                List<string> descricaoErros = new List<string>(erros.Count());

                foreach (var erro in erros)
                {
                    var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    descricaoErros.Add(errorMsg);
                }

                return BadRequest(new { erros = descricaoErros });
            }
        }
    }
}