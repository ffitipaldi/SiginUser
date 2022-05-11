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
    public class AgendaController : ControllerBase
    {
        //-------------------------------------------------//
        //Pega o contexto do banco de dados
        //-------------------------------------------------//
        private readonly ApplicationDbContext context;

        public AgendaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //---------------------------------------------------------//
        //GET:api/agenda -  lista todas as Agendas = GetAgendas
        //---------------------------------------------------------//
        [HttpGet(Name = "GetAgendas")]
        public async Task<ActionResult<List<Agenda>>> GetAgendas()
        {
            return await context.Agendas.AsNoTracking()
                .OrderBy(x => x.CpfProfissional )  
                .ThenBy(x => x.DataAgenda)
                .ToListAsync();
        }

        /// <summary>
        ///--------------------------------------------------------------------------------------------//
        /// GET:api/agenda/CpfProfisional/DataAgenda  -  Ler uma lita de Agendas pelos campos CPF e Data
        ///---------------------------------------------------------------------------------------------//
        /// </summary>
        [HttpGet("short/{cpfprofissional}/{datade}/{dataate}", Name = "GetAgendasShortByCpfData")]
        public async Task<ActionResult<List<Agenda>>> GetAgendasShortByCpfData(string cpfprofissional, string datade, string dataate)
        {
            var dataDe = Convert.ToDateTime(datade);
            var dataAte = Convert.ToDateTime(dataate).AddDays(1);

            return await context.Agendas
                //.Select (x => new { x.Id, x.DataAgenda, x.NomeCandidato, x.Telefone, x.StatusExPsico })
                .Where(x => x.CpfProfissional == cpfprofissional && x.DataAgenda >= dataDe && x.DataAgenda < dataAte)
                .OrderBy(x => x.DataAgenda)
                .ToListAsync();
        }


        /// <summary>
        ///--------------------------------------------------------------------------------------------//
        /// GET:api/agenda/CpfProfisional/DataAgenda  -  Ler uma lita de Agendas pelos campos CPF e Data
        ///---------------------------------------------------------------------------------------------//
        /// </summary>
        [HttpGet("{cpfprofissional}/{datade}/{dataate}", Name = "GetAgendasByCpfData")]
        public async Task<ActionResult<List<Agenda>>> GetAgendasByCpfData(string cpfprofissional, string datade, string dataate)
        {
            var dataDe = Convert.ToDateTime(datade);
            var dataAte = Convert.ToDateTime(dataate).AddDays(1);
            
            return await context.Agendas.AsNoTracking()
                .Where(x => x.CpfProfissional == cpfprofissional 
                       && x.DataAgenda >= dataDe && x.DataAgenda < dataAte)
                .OrderBy(x => x.DataAgenda)
                .ToListAsync();
        }
        
        /// <summary>
        ///-------------------------------------------------------------//
        ///GET:api/agenda/1  -  ler uma Agenda pelo Id = GetAgendaById
        ///-------------------------------------------------------------//
        /// </summary>
        [HttpGet("{id}", Name = "GetAgendaById")]
        public async Task<ActionResult<Agenda>> GetAgendaById(int id)
        {
            return await context.Agendas
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }


        /// <summary>
        ///-------------------------------------------------//
        /// POST:api/agnda  - Inclui uma nova Agenda
        ///-------------------------------------------------//
        /// </summary>
        [HttpPost(Name = "IncluiAgenda")]
        public async Task<ActionResult<Agenda>> Post(Agenda agenda)
        {
            context.Add(agenda);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetAgendaById", new { id = agenda.Id }, agenda);
        }

        /// <summary>
        ///-------------------------------------------------------------------------------//
        ///PUT:api/agenda/3 -  Altera uma Agenda pelo Id contido no corpo da requisição
        ///-------------------------------------------------------------------------------//
        /// </summary>
        [HttpPut("{id}", Name = "AlteraAgenda")]
        public async Task<ActionResult<Agenda>> Put(int id, Agenda agenda)
        {
            context.Entry(agenda).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(agenda);
        }

        /// <summary>
        ///-------------------------------------------------//
        ///Deleta uma Agenda pelo Id
        ///-------------------------------------------------//
        /// </summary>
        [HttpDelete("{id}", Name = "ExcluiAgenda")]
        public async Task<ActionResult<Agenda>> Delete(int id)
        {
            var agenda = new Agenda { Id = id };
            context.Remove(agenda);
            await context.SaveChangesAsync();
            return Ok(agenda);
        }
    }
}
