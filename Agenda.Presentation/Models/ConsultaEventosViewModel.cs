using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AgendaEventos.Repository.Entities;

namespace Agenda.Presentation.Models
{
	public class ConsultaEventosViewModel
	{

		[Required(ErrorMessage = "Por favor informe uma data ")]
		public DateTime Data { get; set; }


		public List<Eventos> Eventos { get; set; }
	}
}
