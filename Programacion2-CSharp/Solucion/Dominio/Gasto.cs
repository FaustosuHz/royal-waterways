namespace Dominio
{
    public class Gasto : IValidar
    {
    public static int UltimoId { get; set; }
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion {  get; set; } 

     public Gasto()
     {
       Id = UltimoId;
       UltimoId++;
     }

    public Gasto(string nombre, string descripcion)
    {
       Id = UltimoId++;
       Nombre = nombre;
       Descripcion = descripcion;
    }

     public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
        }

     private void ValidarNombre()
     {
        if(string.IsNullOrEmpty(Nombre))
        { 
           throw new Exception("El nombre del gasto es obligatorio");
        }
     }

     private void ValidarDescripcion()
     {
         if (string.IsNullOrEmpty(Descripcion))
           {
              throw new Exception("La descripción no puede estar vacia");
           }
    }

     public override bool Equals(object obj)
      {
          if (obj is Gasto g)
           {
                return Nombre == g.Nombre;
           }
            else
           {
             return false;
           }
      }

   }
}