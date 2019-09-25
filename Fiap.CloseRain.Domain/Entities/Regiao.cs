using Fiap.CloseRain.Domain.Model;

namespace Fiap.CloseRain.Domain.Entities
{
    public sealed class Regiao
    {
        public Regiao() { }

        public Regiao(int idRegiao, string cep, string logradouro, string bairro, string municipio, string uf, double latitude, double longitude)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Municipio = municipio;
            Uf = uf.ToUpper();
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

            if (Latitude.Equals(0))
                notification.AddError(nameof(Latitude), "Latitude deve ser informado.");

            if (Longitude.Equals(0))
                notification.AddError(nameof(Longitude), "Latitude deve ser informado.");

            return notification;
        }

        public string GetPolicyByState()
        {

            if (Uf.Equals("AC", System.StringComparison.InvariantCultureIgnoreCase))
                return "@Governo_ac";

            if (Uf.Equals("AL", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoAlagoas";

            if (Uf.Equals("AM", System.StringComparison.InvariantCultureIgnoreCase))
                return "@AmazonasGoverno";

            if (Uf.Equals("AP", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoDoAmapa";

            if (Uf.Equals("BA", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoDaBahia";

            if (Uf.Equals("CE", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoDoCeara";

            if (Uf.Equals("DF", System.StringComparison.InvariantCultureIgnoreCase))
                return "@Gov_DF";

            if (Uf.Equals("ES", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoES";

            if (Uf.Equals("GO", System.StringComparison.InvariantCultureIgnoreCase))
                return "@Governo_go";

            if (Uf.Equals("MA", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoMA";

            if (Uf.Equals("MG", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoMG";

            if (Uf.Equals("MS", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoMS";

            if (Uf.Equals("MT", System.StringComparison.InvariantCultureIgnoreCase))
                return "@govmatogrosso";

            if (Uf.Equals("PA", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoPara";

            if (Uf.Equals("PB", System.StringComparison.InvariantCultureIgnoreCase))
                return "@Govparaiba";

            if (Uf.Equals("PE", System.StringComparison.InvariantCultureIgnoreCase))
                return "@governope";

            if (Uf.Equals("PI", System.StringComparison.InvariantCultureIgnoreCase))
                return "@governodoPi";

            if (Uf.Equals("PR", System.StringComparison.InvariantCultureIgnoreCase))
                return "@governoparana";

            if (Uf.Equals("RJ", System.StringComparison.InvariantCultureIgnoreCase))
                return "@govrj";

            if (Uf.Equals("RN", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoDoRn";

            if (Uf.Equals("RO", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovernoRO";

            if (Uf.Equals("RR", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovRoraima";
            if (Uf.Equals("RS", System.StringComparison.InvariantCultureIgnoreCase))
                return "Governo_rs";
            if (Uf.Equals("SC", System.StringComparison.InvariantCultureIgnoreCase))
                return "@GovSC";
            if (Uf.Equals("SE", System.StringComparison.InvariantCultureIgnoreCase))
                return "@governoSergipe";
            if (Uf.Equals("SP", System.StringComparison.InvariantCultureIgnoreCase))
                return "@governosp";
            if (Uf.Equals("TO", System.StringComparison.InvariantCultureIgnoreCase))
                return "governoto";


            return "@GovernoDeSaoPaulo";
        }
    }
}
