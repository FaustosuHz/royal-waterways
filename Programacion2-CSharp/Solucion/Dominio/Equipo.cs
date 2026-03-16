namespace Dominio
{
    public class Equipo : IValidar
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Equipo()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Equipo(string nombre) {
            Id = UltimoId++;
            Nombre = nombre;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre del equipo no puede estar vacio");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Equipo e)
            {
                return Nombre == e.Nombre;
            }
            else
            {
                return false;
            }
        }

   }
}
