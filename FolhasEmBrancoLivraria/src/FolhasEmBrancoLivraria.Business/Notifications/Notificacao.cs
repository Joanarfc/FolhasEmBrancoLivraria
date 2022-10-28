using System;
using System.Text;

namespace FolhasEmBrancoLivraria.Business.Notifications
{
    public class Notificacao
    {
        public string Mensagem { get; }

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

    }
}
