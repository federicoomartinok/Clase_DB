using PruebaDB.DB;

namespace PruebaDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persona = new PersonaADO("Maria", "gaga");

            persona.Add();

            persona.Nombre = "Juana";

            persona.Update();


            
            DB.Db.Insert("Ernesto", "Arriaga");
            DB.Db.Select();

        }
    }
}