﻿using System.ComponentModel.DataAnnotations;

namespace ProAgil.Api.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim  { get; set; }
        [Range(2,120000, ErrorMessage = "O campo {0} de ter de 2 a 120000")]
        public int Quantidade { get; set; }

    }
}