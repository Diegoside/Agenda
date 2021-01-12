using System;
using System.Collections.Generic;
using System.Text;
using static Dapper.SqlMapper;

namespace AgendaEventos.Repository.Contracts
{
	public interface IBaseRepository<T>
	{
		void Inserir(T obj);
		void Alterar(T obj);
		void Excluir(T obj);

		List<T> Consultar();
		Identity ObterPorId(Guid id);




	}
}
