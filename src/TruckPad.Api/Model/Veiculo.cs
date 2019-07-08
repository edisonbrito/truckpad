using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TruckPad.Domain.Model
{
    public class Veiculo
    {
        public Veiculo(bool carregado, TipoVeiculo tipo, string placa, DateTime dataPassagemTerminal)
        {
            Carregado = carregado;
            TipoVeiculo = tipo;
            Placa = placa;
            DataPassagemTerminal = dataPassagemTerminal;
        }

        public Veiculo(bool carregado, TipoVeiculo tipo, string placa)
        {
            Carregado = carregado;
            TipoVeiculo = tipo;
            Placa = placa;          
        }

        public bool Carregado { get; set; }     
        public TipoVeiculo TipoVeiculo { get; set; }    
        public string Placa { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DataPassagemTerminal { get; set; }
    }
}
