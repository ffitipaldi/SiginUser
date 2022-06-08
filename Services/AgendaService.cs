using SiginUser.Models;
using System.Data;
using System.Data.SqlClient;

namespace SiginUser.Data.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly ApplicationDbContext _context;

        public AgendaService(ApplicationDbContext context)
        {
            this._context = context;
        }


        public Task<bool> DeleteAgendaById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> GetAgendaByIdAgenda(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Agenda>> GetListAgendas()
        {
            throw new NotImplementedException();
        }
    }
}
