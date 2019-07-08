using TruckPad.Domain.Enum;

namespace TruckPad.Api.ViewModel
{
    public class MotoristaViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Sexo Sexo { get; set; }
        public bool PossuiVeiculo { get; set; }
        public CNH CNH { get; set; }
        public bool CargaParaVoltaDestino { get; set; }
        public VeiculoViewModel veiculo { get; set; }       
    }
}
