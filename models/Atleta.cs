using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtetlaAPI.models

{
    public class Atleta
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Altura { get; set; }
        public double Peso { get; set; }
    }
}