using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act2_TiendaVirtual
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public List<OrdenDeCompra> Ordenes { get; set; } = new List<OrdenDeCompra>();

        public Cliente(string nombre, string email)
        {
            Nombre = nombre;
            Email = email;
        }
    }
}
