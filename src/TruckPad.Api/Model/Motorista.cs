using TruckPad.Domain.Enum;
using MongoDB.Bson;
using System;

namespace TruckPad.Domain.Model
{
    public class Motorista
    {
        public Motorista(Guid id, string nome, int idade, Sexo sexo, bool veiculoProprio, CNH cNH, Veiculo veiculo, bool cargaParaVoltaDestino)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            VeiculoProprio = veiculoProprio;
            CNH = cNH;
            Veiculo = veiculo;
            CargaParaVoltaDestino = cargaParaVoltaDestino;
        }

        public Motorista(string nome, int idade, Sexo sexo, bool veiculoProprio, CNH cNH, Veiculo veiculo, bool cargaParaVoltaDestino)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            VeiculoProprio = veiculoProprio;
            CNH = cNH;
            Veiculo = veiculo;
            CargaParaVoltaDestino = cargaParaVoltaDestino;
        }

        public Motorista()
        {
            Veiculo = new Veiculo();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Sexo Sexo { get; set; }
        public bool VeiculoProprio { get; set; }       
        public CNH CNH { get; set; }
        public bool CargaParaVoltaDestino { get; set; }
        public Veiculo Veiculo { get; set; }       
    }   
}
