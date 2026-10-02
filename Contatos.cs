using System.Collections.Generic;
using System.Linq;

namespace ProjetoAgenda
{
    public class Contatos
    {
        private readonly List<Contato> agenda;

        public List<Contato> Agenda => agenda;

        public Contatos()
        {
            agenda = new List<Contato>();
        }

        public bool adicionar(Contato c)
        {
            if (pesquisar(c) != null)
            {
                return false;
            }
            agenda.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            return agenda.FirstOrDefault(item => item.Equals(c));
        }

        public bool alterar(Contato c)
        {
            Contato existente = pesquisar(c);
            if (existente == null)
            {
                return false;
            }

            existente.Nome = c.Nome;
            existente.DtNasc = c.DtNasc;

            if (c.Telefones.Count > 0)
            {
                existente.Telefones.Clear();
                foreach (var tel in c.Telefones)
                {
                    existente.adicionarTelefone(tel);
                }
            }

            return true;
        }

        public bool remover(Contato c)
        {
            Contato existente = pesquisar(c);
            if (existente != null)
            {
                return agenda.Remove(existente);
            }
            return false;
        }
    }
}