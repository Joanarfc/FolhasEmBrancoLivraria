﻿using FolhasEmBrancoLivraria.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FolhasEmBrancoLivraria.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

    }
}
