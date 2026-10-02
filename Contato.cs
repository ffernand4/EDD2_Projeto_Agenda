using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAgenda
{
    public class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public Data DtNasc
        {
            get => dtNasc;
            set => dtNasc = value;
        }

        public List<Telefone> Telefones => telefones;

        public Contato()
        {
            telefones = new List<Telefone>();
            dtNasc = new Data();
        }

        public Contato(string email)
        {
            this.email = email;
            this.telefones = new List<Telefone>();
            this.dtNasc = new Data();
        }

        public Contato(string email, string nome, Data dtNasc)
        {
            this.email = email;
            this.nome = nome;
            this.dtNasc = dtNasc;
            this.telefones = new List<Telefone>();
        }

        public int getIdade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - dtNasc.Ano;

            if (hoje.Month < dtNasc.Mes || (hoje.Month == dtNasc.Mes && hoje.Day < dtNasc.Dia))
            {
                idade--;
            }

            return idade < 0 ? 0 : idade;
        }

        public void adicionarTelefone(Telefone t)
        {
            if (t.Principal)
            {
                foreach (var tel in telefones)
                {
                    tel.Principal = false;
                }
            }
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            var telPrincipal = telefones.FirstOrDefault(t => t.Principal);
            if (telPrincipal != null)
            {
                return $"{telPrincipal.Tipo}: {telPrincipal.Numero}";
            }

            var primeiroTel = telefones.FirstOrDefault();
            return primeiroTel != null ? $"{primeiroTel.Tipo}: {primeiroTel.Numero}" : "Nenhum telefone cadastrado";
        }

        public override string ToString()
        {
            string infoTelefone = getTelefonePrincipal();
            return $"Nome: {nome} | E-mail: {email} | Nascimento: {dtNasc} ({getIdade()} anos) | Tel Principal: {infoTelefone}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato outro)
            {
                return string.Equals(this.email, outro.email, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return email != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(email) : 0;
        }
    }
}