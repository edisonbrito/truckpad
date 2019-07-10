namespace TruckPad.Domain.Model
{
    public class Geolocalizacao
    {
        public Geolocalizacao()
        {
            Origem = new LocalidadeOrigem();
            Destino = new LocalidadeDestino();
        }

        public LocalidadeOrigem Origem { get; set; }
        public LocalidadeDestino Destino { get; set; }
    }
}
