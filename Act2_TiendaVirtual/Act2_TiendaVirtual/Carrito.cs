using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act2_TiendaVirtual
{
    internal class Carrito
    {
        // Propiedad pública que guarda el cliente al que pertenece este carrito.
        public Cliente Cliente { get; set; }

        // Diccionario que guarda los productos agregados al carrito.
        // La clave es el producto, y el valor es la cantidad de ese producto que se agregó.
        public Dictionary<Producto, int> Productos { get; set; } = new Dictionary<Producto, int>();

        // Constructor que recibe un objeto de tipo Cliente.
        public Carrito(Cliente cliente)
        {
            // Asignamos el cliente recibido al carrito.
            Cliente = cliente;
        }

        // Método público para agregar un producto al carrito.
        // Recibe como parámetros un producto y una cantidad.
        public void AgregarProducto(Producto producto, int cantidad)
        {
            // Verifica si el producto ya existe.
            if (Productos.ContainsKey(producto))
                // Si ya existe, simplemente sumamos la cantidad al valor actual.
                Productos[producto] += cantidad;
            else
                // Si no existe, lo agregamos al diccionario con la cantidad indicada.
                Productos.Add(producto, cantidad);
        }

        // Método público para eliminar un producto del carrito usando su nombre.
        public void EliminarProducto(string nombreProducto)
        {
            // Buscamos el primer producto en el diccionario que tenga ese nombre usando "FirstOrDefault", no lo encuentra, devuelve null. .
            var producto = Productos.Keys.FirstOrDefault(p => p.Nombre == nombreProducto);
            // Si se encontró el producto (no es null), lo eliminamos del diccionario.
            if (producto != null)
                Productos.Remove(producto);
        }

        // Método público que calcula el total a pagar del carrito.
        public double CalcularTotal()
        {
            //Recorre todos los productos y suma el precio de cada uno multiplicado por su cantidad.
            return Productos.Sum(p => p.Key.Precio * p.Value);
        }

        // Método para mostrar en pantalla el detalle de lo que hay en el carrito.
        public void VerTotalDelCarrito()
        {
            // Escribimos un título para el detalle del carrito.
            Console.WriteLine("\n--- Total del Carrito ---");

            // Recorremos cada elemento del diccionario de productos.
            foreach (var item in Productos)
            {
                // Mostramos el nombre del producto, la cantidad, el precio unitario y el subtotal.
                Console.WriteLine($"Producto: {item.Key.Nombre}, Cantidad: {item.Value}, Precio unitario: ${item.Key.Precio}, Subtotal: ${item.Key.Precio * item.Value}");
            }

            // Al final, mostramos el total general del carrito llamando al método CalcularTotal.
            Console.WriteLine($"\nTotal a pagar: ${CalcularTotal()}");
        }
    }
}
