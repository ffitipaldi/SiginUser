namespace SiginUser.Models.Consultas
{
    public class ResumoAgendas
    {
        public int IdAgenda { get; set; }
        public string? HoraAgenda { get; set; }
        public string? NomeCandidato { get; set; }
        public string? Telefone { get; set; }
        public string? StatusExPsicoSigla { get; set; }
        public bool FlagCandidatoCompareceu { get; set; }
    }
}
