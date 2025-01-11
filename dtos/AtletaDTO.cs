using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtetlaAPI.models;

namespace atetlaAPI.dtos
{
    public class AtletaDTO
    {

        public AtletaDTO() { }

        public AtletaDTO(Atleta obj)
        {
            Id = obj.Id.ToString();
            Nome = obj.Nome;
            Altura = obj.Altura;
            Peso = obj.Peso;
        }
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public double Altura { get; set; }
        public double Peso { get; set; }

        public Atleta GetModel()
        {
            var atleta = new Atleta();
            PreencherModel(atleta);
            return atleta;
        }

        public void PreencherModel(Atleta obj)
        {
            long.TryParse(this.Id, out long id);
            obj.Id = id;
            obj.Nome = this.Nome;
            obj.Altura = this.Altura;
            obj.Peso = this.Peso;
        }
    }
}