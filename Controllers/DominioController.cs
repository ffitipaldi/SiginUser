using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiginUser.Data;
using SiginUser.Models;
using System;
using System.Reflection;

namespace SiginUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominioController : ControllerBase
    {
        //-------------------------------------------------//
        //Pega o contexto do banco de dados
        //-------------------------------------------------//
        private readonly ApplicationDbContext context;

        public DominioController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //---------------------------------------------------------//
        //GET:api/dominio -  lista todos os Dominios = GetDominios
        //---------------------------------------------------------//
        [HttpGet(Name = "GetDominios")]
        public async Task<ActionResult<List<Dominio>>> GetDominios()
        {
            return await context.Dominios.AsNoTracking()
                .OrderBy(x => x.Campo)                      //faltou  x.Sequencia
                .ToListAsync();
        }

        //-------------------------------------------------------------//
        //GET:api/dominio/1  -  ler um Dominio pelo Id = GetDominioById
        //-------------------------------------------------------------//
        [HttpGet("{id}", Name = "GetDominioById")]
        public async Task<ActionResult<Dominio>> GetDominioById(int id)
        {
            return await context.Dominios
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        //-----------------------------------------------------------//
        //GET:api/dominio/campo/TipoSexo  -  Lista Dominio pelo campo
        //-----------------------------------------------------------//
        [HttpGet("campo/{campo}", Name = "GetDominioByCampoList")]
        public async Task<ActionResult<List<Dominio>>> GetDominioByCampoList(string campo)
        {
            return await context.Dominios
                .Where(x => x.Campo == campo)
                .OrderBy(x => x.Sequencia)
                .ToListAsync();
        }

        //-----------------------------------------------------------------//
        //GET:api/dominio/TipoSexo/MASC  -  Ler um Dominio pelo campo/Sigla
        //-----------------------------------------------------------------//
        [HttpGet("{campo}/{sigla}", Name = "GetDominioByCampoSigla")]
        public async Task<ActionResult<Dominio>> GetDominioByCampoSigla(string campo, string sigla)
        {
            return await context.Dominios
                .Where(x => x.Campo == campo && x.Sigla == sigla)                
                .FirstOrDefaultAsync();
        }

        //-------------------------------------------------//
        //POST:api/dominio  - Inclui um novo Dominio
        //-------------------------------------------------//
        [HttpPost(Name ="IncluiDominio")]
        public async Task<ActionResult<Dominio>> Post(Dominio dominio)
        {
            context.Add(dominio);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetDominioById", new { id = dominio.Id }, dominio);
        }

        //-------------------------------------------------------------------------------//
        //PUT:api/dominio/3 -  Altera um Dominio pelo Id contido no corpo da requisição
        //-------------------------------------------------------------------------------//
        [HttpPut("{id}",Name ="AlteraDominio")]
        public async Task<ActionResult<Dominio>> Put(int id, Dominio dominio)
        {
            context.Entry(dominio).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(dominio);
        }

        //-------------------------------------------------//
        //Deleta um Dominio pelo Id
        //-------------------------------------------------//
        [HttpDelete("{id}",Name ="ExcluiDominio")]
        public async Task<ActionResult<Dominio>> Delete(int id)
        {
            var dominio = new Dominio { Id = id };
            context.Remove(dominio);
            await context.SaveChangesAsync();
            return Ok(dominio);
        }
    }
}

