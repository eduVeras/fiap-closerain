using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;
using Fiap.CloseRain.Service.Correio.Models;
using RestSharp;

namespace Fiap.CloseRain.Service.Correio.Services
{
    public class ViaCepService : ICorreioService
    {
        public async Task<Regiao> GetAddresByCepAsync(string cep)
        {
            var client = new RestClient("http://viacep.com.br/");
            var request = new RestRequest($"ws/{cep}/json/", Method.GET);


            IRestResponse<ViaCepModel> result = await client.ExecuteGetTaskAsync<ViaCepModel>(request);
            if (!result.IsSuccessful && result.Data != null)
            {
                result = await client.ExecuteGetTaskAsync<ViaCepModel>(request);
            }

            var data = result.Data;
            if(data == null)
                throw new Exception($"Erro ao requisitar CEP - {cep}");

            return new Regiao(0, cep, data.logradouro, data.bairro, data.localidade, data.uf, 0, 0);
        }
    }
}
