namespace SiginUser.Models.Consultas
{
    public class ResumoAgendasMes
    {
        public int IdAgenda { get; set; }
        public DateTime DataAgenda { get; set; }
        public string? HoraAgenda { get; set; }
        public string? NomeCandidato { get; set; }
        public string? Telefone { get; set; }
        public string? TipoProcesso { get; set; }
        public string? StatusExPsicoSigla { get; set; }
    }
}
