using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Presentation.Models;
using AgendaEventos.Repository.Repositories;
using AgendaEventos.Repository.Entities;

namespace Agenda.Presentation.Controllers
{
	public class ClienteController : Controller
	{
		public IActionResult Cadastro()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Cadastro(CadastroEventoViewModel model, [FromServices] EventoRepositories eventoRepositories)
		   
		{
			try
			{
				if (ModelState.IsValid)
				{

					var evento = new Eventos
					{
						Nome = model.Nome,
						Descricao = model.Descricao,
						Data = model.Data,
						Hora = model.Hora,
						Local = model.Local,
						Participantes = model.Participantes,
						Tipo = model.Tipo

					};

					eventoRepositories.Inserir(evento);
				}


				TempData["MensagemSucesso"] = $"Cliente '{model.Nome}',cadastrado com sucesso!";
				ModelState.Clear();

			}
			catch(Exception e)
			{
				TempData["MensagemErro"] = "Ocorreu um erro: "+ e.Message;
			}
			
			return View();
		}

		public IActionResult Consulta()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Consulta(ConsultaEventosViewModel model, [FromServices] EventoRepositories eventoRepositories)
		{
			if (ModelState.IsValid)
			{

				try
				{

					var result = eventoRepositories.ObterPorData(model.Data);

					if(result.Count() > 0)
					{
						model.Eventos = result;

						TempData["MensagemSucesso"] = $"{result.Count()} Evento(s) obtidos com sucesso.";

					}
					else
					{
						TempData["MensagemAlerta"] = "Nenhum Registro encontrado!";

					}

				}

				catch(Exception e)
				{

					TempData["MensagemErro"] = e.Message;

				}

			}

			return View(model);

		}

		public IActionResult Edicao(Guid id, [FromServices] EventoRepositories eventoRepositories)
		{
			var model = new EdicaoEventosViewModel();

			try
			{
				TempData["indent"] = id;

				var evento = eventoRepositories.ObterPorId(id);

				model.id = evento.Id;
				model.Nome = evento.Nome;
				model.Data = evento.Data;
				model.Local = evento.Local;
				model.Participantes = evento.Participantes;
				model.Tipo = evento.Tipo;
				model.Descricao = evento.Descricao;
				model.Hora = evento.Hora;
			}

			catch(Exception e)
			{

				TempData["MensagemErro"] = e.Message;

			}

			return View(model);
		}

		[HttpPost]
		public IActionResult Edicao(EdicaoEventosViewModel model, [FromServices] EventoRepositories eventoRepositories)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var evento = new Eventos
					{
						Id = model.id,
						Nome = model.Nome,
						Data = model.Data,
						Local = model.Local,
						Participantes = model.Participantes,
						Tipo = model.Tipo,
						Descricao = model.Descricao,
						Hora = model.Hora

					};
					eventoRepositories.Alterar(evento);

					TempData["MensagemSucesso"] = $"Evento '{model.Nome}', atualizado com sucesso!";

				}
			}

			catch (Exception e)
			{
				TempData["MensagemErro"] = e.Message;

			}
		  
		
			return View();
		}


		public IActionResult Exclusao(Guid id, [FromServices] EventoRepositories eventoRepositories)
		{
			try { 
			var evento = eventoRepositories.ObterPorId(id);

			eventoRepositories.Excluir(evento);

			TempData["MensagemSucesso"] = $"Evento '{evento.Nome}' excluído com sucesso!";
			
			}

			catch(Exception e)
			{
				TempData["MensagemErro"] = e.Message;


			}

			return RedirectToAction("Consulta");
		}

	}
}
