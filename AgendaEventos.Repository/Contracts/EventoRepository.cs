using AgendaEventos.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Dapper.SqlMapper;

namespace AgendaEventos.Repository.Contracts
{
	public interface EventoRepository : IBaseRepository<Eventos>
	{

		List<Eventos> ObterPorData(DateTime data);

		

	}
}
