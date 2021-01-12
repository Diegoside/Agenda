using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaEventos.Repository.Entities
{
	public class Eventos
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string  Descricao { get; set; }
		public string Local { get; set; }
		public string Participantes { get; set; }
		public DateTime Data { get; set; }
		public int Tipo { get; set; }
		public DateTime Hora { get; set; }
	}
}
