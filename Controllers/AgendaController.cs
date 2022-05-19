using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiginUser.Data;
using SiginUser.Models;
using SiginUser.Models.Consultas;
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


        ///---------------------------------------------------------//
        /// <summary>
        /// GET:api/agenda -  lista todas as Agendas = GetAgendas        
        /// </summary>
        /// <returns>
        ///     [
        ///       {
        ///         "id": 1,
        ///         "tipoPerfil": "PSICO",
        ///         "cpfProfissional": "30381498883",
        ///         "dataAgenda": "2022-05-10T08:00:00",
        ///         "horaAgenda": "08:00",
        ///         "dataAgendaDetran": "2022-05-10T08:00:00",
        ///         "horaAgendaDetran": "08:00",
        ///         "cpfCandidato": "35502471845",
        ///         "nomeCandidato": "Jessica Vanessa Ferreira Dos Santos",
        ///         "telefone": "(11) 9488-86131",
        ///         "emailCandidato": "jessicaVFS@uol.com.br",
        ///         "tipoProcesso": "PRIHAB",
        ///         "categoria": "AB",
        ///         "statusExMedico": "NAOREALIZD",
        ///         "statusExPsico": "NAOREALIZD"
        ///       }
        ///     ]
        /// </returns>
        ///---------------------------------------------------------//
        /// 
        [HttpGet(Name = "GetAgendas")]
        public async Task<ActionResult<List<Agenda>>> GetAgendas()
        {
            return await context.Agendas.AsNoTracking()
                .OrderBy(x => x.CpfProfissional )  
                .ThenBy(x => x.DataAgenda)
                .ToListAsync();
        }



        ///---------------------------------------------------------------------------------------------//
        /// TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#
        /// <summary>
        /// GET:api/agenda/CpfProfisional/DataAgenda  -  Ler uma lita de Agendas pelos campos CPF e Data
        /// </summary>
        /// <param name="cpfprofissional">Cpf do Profissional</param>
        /// <param name="datade"> Data DE (início do intervalo a ser listado)</param>
        /// <param name="dataate">Data ATE (final do intervalo a ser listado)</param>
        /// <returns>
        /// </returns>
        /// TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#
        ///---------------------------------------------------------------------------------------------//
        /// 
        //[HttpGet("list/{cpfprofissional}", Name = "GetDataAgendasByCpf")]
        //public async Task<ActionResult<List<Agendas>>> GetDataAgendasByCpf(string cpfprofissional)
        //{
        //    return await context.Agendas
        //        .Where(x => x.CpfProfissional == cpfprofissional)
        //        //.Select(x => new { x.Id, x.DataAgenda })
        //        ////.GroupBy (x => x.DataAgenda)
        //        //.OrderBy(x => x.DataAgenda)
        //        .ToListAsync();
        //}



        ///---------------------------------------------------------------------------------------------//
        /// <summary>
        /// GET:api/agenda/CpfProfisional/DataAgenda  -  Ler uma lita de Agendas pelos campos CPF e Data
        /// </summary>
        /// <param name="cpfprofissional">Cpf do Profissional</param>
        /// <param name="datade"> Data DE (início do intervalo a ser listado)</param>
        /// <param name="dataate">Data ATE (final do intervalo a ser listado)</param>
        /// <returns>
        ///     [
        ///       {
        ///         "id": 1,
        ///         "tipoPerfil": "PSICO",
        ///         "cpfProfissional": "30381498883",
        ///         "dataAgenda": "2022-05-10T08:00:00",
        ///         "horaAgenda": "08:00",
        ///         "dataAgendaDetran": "2022-05-10T08:00:00",
        ///         "horaAgendaDetran": "08:00",
        ///         "cpfCandidato": "35502471845",
        ///         "nomeCandidato": "Jessica Vanessa Ferreira Dos Santos",
        ///         "telefone": "(11) 9488-86131",
        ///         "emailCandidato": "jessicaVFS@uol.com.br",
        ///         "tipoProcesso": "PRIHAB",
        ///         "categoria": "AB",
        ///         "statusExMedico": "NAOREALIZD",
        ///         "statusExPsico": "NAOREALIZD"
        ///       }
        ///     ]
        /// </returns>
        ///---------------------------------------------------------------------------------------------//
        /// 
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


        ///-------------------------------------------------------------//
        /// <summary>
        /// GET:api/agenda/1  -  ler uma Agenda pelo Id = GetAgendaById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///       {
        ///         "id": 1,
        ///         "tipoPerfil": "PSICO",
        ///         "cpfProfissional": "30381498883",
        ///         "dataAgenda": "2022-05-10T08:00:00",
        ///         "horaAgenda": "08:00",
        ///         "dataAgendaDetran": "2022-05-10T08:00:00",
        ///         "horaAgendaDetran": "08:00",
        ///         "cpfCandidato": "35502471845",
        ///         "nomeCandidato": "Jessica Vanessa Ferreira Dos Santos",
        ///         "telefone": "(11) 9488-86131",
        ///         "emailCandidato": "jessicaVFS@uol.com.br",
        ///         "tipoProcesso": "PRIHAB",
        ///         "categoria": "AB",
        ///         "statusExMedico": "NAOREALIZD",
        ///         "statusExPsico": "NAOREALIZD"
        ///       }
        /// </returns>
        ///-------------------------------------------------------------//
        ///
        [HttpGet("{id}", Name = "GetAgendaById")]
        public async Task<ActionResult<Agenda>> GetAgendaById(int id)
        {
            return await context.Agendas
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }



        ///-------------------------------------------------//
        /// <summary>
        /// POST:api/agnda  - Inclui uma nova Agenda
        /// </summary>
        /// <param name="agenda"> JSON com a estrutura da Agenda com ID = 0
        ///     {
        ///       "id": 0,
        ///       "tipoPerfil": "PSICO",
        ///       "cpfProfissional": "30381498883",
        ///       "dataAgenda": "2022-05-10T09:00:00",
        ///       "horaAgenda": "09:00",
        ///       "dataAgendaDetran": "2022-05-10T09:00:00",
        ///       "horaAgendaDetran": "09:00",
        ///       "cpfCandidato": "25586149400",
        ///       "nomeCandidato": "Fernando Luiz Azevêdo Fitipaldi",
        ///       "telefone": "(11) 93240-3415",
        ///       "emailCandidato": "ffitipaldi@gmail.com",
        ///       "tipoProcesso": "RENOV",
        ///       "categoria": "AB",
        ///       "statusExMedico": "NAOREALIZD",
        ///       "statusExPsico": "NAOREALIZD"
        ///     }
        /// </param>
        /// <returns>
        ///     {
        ///       "id": 2,
        ///       "tipoPerfil": "PSICO",
        ///       "cpfProfissional": "30381498883",
        ///       "dataAgenda": "2022-05-10T09:00:00",
        ///       "horaAgenda": "09:00",
        ///       "dataAgendaDetran": "2022-05-10T09:00:00",
        ///       "horaAgendaDetran": "09:00",
        ///       "cpfCandidato": "25586149400",
        ///       "nomeCandidato": "Fernando Luiz Azevêdo Fitipaldi",
        ///       "telefone": "(11) 93240-3415",
        ///       "emailCandidato": "ffitipaldi@gmail.com",
        ///       "tipoProcesso": "RENOV",
        ///       "categoria": "AB",
        ///       "statusExMedico": "NAOREALIZD",
        ///       "statusExPsico": "NAOREALIZD"
        ///     }
        /// </returns>
        ///-------------------------------------------------//
        ///
        [HttpPost(Name = "IncluiAgenda")]
        public async Task<ActionResult<Agenda>> Post(Agenda agenda)
        {
            context.Add(agenda);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetAgendaById", new { id = agenda.Id }, agenda);
        }


        ///-------------------------------------------------------------------------------//
        /// <summary>
        /// PUT:api/agenda/2 -  Altera uma Agenda pelo Id contido no corpo da requisição
        /// </summary>
        /// <param name="id">
        ///     {
        ///       "id": 2,
        ///       "tipoPerfil": "PSICO",
        ///       "cpfProfissional": "30381498883",
        ///       "dataAgenda": "2022-05-10T09:00:00",
        ///       "horaAgenda": "09:00",
        ///       "dataAgendaDetran": "2022-05-10T09:00:00",
        ///       "horaAgendaDetran": "09:00",
        ///       "cpfCandidato": "25586149400",
        ///       "nomeCandidato": "Fernando Luiz Azevêdo Fitipaldi",
        ///       "telefone": "(11) 93240-3415",
        ///       "emailCandidato": "ffitipaldi@gmail.com",
        ///       "tipoProcesso": "RENOV",
        ///       "categoria": "C",
        ///       "statusExMedico": "NAOREALIZD",
        ///       "statusExPsico": "NAOREALIZD"
        ///     }
        /// </param>
        /// <param name="agenda"></param>
        /// <returns>
        ///     {
        ///       "id": 2,
        ///       "tipoPerfil": "PSICO",
        ///       "cpfProfissional": "30381498883",
        ///       "dataAgenda": "2022-05-10T09:00:00",
        ///       "horaAgenda": "09:00",
        ///       "dataAgendaDetran": "2022-05-10T09:00:00",
        ///       "horaAgendaDetran": "09:00",
        ///       "cpfCandidato": "25586149400",
        ///       "nomeCandidato": "Fernando Luiz Azevêdo Fitipaldi",
        ///       "telefone": "(11) 93240-3415",
        ///       "emailCandidato": "ffitipaldi@gmail.com",
        ///       "tipoProcesso": "RENOV",
        ///       "categoria": "C",
        ///       "statusExMedico": "NAOREALIZD",
        ///       "statusExPsico": "NAOREALIZD"
        ///     }
        /// </returns>
        ///-------------------------------------------------------------------------------//
        ///
        [HttpPut("{id}", Name = "AlteraAgenda")]
        public async Task<ActionResult<Agenda>> Put(int id, Agenda agenda)
        {
            context.Entry(agenda).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(agenda);
        }



        ///-------------------------------------------------//
        /// <summary>
        /// DELETE: api/agenda/3 - Deleta uma Agenda pelo Id
        /// </summary>
        /// <param name="id">Identificador da Agenda que se deseja excluir</param>
        /// <returns>
        ///     {
        ///        "id": 4,
        ///        "tipoPerfil": null,
        ///        "cpfProfissional": null,
        ///        "dataAgenda": "0001-01-01T00:00:00",
        ///        "horaAgenda": null,
        ///        "dataAgendaDetran": "0001-01-01T00:00:00",
        ///        "horaAgendaDetran": null,
        ///        "cpfCandidato": null,
        ///        "nomeCandidato": null,
        ///        "telefone": null,
        ///        "emailCandidato": null,
        ///        "tipoProcesso": null,
        ///        "categoria": null,
        ///        "statusExMedico": null,
        ///        "statusExPsico": null
        ///      }
        /// </returns>
        ///-------------------------------------------------//
        /// 
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
