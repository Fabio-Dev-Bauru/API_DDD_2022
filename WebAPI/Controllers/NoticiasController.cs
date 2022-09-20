using Aplicacao.Interfaces;
using Entidades.Entidades;
using Entidades.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly IAplicacaoNoticia _IAplicacaoNoticia;

        public NoticiasController(IAplicacaoNoticia IAplicacaoNoticia)
        {
            _IAplicacaoNoticia = IAplicacaoNoticia;
        }


        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListarNoticias")]
        public async Task<List<Noticia>> ListarNoticias()
        {
            return await _IAplicacaoNoticia.ListarNoticiasAtivas();
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaNoticia")]
        public async Task<List<Notifica>> AdicionaNoticia(NoticiaModel noticia)
        {
            var noticiaNova = new Noticia()
            {
                Titulo = noticia.Titulo,
                Informacao = noticia.Informacao,
                UserId = await RetornaIdUsuarioLogado(),
            };

            await _IAplicacaoNoticia.AdicionaNoticia(noticiaNova);

            return noticiaNova.Notificacoes;

        }


        private async Task<string> RetornaIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            else
            {
                return string.Empty;
            }
        }

    }
}
