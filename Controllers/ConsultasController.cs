using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SiginUser.Data;
using SiginUser.Models.Consultas;
using System.Data;

namespace SiginUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : Controller
    {
        //-------------------------------------------------//
        //Pega o contexto do banco de dados
        //-------------------------------------------------//
        private readonly SqlConnectionConfiguration _configuration;
        public ConsultasController(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        ///---------------------------------------------------------------------------------------------//
        /// TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#
        /// <summary>
        /// GET:api/agenda/CpfProfisional/DataAgenda  -  Ler uma lita de Agendas pelos campos CPF e Data
        /// </summary>
        /// <param name="cpfprofissional">Cpf do Profissional</param>
        /// <returns>
        /// </returns>
        /// TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#TESTE#
        ///---------------------------------------------------------------------------------------------//
        /// 
        [HttpGet("GetDataAgendasByCpf/{cpfprofissional}", Name = "GetDataAgendasByCpf")]
        public async Task<ActionResult<List<DataAgendas>>> GetDataAgendasByCpf(string cpfprofissional)
        {
            List<DataAgendas> dataAgendas = new List<DataAgendas>();
            using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
            {
                const string query =
                    "Select convert(varchar(10),DataAgenda, 103) as DataConsulta " +
                    "From  Agendas " +
                    "Where CpfProfissional = @CpfProfissional " +
                    "Group by convert(varchar(10), DataAgenda, 103) " +
                    "Order by DataConsulta ";

                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@CpfProfissional", cpfprofissional);

                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    DataAgendas dataagenda = new DataAgendas()
                    {
                        DataAgenda = rdr["DataConsulta"].ToString() 
                        //DataAgenda = (DateTime)rdr["DataConsulta"]
                    };
                    dataAgendas.Add(dataagenda);
                }
                cmd.Dispose();
            }
            return dataAgendas;
        }
    }
}
