using Microsoft.AspNetCore.Mvc;
using PlaymoveTechTest.Application.Services.Suppliers;
using PlaymoveTechTest.Domain.Dtos.Suppliers;
using System.Net;

namespace PlaymoveTechTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController(ISupplierService supplierService) : ControllerBase
    {
        private readonly ISupplierService _supplierService = supplierService;

        /// <summary>
        /// Adiciona um novo fornecedor.
        /// </summary>
        /// <param name="request">Dados do fornecedor</param>
        /// <response code="201">Retorna a url da request com o id do fornecedor criado</response>
        /// <response code="400">Caso o email do fornecedor já exista</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] SupplierRequestDto request)
        {
            var result = await _supplierService.Create(request);

            if (result is null)
                return BadRequest("Email informado já está cadastrado!");

            return Created($"{Request.Path}/{result}", new { });
        }

        /// <summary>
        /// Retorna um fornecedor específico pelo Id.
        /// </summary>
        /// <param name="id">Id do fornecedor</param>
        /// <response code="200">Retorna os dados do fornecedor</response>
        /// <response code="404">Nenhum fornecedor encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _supplierService.GetById(id);

            return result is not null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Retorna todos os fornecedores.
        /// </summary>
        /// <response code="200">Retorna uma lista com todos fornecedores cadastrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SupplierResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierService.Get();

            return Ok(result);
        }

        /// <summary>
        /// Atualiza um fornecedor existente pelo Id.
        /// </summary>
        /// <param name="id">Id do fornecedor</param>
        /// <param name="request">Dados do fornecedor</param>
        /// <response code="204">Fornecedor atualizado com sucesso</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, SupplierRequestDto request)
        {
            var result = await _supplierService.Update(id, request);

            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Remove um fornecedor pelo Id.
        /// </summary>
        /// <param name="id">Id do fornecedor</param>
        /// <response code="200">Fornecedor excluido com sucesso</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.Delete(id);

            return result ? Ok() : NotFound();
        }
    }
}