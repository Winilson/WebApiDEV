using System.Linq;

namespace Business.Notificacoes
{
    public class Notificacao
    {
        public Notificacao(string menssagem)
        {
            Mensagem = menssagem;
        }
        public string Mensagem { get;}
    }
}
