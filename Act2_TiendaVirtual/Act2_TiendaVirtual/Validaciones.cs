using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    internal class Validaciones
    {
        public static DateTime LeerDateTime()
        {
            bool pudo = false;                         // Variable que indica si la conversión fue exitosa.
            DateTime val = DateTime.Now;               // Variable que almacenará la fecha válida, se inicializa con la fecha actual.

            while (!pudo)                              // Se repite mientras no se ingrese una fecha válida.
            {
                pudo = DateTime.TryParse(Console.ReadLine(), out val); // Intenta convertir lo que escribe el usuario en una fecha.

                if (!pudo)                             // Si no pudo convertirlo en una fecha válida...
                {
                    Console.WriteLine("Valor incorrecto, solo fechas válidas\nIntente nuevamente: ");
                }
            }

            return val;                                // Devuelve la fecha válida que el usuario ingresó.
        }

        // Método que permite leer un número decimal (double) dentro de un rango (mínimo y máximo).
        public static double LeerDouble(double min, double max)
        {
            bool pudo = false;                         // Variable para verificar si la conversión fue exitosa.
            double valido = 0;                         // Guarda el número ingresado.

            while (!pudo)                              // Se repite hasta que se ingrese un número válido.
            {
                pudo = double.TryParse(Console.ReadLine(), out valido); // Intenta convertir el texto ingresado a número (double).

                // Si no es un número o está fuera del rango permitido:
                if (!pudo || valido < min || valido > max)
                {
                    pudo = false; // Aunque sea un número, no está dentro del rango, así que no lo acepta.
                    Console.WriteLine($"Valor incorrecto, solo números double entre {min} y {max}.\nIntente nuevamente: ");
                }
            }

            return valido;                             // Devuelve el número válido.
        }

        // Método para leer un número entero (int) dentro de un rango permitido.
        public static int LeerInt(int min, int max)
        {
            bool pudo = false;                         // Para verificar si fue una entrada válida.
            int val = 0;                               // Variable donde se guarda el número ingresado.

            while (!pudo)                              // Repetir hasta que se ingrese correctamente.
            {
                pudo = int.TryParse(Console.ReadLine(), out val); // Intenta convertir el texto en un número entero.

                // Verifica si no es número o está fuera del rango permitido:
                if (!pudo || val < min || val > max)
                {
                    pudo = false;
                    Console.WriteLine($"Valor incorrecto, solo números enteros entre {min} y {max}.\nIntente nuevamente: ");
                }
            }

            return val;                                // Devuelve el número válido.
        }

        // Método que permite al usuario responder "sí" o "no", devolviendo un valor booleano (true o false).
        public static bool LeerSiNo()
        {
            bool pudo = false;                         // Bandera para controlar si la respuesta fue válida.

            while (!pudo)                              // Repite hasta obtener una respuesta válida.
            {
                string tmp = Console.ReadLine();       // Lee la respuesta del usuario.

                // Convierte la respuesta a minúsculas, elimina espacios y reemplaza í por i.
                tmp = tmp.Trim().ToLower().Replace('í', 'i');

                // Si el usuario responde "si", "s", "yes" o "y", se interpreta como verdadero (true).
                if (tmp == "si" || tmp == "s" || tmp == "yes" || tmp == "y")
                {
                    return true;
                }
                // Si responde "no" o "n", se interpreta como falso (false).
                else if (tmp == "no" || tmp == "n")
                {
                    return false;
                }

                // Si no ingresó ninguna de esas opciones, muestra mensaje de error.
                Console.WriteLine("Valor incorrecto, ingrese si o no");
            }

            return false; // Nunca se llega aquí, pero se requiere devolver algo si todo falla.
        }
    }
}