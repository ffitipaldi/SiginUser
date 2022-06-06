using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SiginUser.Data;
using SiginUser.Models.Consultas;
using System.Data;

namespace SiginUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : Controller
    {
        //-------------------------------------------------//
        //Pega o contexto do banco de dados
        //-------------------------------------------------//
        private readonly SqlConnectionConfiguration _configuration;
        public ServicosController(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        ///---------------------------------------------------------------------------------------------//
        /// <summary>
        /// GET:api/Servicos/GetDataAgendasByCpf/{CpfProfisional}  
        ///     Ler uma lista de Data de Agenda pertencentes ao CPF
        /// </summary>
        /// <param name="cpfprofissional">Cpf do Profissional</param>
        /// <returns>
        ///     [
        ///       {
        ///         "dataAgenda": "2022-05-10T00:00:00"
        ///       },
        ///       {
        ///         "dataAgenda": "2022-06-25T00:00:00"
        ///       }
        ///     ]
        /// </returns>
        ///---------------------------------------------------------------------------------------------//
        /// 
        [HttpGet("GetDataAgendasByCpf/{cpfprofissional}", Name = "GetDataAgendasByCpf")]
        public async Task<ActionResult<List<DataAgendas>>> GetDataAgendasByCpf(string cpfprofissional)
        {
            List<DataAgendas> dataAgendas = new List<DataAgendas>();
            using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
            {
                const string query =
                    "Select  CAST(DataAgenda AS DATE) as DataConsulta " +
                    "From Agendas " +
                    "Where CpfProfissional = @CpfProfissional " +
                    "Group by  CAST(DataAgenda AS DATE) " +
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
                        DataAgenda = (DateTime)rdr["DataConsulta"]
                    };
                    dataAgendas.Add(dataagenda);
                }
                cmd.Dispose();
            }
            return dataAgendas;
        }


        /// <summary>
        /// Retorna um array de resumo de agendas
        /// </summary>
        /// <param name="cpfprofissional"></param>
        /// <param name="datade"></param>
        /// <param name="dataate"></param>
        /// <returns></returns>
        [HttpGet("GetResumoAgendasByCpfData/{cpfprofissional}/{datade}/{dataate}", Name = "GetResumoAgendasByCpfData")]
        public async Task<ActionResult<List<ResumoAgendas>>> GetResumoAgendasByCpfData(string cpfprofissional, string datade, string dataate)
        {
            List<ResumoAgendas> resumoAgendas = new List<ResumoAgendas>();
            using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
            {
                const string query =
                    "Select  Id, " +
		            "        HoraAgenda, " +
		            "        NomeCandidato, " +
		            "        Telefone, " +
		            "        StatusExPsico " +
                    "From Agendas " +
                    "Where CpfProfissional = @CpfProfissional " +
                    "    AND CAST(DataAgenda AS DATE) BETWEEN CAST(@DataDE as DATE) AND CAST(@DataATE as DATE) " +
                    "Order by DataAgenda ";

                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@CpfProfissional", cpfprofissional);
                cmd.Parameters.AddWithValue("@DataDE", datade);
                cmd.Parameters.AddWithValue("@DataATE", dataate);

                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    ResumoAgendas resumoagenda = new ResumoAgendas()
                    {
                        IdAgenda = (int)rdr["Id"],
                        HoraAgenda = (string)rdr["HoraAgenda"],
                        NomeCandidato = (string)rdr["NomeCandidato"],
                        Telefone = (string)rdr["Telefone"],
                        StatusExPsicoSigla = (string)rdr["StatusExPsico"]
                    };
                    resumoAgendas.Add(resumoagenda);
                }
                cmd.Dispose();
            }
            return resumoAgendas;
        }       
    }
}
