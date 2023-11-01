using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDB.DB
{
    internal class PersonaADO : ICRUDoperations<PersonaADO>
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public PersonaADO(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            ID = 0;
        }

        public PersonaADO(PersonaADO persona): this(persona.Nombre,persona.Apellido)
        {
            ID = persona.ID;
        }
        public bool Add()
        {
            return true;
        }

        public bool Delete()
        {
            return true;
        }

        public List<PersonaADO> Select()
        {
           
            return new List<PersonaADO>();
        }

        public bool Update()
        {
            return true;
        }
    }
}
