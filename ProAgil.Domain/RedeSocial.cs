namespace ProAgil.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string NomeRedeSocial { get; set; }
        public string Url { get; set; }
        public int? EventoId { get; set; }
        public int? PalestranteId { get; set; }
        public Evento Evento { get; }
        public Palestrante Palestrante { get; }
        
    }
}