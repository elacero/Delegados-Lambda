using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegadosPrincipios
{
    class Program
    {
        static void Main(string[] args)
        {
            Producto nuevo = new Producto()
            {
                Id = 1,
                Nombre = "Platano",
                Precio = 2
            };

            DelegadosPruebas.CreaProducto(nuevo);
            //Versión C#1.0

            DelProducto midelegado = new DelProducto(miprocesado);
            DelegadosPruebas.Procesador(midelegado);
            DelProducto midelegado2 = new DelProducto(miprocesado2);
            DelegadosPruebas.Procesador(midelegado2);

            //A partir de la versión 2.0 de C#
            DelegadosPruebas.Procesador(miprocesado2);

            //También permitimos métodos anónimos
            DelProducto delegado = delegate(Producto pr)
            {
                Console.WriteLine("Este es un delegado con método anónimo. Su precio es {0}", pr.Precio);
                Console.ReadLine();
            };
            DelegadosPruebas.Procesador(delegado);

            //Versión C# 3.0
            DelProducto delegado2 = pr =>
            {
                Console.WriteLine("Este es un delegado con función lambda. Su precio es {0}", pr.Precio);
                Console.ReadLine();
            };
            DelegadosPruebas.Procesador(delegado2);

            //Aparece la clase FUNC que encapsula un delegado
            //Recibe un parámetro tipo Producto y devuelve un booleano (el último)

            Func<Producto, bool> delegado3 = pr =>
            {
                Console.WriteLine("Este es un delegado con función lambda. Su precio es {0}", pr.Precio);
                Console.ReadLine();
                return true;
            };
            DelegadosPruebas.Procesador2(delegado3);

            //Action para delegados que no devuelven nada
            Action<Producto> delegado4 = pr =>
            {
                Console.WriteLine("Este es un delegado con función lambda. Su precio es {0}", pr.Precio);
                Console.ReadLine();
            };
            DelegadosPruebas.Procesador3(delegado4);

            //Arbol de expresiones Syste.Linq.Expressions solo admiten como método anonimos expresiones
            System.Linq.Expressions.Expression<Func<Producto, bool>> expresion = pr => pr.Precio > 5;
            DelegadosPruebas.Procesador4(expresion);
        }

        public static void miprocesado(Producto p)
        {
            System.Console.WriteLine("El precio del producto es {0}", p.Precio);
            Console.ReadLine();
        }

        public static void miprocesado2(Producto p)
        {
            System.Console.WriteLine("Nombre: {0}, Precio: {1}",p.Nombre,p.Precio);
            Console.ReadLine();
        }
    }
}

/******************************* Enlaces *********************************/
// http://www.variablenotfound.com/2009/03/c-desmitificando-las-expresiones-lambda_29.html
// http://www.variablenotfound.com/2009/03/c-desmitificando-las-expresiones-lambda_2829.html
// https://msdn.microsoft.com/es-es/library/bb397687.aspx