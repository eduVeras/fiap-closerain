﻿namespace Fiap.CloseRain.Domain.Entities
{
    public class Contato
    {
        public Contato()
        {
            
        }

        public Contato(string nome, string numero, string descricao)
        {
            Nome = nome;
            Numero = numero;
            Descricao = descricao;
        }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
    }
}