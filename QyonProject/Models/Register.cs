using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonProject.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public double TemperaturaMediaCorpo { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}
