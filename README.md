# Projeto Agenda de Contatos

**Instituição:** Instituto Federal de Educação, Ciência e Tecnologia de São Paulo — Campus Cubatão  
**Curso:** Tecnologia em Análise e Desenvolvimento de Sistemas  
**Disciplina:** Estrutura de Dados 2 (CBTEDD2)  
**Tópico:** Listas em C# (Console Application)  
**Semana:** 6 — 10/09/2026  

---

## Descrição do Projeto

O **Projeto Agenda** é uma aplicação em console desenvolvida em C# para o gerenciamento de contatos pessoais. O sistema permite cadastrar contatos contendo informações fundamentais como nome, e-mail, data de nascimento e múltiplos números de telefone com indicação de linha principal.

## Funcionalidades

1. **Adicionar Contato:** Cadastra um novo contato com e-mail único, data de nascimento e uma lista de telefones associados.
2. **Pesquisar Contato:** Localiza e exibe todos os detalhes de um contato a partir do e-mail informado.
3. **Alterar Contato:** Atualiza as informações (nome, data de nascimento e telefones) de um contato existente.
4. **Remover Contato:** Remove o contato informado da agenda.
5. **Listar Contatos:** Exibe relatórios formatados de todos os contatos cadastrados, incluindo idade calculada dinamicamente e telefone principal.

---

## Estrutura das Classes (UML)

```text
+--------------------------------------------+
| Data                                       |
+--------------------------------------------+
| - dia: int                                 |
| - mes: int                                 |
| - ano: int                                 |
+--------------------------------------------+
| + setData(int dia, int mes, int ano): void |
| + ToString(): String (override)            |
+--------------------------------------------+

+-------------------+
| Telefone          |
+-------------------+
| - tipo: string    |
| - numero: string  |
| - principal: bool |
+-------------------+

+------------------------------------------+
| Contato                                  |
+------------------------------------------+
| - email: string                          |
| - nome: string                           |
| - dtNasc: Data                           |
| - telefones: List<Telefone>              |
+------------------------------------------+
| + getIdade(): int                        |
| + adicionarTelefone(Telefone t): void    |
| + getTelefonePrincipal(): string         |
| + ToString(): String (override)          |
| + Equals(object obj): bool (override)    |
+------------------------------------------+

+------------------------------------+
| Contatos                           |
+------------------------------------+
| - agenda: List<Contato> (readOnly) |
+------------------------------------+
| + adicionar(Contato c): bool       |
| + pesquisar(Contato c): Contato    |
| + alterar(Contato c): bool         |
| + remover(Contato c): bool         |
+------------------------------------+
```

---

## Como Executar

### Pré-requisitos
- **SDK do .NET Core 6.0 ou superior**
- **Visual Studio 2022** / **Visual Studio Code** com extensão C#

### Passo a passo
1. Clone ou faça o download dos arquivos do projeto.
2. Abra o terminal no diretório do projeto onde está localizado o arquivo `.csproj`.
3. Execute o comando de compilação e execução:
   ```bash
   dotnet run
   ```
## Código-Fonte Completo (C#)

### `Data.cs`
```csharp
using System;

namespace ProjetoAgenda
{
    public class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public int Dia
        {
            get => dia;
            set => dia = value;
        }

        public int Mes
        {
            get => mes;
            set => mes = value;
        }

        public int Ano
        {
            get => ano;
            set => ano = value;
        }

        public Data() { }

        public Data(int dia, int mes, int ano)
        {
            setData(dia, mes, ano);
        }

        public void setData(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public override string ToString()
        {
            return $"{dia:D2}/{mes:D2}/{ano:D4}";
        }
    }
}
Telefone.cs
