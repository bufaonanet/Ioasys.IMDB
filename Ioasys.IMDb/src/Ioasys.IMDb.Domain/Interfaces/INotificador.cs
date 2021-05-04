using Ioasys.IMDb.Domain.Notifications;
using System.Collections.Generic;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface INotificador
    {
        public void AdicionarNotificacao(Notificacao notificacao);

        public List<Notificacao> ObterNotificacoes();

        public bool TemNotificacao();
        
    }
}
