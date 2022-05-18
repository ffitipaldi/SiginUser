using SiginUser.Models;

namespace SiginUser.Data.Services
{
    public interface IAgendaService
    {
        Task<List<Agenda>> GetListAgendas();
        Task<Agenda> GetAgendaByIdAgenda(int Id);
        Task<bool> DeleteAgendaById(int Id);
    }
}
