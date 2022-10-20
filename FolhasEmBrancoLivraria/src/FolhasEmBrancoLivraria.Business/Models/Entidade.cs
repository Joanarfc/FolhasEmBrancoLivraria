using System;
using System.Collections.Generic;
using System.Text;

namespace FolhasEmBrancoLivraria.Business.Models
{
    public abstract class Entidade
    {
        public Guid Id { get; set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
