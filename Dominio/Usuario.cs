﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
            

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool EsAdmin { get; set; }

    }
}
