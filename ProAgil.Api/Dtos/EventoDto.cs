using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.Api.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Local não pode ser nulo.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local deve ter entre 3 a 100 caracteres")]
        public string Local { get; set; }
        
        [Required(ErrorMessage = "Data do evento não pode ser nulo")]
        public string DataEvento { get; set; }
       
        [Required(ErrorMessage = "O Tema não pode ser nulo")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tema deve ter no mínimo 3 caracteres")]
        public string Tema { get; set; }
        
        [Range(2,10000, ErrorMessage = "Quantidade de pessoas deve ter de 2 a 10000")]
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string  Telefone { get; set; }
        
        [EmailAddress(ErrorMessage = "O campo Email não é um endereço de email válido.")]
        public string  Email { get; set; }
        
        public List<LoteDto> Lotes{ get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}