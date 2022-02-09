using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
                            ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png.)")]
        public string ImagemURL { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório."),
         StringLength(50, MinimumLength = 3,
                         ErrorMessage = "{0} deve conter um intervalo entre 3 a 50 caracteres.")]
        public string Tema { get; set; }

        [Display(Name = "Quantidade de pessoas.")]
        [Range(1, 120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000")]
        public int QtdPessoas { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Phone(ErrorMessage = "Digite um {0} válido")]
        public string Telefone { get; set; }

        [Display(Name = "e-mail"),
         Required(ErrorMessage = "O {0} é obrigatório."),
         EmailAddress(ErrorMessage = "Digite um {0} válido.")]
        public string Email { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}