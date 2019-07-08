using System;
using TruckPad.Domain.Model;

namespace TruckPad.Api.ViewModel
{
    public class VeiculoViewModel
    {
        public bool Carregado { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string Placa { get; set; }
        public DateTime DataPassagemTerminal { get; set; }
    }
}