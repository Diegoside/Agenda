using AgendaEventos.Repository.Contracts;
using AgendaEventos.Repository.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AgendaEventos.Repository.Repositories
{
	public class EventoRepositories : EventoRepository
	{

		private readonly string connectionString;

		public EventoRepositories(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public void Alterar(Eventos obj)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Execute("SP_ALTERAR_EVENTO",
					new
					{
						_NOME = obj.Nome,
						_DESCRICAO = obj.Descricao,
						_LOCAL = obj.Local,
						_PARTICIPANTES = obj.Participantes,
						_DATA = obj.Data,
						_tipo = obj.Tipo,
						_HORA = obj.Hora

					},
					commandType: CommandType.StoredProcedure);


			}
		}

		public List<Eventos> Consultar()
		{
			var query = @"
			   SELECT
					IDEVENTO AS ID,
					NOME,
					DESCRICAO,
					LOCAL,
					PARTICIPANTES,
					DATA,
					TIPO,
					HORA,
			   FROM TBL_EVENTOS
					ORDER BY NOME ASC";
			
			using (var connection = new SqlConnection(connectionString))
			{
				return connection
				.Query<Eventos>(query)

				.ToList();

			}
		}

		public void Excluir(Eventos obj)
		{
			
			using (var connection = new SqlConnection(connectionString))
			{
				
				connection.Execute(
				"SP_EXCLUIR_EVENTO", 
				new 
{
					_IDEVENTO = obj.Id
				},
				commandType: CommandType.StoredProcedure);
			}
		}

		public void Inserir(Eventos obj)
		{
			using (var connection = new SqlConnection(connectionString))
			{

				connection.Execute("SP_INCLUIR_EVENTO",
					new
					{
						_NOME = obj.Nome,
						_DESCRICAO = obj.Descricao,
						_LOCAL = obj.Local,
						_PARTICIPANTES = obj.Participantes,
						_DATA = obj.Data,
						_tipo = obj.Tipo,
						_HORA = obj.Hora

					},
					commandType : CommandType.StoredProcedure);

			}
		}

		public List<Eventos> ObterPorData(DateTime data)
		{
			var query = @"
			SELECT
					IDEVENTO AS ID,
					NOME,
					DESCRICAO,
					LOCAL,
					PARTICIPANTES,
					DATA,
					TIPO,
					HORA
			FROM TBL_EVENTOs
					WHERE DATA = @_DATA
							ORDER BY DATA ASC";
			//conectando no banco de dados e executando a query..
			using (var connection = new SqlConnection(connectionString))
			{
				return connection
				.Query<Eventos>(query, new

				{

					_DATA = data
				})
				.ToList();

			}
		}

		public Eventos ObterPorId(Guid id)
		{
			var query = @"
				SELECT
						IDEVENTO AS ID,
						NOME,
					DESCRICAO,
					LOCAL,
					PARTICIPANTES,
					DATA,
					TIPO,
					HORA
		       FROM TBL_EVENTOS
						WHERE IDEVENTO = @_ID";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection
					  .Query<Eventos>(query, new
					  {
						  _ID = id
					  })
						.FirstOrDefault();
			}
		}

		SqlMapper.Identity IBaseRepository<Eventos>.ObterPorId(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}


