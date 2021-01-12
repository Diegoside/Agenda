using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Presentation.Models
{
	public class EdicaoEventosViewModel : ConsultaEventosViewModel
	{

		public Guid id { get; set; }

		[MinLength(4, ErrorMessage = "Por favor, informe o nome do evento com no mínimo {1} caracteres.")]
		[MaxLength(100, ErrorMessage = "Por favor, informe o nome do evento com no máximo {1} caracteres.")]
		
		public string Nome { get; set; }

		[MinLength(4, ErrorMessage = "Por favor, informe um Evento com no mínimo {1} caracteres.")]
		[MaxLength(300, ErrorMessage = "Por favor, informe um Evento com no máximo {1} caracteres.")]
		
		public string Descricao { get; set; }

		[MinLength(5, ErrorMessage = "Por favor, informe um local com no mínimo {1} caracteres.")]
		[MaxLength(300, ErrorMessage = "Por favor, informe um local com no máximo {1} caracteres.")]
		
		public string Local { get; set; }

		[MinLength(4, ErrorMessage = "Por favor, informe o nome do participante com no mínimo {1} caracteres.")]
		[MaxLength(150, ErrorMessage = "Por favor, informe um participante com no máximo {1} caracteres.")]
		public string Participantes { get; set; }

		[Required(ErrorMessage = "Por Favor, Informe uma Data")]
		public DateTime Data { get; set; }


		[Required(ErrorMessage = "Por Favor, Informe o tipo do evento")]
		public int Tipo { get; set; }

		public DateTime Hora { get; set; }
	}
}
