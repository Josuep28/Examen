using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    internal class Program
    {
        static bool ValidarDatos(double precio, int cantidad)
        {
            if (precio > 0 && cantidad > 0)
            {
                return true;
            }
            return true;
            Console.WriteLine("ERROR: El precio debe ser mayor a $0 y la cantidad mayor a 0.");
            return false;
        }
        static void ImprimirMatrizDatos(double[,] matriz, string[] codigos) 
        {
            Console.WriteLine("---MATRIZ BIDIMENSIAL DE DATOS (PRECIO Y CANTIDAD)---");
            Console.WriteLine("Fila | Código | Col 0 (Precio $) | Col 1 (Cantidad)");
            Console.WriteLine("-----------------------------------------------------");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("[{0}]   |{1}|${2,12:N2} |{3,18}", i, codigos[i] , matriz[i, 0] , matriz[i, 1]);
            }
        }
        static void BuscadorCodigo(string[] codigos, string[] modelos, double[] montos, string codigoBuscado) 
        {
            if (codigoBuscado == "") 
            {
                Console.WriteLine("ERROR: La entrada esta vacía.");
                return;
            }
            for (int i = 0; i < 6; i++) 
            {
                if (codigos[i] == codigoBuscado) 
                {
                    Console.WriteLine(" Buscando '{0}':!ENCONTRADO¡ Modelo :{1} | Monto: ${2:N2}", codigoBuscado, modelos[i], montos[i]);
                    return;
                }
            }
            Console.WriteLine(" Buscando '{0}': ERROR, código no registrado.", codigoBuscado);

        }
        static void Main(string[] args)
        {
            string[] codigos = { "AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206" };
            string[] modelo = { "SUV Interceptor", "Sedan Executive", "PickUp Titan", "City Hatchback", "Electric EV", "Van Carga" };

            double[,] datos = {    
                
                { 28000.0,  2 },
                { 18500.0,  4 },
                { 35000.0,  1 },
                { 14000.0,  5 },
                { 42000.0,  1 },
                { 22500.0,  3 }
            };
            double[] montosNetos = new double[6];
            double granTotal = 0.0;
            int VentasPremiun = 0;

            for (int i = 0; i < 6; i++) 
            {
                if (ValidarDatos(datos[i,0], (int)datos[i, 1]))
                    {
                        montosNetos[i] = datos[i, 0] * datos[i, 1];
                        granTotal += montosNetos[i];

                    if (montosNetos[i] > 50000)
                    {
                        VentasPremiun++;
                    }

                }
            }
            ImprimirMatrizDatos(datos, codigos);
            Console.WriteLine();

            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 5 - 1; j++) 
                {
                    if (montosNetos[j] < montosNetos[j + 1]) 
                    {
                        double auxMonto = montosNetos[j];
                        montosNetos[j] = montosNetos[j + 1];
                        montosNetos[j + 1] = auxMonto;

                        string auxCodigo = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = auxCodigo;

                        string auxModelo = modelo[j];
                        modelo[j] = modelo[j + 1];
                        modelo[j + 1] = auxModelo;

                        for (int c = 0; c < 2; c++) 
                        {
                            double auxDato = datos[j, c];
                            datos[j, c] = datos[j + 1, c];
                            datos[j + 1, c] = auxDato;
                        }
                    }
                }
            }
            Console.WriteLine("---REPORTE ORDENADO POR MONTO NETO (DECRECIENTE)---");
            for (int i = 0; i < 6; i++) 
            {
                Console.WriteLine("{0}.Código: {1} | Modelo: {2,-15} | Monto: ${3,10:N2}", i+1, codigos[i], modelo[i], montosNetos[i]);
            }
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("METRICAS RESUMEN:");
                Console.WriteLine(" *Gran Total Acumulado         :${0:N2}", granTotal);
                Console.WriteLine(" *Ventas Premiun (>$50.000):{0}transacciones", VentasPremiun);
                Console.WriteLine();

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("PRUEBA DE BÚSQUEDA SECUENCIAL:");
                BuscadorCodigo(codigos, modelo, montosNetos, "AUTO-203");

                Console.ReadKey();
        }
    }
}
