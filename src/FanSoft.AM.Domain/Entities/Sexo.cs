using System.Collections.Generic;

namespace FanSoft.AM.Domain.Entities
{
    public class Sexo : Entity
    {
        protected Sexo() { }

        public Sexo(string genero) => Genero = genero;
        public Sexo(int id, string genero)
        {
            Id = id;
            Genero = genero;
        }

        public string Genero { get; private set; }

        public IReadOnlyList<Paciente> Pacientes { get; private set; }
    }
}
