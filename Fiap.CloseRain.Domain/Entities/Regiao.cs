using Fiap.CloseRain.Domain.Model;

namespace Fiap.CloseRain.Domain.Entities
{
    public sealed class Regiao
    {
        public Regiao() { }

        public Regiao(int idRegiao, string cep, string logradouro, string bairro, string municipio, string uf, string pais, double latitude, double longitude)
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

        public Notification<Regiao> IsValid()
        {
            var notification = new Notification<Regiao>(this);
            if (string.IsNullOrWhiteSpace(Cep))
                notification.AddError(nameof(Cep), "Cep deve ser informado");

            if (Cep.Length == 8)
                notification.AddError(nameof(Cep), "Cep inválido.");

            if (string.IsNullOrWhiteSpace(Logradouro))
                notification.AddError(nameof(Logradouro), "Logradouro deve ser informado.");

            if (Logradouro.Length <= 5)
                notification.AddError(nameof(Logradouro), "Logradouro inválido.");

            if (string.IsNullOrWhiteSpace(Bairro))
                notification.AddError(nameof(Bairro), "Bairro deve ser informado.");

            if (Logradouro.Length <= 5)
                notification.AddError(nameof(Bairro), "Bairro inválido.");

            if (string.IsNullOrWhiteSpace(Municipio))
                notification.AddError(nameof(Municipio), "Municipio deve ser informado.");

            if (string.IsNullOrWhiteSpace(Uf))
                notification.AddError(nameof(Uf), "Uf deve ser informado.");

            if (Uf.Length != 2)
                notification.AddError(nameof(Uf), "Uf inválida.");

            if (string.IsNullOrWhiteSpace(Pais))
                notification.AddError(nameof(Pais), "Pais deve ser informado.");

            if (Latitude.Equals(0))
                notification.AddError(nameof(Latitude), "Latitude deve ser informado.");

            if (Longitude.Equals(0))
                notification.AddError(nameof(Longitude), "Latitude deve ser informado.");

            return notification;
        }


    }
}
