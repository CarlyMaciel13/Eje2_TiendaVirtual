using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act2_TiendaVirtual
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public Categoria Categoria { get; set; }
        public int CantidadInventario { get; set; }

        public Producto(string nombre, string descripcion, double precio, Categoria categoria, int cantidad)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
            CantidadInventario = cantidad;
        }

        // Método público para actualizar la cantidad de productos en el inventario.
        // Recibe como parámetro la nueva cantidad que se desea asignar.
        public void ActualizarCantidad(int cantidad)
        {
            // Cambia el valor de CantidadInventario al nuevo valor recibido.
            CantidadInventario = cantidad;
        }

        // Método público para modificar el precio del producto.
        // Recibe como parámetro el nuevo precio que se desea asignar.
        public void ModificarPrecio(double nuevoPrecio)
        {
            // Cambia el valor de Precio al nuevo valor recibido.
            Precio = nuevoPrecio;
        }
    }
}
