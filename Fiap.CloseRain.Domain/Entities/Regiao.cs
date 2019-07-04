using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Regiao
    {
        public Regiao() { }
        
        public int IdRegiao { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void IsValid()
        {

        }

        private bool IsValidCep()
        {
            return true;
        }

        private bool IsValidUf()
        {
            return true;
        }
    }
}
