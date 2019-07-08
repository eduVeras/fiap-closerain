using Fiap.CloseRain.Domain.Model;
using Fiap.CloseRain.Domain.Validation;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Regiao
    {
        public Regiao() { }

        public Regiao(int idRegiao, string cep, string logradouro,  string bairro, string municipio, string uf, string pais, double latitude, double longitude)
        {   
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Municipio = municipio;
            Uf = uf.ToUpper();
            Pais = pais;
            Latitude = latitude;
            Longitude = longitude;
        }
        
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

        public Notification IsValid()
        {
            var validate =  new RegiaoValidator().Validate(this);
            return validate;
        }
    }
}
