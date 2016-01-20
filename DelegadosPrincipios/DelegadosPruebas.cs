using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegadosPrincipios
{
    public class Producto
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public decimal Precio{get;set;}
    }

    public delegate void DelProducto(Producto p);

    class DelegadosPruebas
    {
        private static Producto P;
        public static void CreaProducto(Producto p)
        {
            P=p;
        }

        public static void Procesador(DelProducto dp)
        {
            dp(P);
        }

        public static bool Procesador2(Func<Producto,bool> fp)
        {
            return fp(P);
        }

        public static void Procesador3(Action<Producto> ap)
        {
            ap(P);
        }

        public static bool Procesador4(System.Linq.Expressions.Expression<Func<Producto,bool>> exp)
        {
            Func<Producto,bool> del= exp.Compile();
            return del(P);
        }
    }
}
