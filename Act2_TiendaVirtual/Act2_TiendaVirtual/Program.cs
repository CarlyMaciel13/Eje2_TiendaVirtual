using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST;

namespace Act2_TiendaVirtual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cargamos productos de ejemplo
            Categoria electronica = new Categoria("Electrónica", "Dispositivos electrónicos"); // Creamos una categoría llamada Electrónica
            Categoria ropa = new Categoria("Ropa", "Prendas de vestir"); // Creamos una categoría llamada Ropa

            // Creamos una lista de productos y la llenamos con algunos ejemplos
            List<Producto> productos = new List<Producto>
        {
            new Producto("Laptop", "Portátil de alto rendimiento", 1500, electronica, 10), // Producto 1
            new Producto("Camiseta", "Camiseta de algodón", 25, ropa, 50), // Producto 2
            new Producto("Auriculares", "Auriculares inalámbricos", 100, electronica, 30) // Producto 3
        };

            // Creamos un cliente de ejemplo con nombre y correo
            Cliente cliente = new Cliente("Juan Pérez", "juan@mail.com");

            // Creamos un carrito asociado a ese cliente
            Carrito carrito = new Carrito(cliente);

            int opcion; // Variable para guardar la opción seleccionada del menú

            // Bucle principal que muestra el menú mientras la opción no sea 0
            do
            {
                opcion = Menu(); // Llamamos al método que muestra el menú y guarda la opción elegida

                switch (opcion) // Evaluamos la opción elegida
                {
                    case 1:
                        // Opción 1: Agregar producto al carrito
                        Console.WriteLine("Productos disponibles:");
                        for (int i = 0; i < productos.Count; i++) // Mostramos la lista de productos
                        {
                            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio}"); // Mostramos cada producto
                        }
                        Console.Write("Seleccione el número del producto a agregar: ");
                        int indice = int.Parse(Console.ReadLine()) - 1; // Restamos 1 para que coincida con el índice real de la lista
                        Console.Write("Ingrese la cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine()); // Leemos la cantidad que quiere agregar
                        carrito.AgregarProducto(productos[indice], cantidad); // Agregamos el producto al carrito
                        Console.WriteLine("Producto agregado al carrito.");
                        break;

                    case 2:
                        // Opción 2: Eliminar producto del carrito
                        Console.Write("Ingrese el nombre del producto a eliminar: ");
                        string nombre = Console.ReadLine(); // Leemos el nombre del producto a eliminar
                        carrito.EliminarProducto(nombre); // Llamamos al método para eliminar el producto
                        Console.WriteLine("Producto eliminado del carrito si existía.");
                        break;

                    case 3:
                        // Opción 3: Ver total del carrito
                        carrito.VerTotalDelCarrito(); // Llamamos al método que muestra el total
                        break;

                    case 4:
                        // Opción 4: Confirmar orden de compra
                        Console.Write("Ingrese la dirección de envío: ");
                        string direccion = Console.ReadLine(); // Leemos la dirección de envío
                        OrdenDeCompra orden = new OrdenDeCompra(cliente, carrito.Productos, direccion); // Creamos una orden
                        orden.ConfirmarOrdenDeCompra(); // Confirmamos la orden (muestra el resumen)
                        cliente.Ordenes.Add(orden); // Guardamos la orden en la lista del cliente
                        break;
                }

                // Pausa para que el usuario vea el resultado antes de limpiar pantalla
                Console.WriteLine("\n\nToque una tecla para continuar..");
                Console.ReadKey(); // Esperamos a que el usuario toque una tecla
                Console.Clear(); // Limpiamos la pantalla

            } while (opcion != 0); // El ciclo se repite hasta que se elige la opción 0 (salir)

            Console.ReadKey(); // Esperamos nuevamente una tecla antes de cerrar
        }

        // Método para mostrar el menú y leer la opción del usuario
        private static int Menu()
        {
            int opcion; // Variable para guardar la opción elegida

            // Mostramos las opciones al usuario
            Console.WriteLine("Ingrese el número de la opción y luego enter:\n");
            Console.WriteLine("1 - Agregar producto al carrito");
            Console.WriteLine("2 - Eliminar producto del carrito");
            Console.WriteLine("3 - Ver total del carrito");
            Console.WriteLine("4 - Confirmar orden de compra");
            Console.WriteLine("0 - Salir\n");

            // Validamos que el número ingresado esté entre 0 y 4
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 4)
            {
                Console.WriteLine("Opción inválida. Intente nuevamente."); // Si no es válido, volvemos a pedirlo
            }

            return opcion; // Retornamos la opción elegida

        }
    }
}
