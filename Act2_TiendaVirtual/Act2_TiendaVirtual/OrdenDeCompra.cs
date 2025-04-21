using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act2_TiendaVirtual
{
    internal class OrdenDeCompra
    {
        // Propiedades 
        public Cliente Cliente { get; set; } 
        public Dictionary<Producto, int> Productos { get; set; }// Diccionario que guarda los productos comprados y la cantidad de cada uno, la clave es el producto, el valor es la cantidad comprada.
        public string DireccionEnvio { get; set; }

        // Constructor 
        public OrdenDeCompra(Cliente cliente, Dictionary<Producto, int> productos, string direccionEnvio)
        {
           Cliente = cliente;
            Productos = new Dictionary<Producto, int>(productos);
            DireccionEnvio = direccionEnvio;
        }

        // Método que calcula el total de la orden sumando cada producto * cantidad.
        public double CalcularTotal()
        {
            // Usamos LINQ para recorrer todos los productos y sumar su subtotal (precio(p.key.precio) * cantidad(p.value)).
            return Productos.Sum(p => p.Key.Precio * p.Value);
        }

        // Método para confirmar la orden y muestra todos los detalles .
        public void ConfirmarOrdenDeCompra()
        {
             Console.WriteLine("\n--- Orden de Compra Confirmada ---");
            Console.WriteLine($"-Cliente: {Cliente.Nombre}  -Email: {Cliente.Email}");// Muestra el nombre y el email del cliente que hizo la compra
            Console.WriteLine($"-Dirección de Envio: {DireccionEnvio}");// Muestra la dirección donde se enviará la compra.
             foreach (var item in Productos)// Recorremos todos los productos de la orden.
            {
               Console.WriteLine($"Producto: {item.Key.Nombre}, Cantidad: {item.Value}, Precio unitario: ${item.Key.Precio}");// Muestra el nombre del producto "item.Key", la cantidad y el precio unitario "item.value" ya que usamos Dictionary.
            }
            Console.WriteLine($"\nTotal: ${CalcularTotal()}");// Muestra el total a pagar usando el método CalcularTotal.
        }
    }
}

