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
        ///-------------------------------------------------//
        /// Pega o contexto do banco de dados
        ///-------------------------------------------------//
        /// 
        private readonly ApplicationDbContext context;

        public DominioController(ApplicationDbContext context)
        {
            this.context = context;
        }


        ///-------------------------------------------------------------//
        /// <summary>
        /// GET:api/dominio -  lista todos os Dominios = GetDominios
        /// </summary>
        /// <returns>
        ///     [
        ///       {
        ///         "id": 22,
        ///         "campo": "OrigemCandidato",
        ///         "sigla": "DETRAN",
        ///         "descricao": "Detran",
        ///         "sequencia": 1
        ///       },
        ///       {
        ///         "id": 23,
        ///         "campo": "OrigemCandidato",
        ///         "sigla": "PART",
        ///         "descricao": "Particular",
        ///         "sequencia": 2
        ///       }
        ///     ]
        /// </returns>
        ///-------------------------------------------------------------//
        /// 
        [HttpGet(Name = "GetDominios")]
        public async Task<ActionResult<List<Dominio>>> GetDominios()
        {
            return await context.Dominios.FromSqlRaw
                (
                    "Select * " +
                    "From Dominios " +
                    "Order by Campo, Sequencia"

                ).ToListAsync();

            //return await context.Dominios.AsNoTracking()
            //    .OrderBy(x => x.Campo)
            //    .ThenBy(x => x.Sequencia)
            //    .ToListAsync();
        }


        ///-------------------------------------------------------------//
        /// <summary>
        /// GET:api/dominio/1  -  ler um Dominio pelo Id = GetDominioById
        /// </summary>
        /// <param name="id">Identificador do Domínio que se deseja ler</param>
        /// <returns>
        ///     {
        ///      "id": 1,
        ///      "campo": "TipoSexo",
        ///      "sigla": "MASC",
        ///      "descricao": "Masculino",
        ///      "sequencia": 1
        ///     }
        /// </returns>
        ///-------------------------------------------------------------//
        /// 
        [HttpGet("{id}", Name = "GetDominioById")]
        public async Task<ActionResult<Dominio>> GetDominioById(int id)
        {
            return await context.Dominios.FromSqlRaw
                (
                    "Select * " +
                    "From Dominios " +
                    "Where Id = {0}", id
                ) .FirstOrDefaultAsync();

            //return await context.Dominios
            //    .Where(x => x.Id == id)
            //    .FirstOrDefaultAsync();
        }


        ///-----------------------------------------------------------//
        /// <summary>
        /// GET:api/dominio/campo/TipoSexo  -  Lista Dominio pelo campo
        /// </summary>
        /// <param name="campo">Nome do campo desejado a ser listado</param>
        /// <returns>
        ///     [
        ///        {
        ///            "id": 1,
        ///            "campo": "TipoSexo",
        ///            "sigla": "MASC",
        ///            "descricao": "Masculino",
        ///            "sequencia": 1
        ///        },
        ///        {
        ///            "id": 3,
        ///            "campo": "TipoSexo",
        ///            "sigla": "FEM",
        ///            "descricao": "Feminino",
        ///            "sequencia": 2
        ///        }
        ///     ]
        /// </returns>
        ///-----------------------------------------------------------//
        ///
        [HttpGet("campo/{campo}", Name = "GetDominioByCampoList")]
        public async Task<ActionResult<List<Dominio>>> GetDominioByCampoList(string campo)
        {
            return await context.Dominios.FromSqlRaw
                (
                    "Select * " +
                    "From Dominios " +
                    "Where Campo = {0} " +
                    "Order by Sequencia", campo

                ).ToListAsync();

            //return await context.Dominios
            //    .Where(x => x.Campo == campo)
            //    .OrderBy(x => x.Sequencia)
            //    .ToListAsync();
        }


        ///-----------------------------------------------------------//
        /// <summary>
        /// GET:api/dominio/TipoSexo/MASC  -  Ler um Dominio pelos campos: Campo e Sigla 
        /// </summary>
        /// <param name="campo">Nome do campo desejado a ser listado</param>
        /// <param name="sigla">Sigla pertencente ao campo listado</param>
        /// <returns>
        ///    {
        ///        "id": 1,
        ///        "campo": "TipoSexo",
        ///        "sigla": "MASC",
        ///        "descricao": "Masculino",
        ///        "sequencia": 1
        ///    }
        /// </returns>
        ///-----------------------------------------------------------//
        ///
        [HttpGet("{campo}/{sigla}", Name = "GetDominioByCampoSigla")]
        public async Task<ActionResult<Dominio>> GetDominioByCampoSigla(string campo, string sigla)
        {
            return await context.Dominios
                .Where(x => x.Campo == campo && x.Sigla == sigla)                
                .FirstOrDefaultAsync();
        }


        ///-----------------------------------------------------------//
        /// <summary>
        /// POST:api/dominio  - Inclui um novo Dominio 
        /// </summary>
        /// <param name="dominio">Jason com a estrutura de um domínio com id = 0
        ///     {
        ///       "id": 0,
        ///       "campo": "TipoSexo",
        ///       "sigla": "OUT",
        ///       "descricao": "Masculino",
        ///       "sequencia": 3
        ///     }
        /// </param>
        /// <returns>
        ///     {
        ///       "id": 32,
        ///       "campo": "TipoSexo",
        ///       "sigla": "OUT",
        ///       "descricao": "Masculino",
        ///       "sequencia": 3
        ///     }
        /// </returns>
        ///-----------------------------------------------------------//
        ///
        [HttpPost(Name ="IncluiDominio")]
        public async Task<ActionResult<Dominio>> Post(Dominio dominio)
        {
            context.Add(dominio);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetDominioById", new { id = dominio.Id }, dominio);
        }


        /// <summary>
        /// PUT:api/dominio/32 -  Altera um Dominio pelo Id contido no corpo da requisição 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dominio">Jason com a estrutura de um domínio com id a alterar 
        ///     {
        ///       "id": 32,
        ///       "campo": "TipoSexo",
        ///       "sigla": "OUT",
        ///       "descricao": "Outros",
        ///       "sequencia": 3
        ///     }
        /// </param>
        /// <returns>
        ///     {
        ///       "id": 32,
        ///       "campo": "TipoSexo",
        ///       "sigla": "OUT",
        ///       "descricao": "Outros",
        ///       "sequencia": 3
        ///     }
        /// </returns>
        /// 
        [HttpPut("{id}",Name ="AlteraDominio")]
        public async Task<ActionResult<Dominio>> Put(int id, Dominio dominio)
        {
            context.Entry(dominio).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(dominio);
        }


        /// <summary>
        /// DELETE:api/dominio/32 - Deleta um Dominio pelo Id
        /// </summary>
        /// <param name="id">Identificador que se deseja deletar</param>
        /// <returns>
        /// {
        ///   "id": 32,
        ///   "campo": null,
        ///   "sigla": null,
        ///   "descricao": null,
        ///   "sequencia": 0
        /// }
        /// </returns>
        /// 
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

