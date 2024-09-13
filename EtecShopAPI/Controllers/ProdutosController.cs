using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EtecShopAPI.Collections;
using EtecShopAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace EtecShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _repo;

    public ProdutosController(IProdutoRepository repository)
    {
        _repo = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var produtos = await _repo.GetAllAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var produto = await _repo.GetByIdAsync(id);
        if (produto == null)
            return NotFound("Produto não encontrado");
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Produto produto)
    {
        await _repo.CreateAsync(produto);
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Produto produto)
    {
        var prod = await _repo.GetByIdAsync(produto.Id);
        if (prod == null)
            return NotFound("Produto não encontrado");

        await _repo.UpdateAsync(produto);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var prod = await _repo.GetByIdAsync(id);
        if (prod == null)
            return NotFound("Produto não encontrado");
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
