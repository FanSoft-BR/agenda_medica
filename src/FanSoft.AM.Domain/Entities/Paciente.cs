using System;

namespace FanSoft.AM.Domain.Entities
{
    public class Paciente : Entity
    {
        public Paciente(string nome, string sobrenome, DateTime nascimento, int sexoId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
            SexoId = sexoId;
        }

        public Paciente(int id, string nome, string sobrenome, DateTime nascimento, int sexoId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
            SexoId = sexoId;
        }

        protected Paciente() { }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public string NomeCompleto => $"{Nome} {Sobrenome}";
        public DateTime Nascimento { get; private set; }

        public int SexoId { get; private set; }
        public Sexo Sexo { get; private set; }

        public void Atualizar(string nome, string sobrenome, DateTime nascimento, int sexoId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
            SexoId = sexoId;
        }
    }
}
