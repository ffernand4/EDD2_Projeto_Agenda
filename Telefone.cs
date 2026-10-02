namespace ProjetoAgenda
{
    public class Telefone
    {
        private string tipo;
        private string numero;
        private bool principal;

        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public string Numero
        {
            get => numero;
            set => numero = value;
        }

        public bool Principal
        {
            get => principal;
            set => principal = value;
        }

        public Telefone() { }

        public Telefone(string tipo, string numero, bool principal = false)
        {
            this.tipo = tipo;
            this.numero = numero;
            this.principal = principal;
        }

        public override string ToString()
        {
            return $"{tipo}: {numero}" + (principal ? " (Principal)" : "");
        }
    }
}