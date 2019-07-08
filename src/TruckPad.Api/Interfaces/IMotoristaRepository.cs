using System.Collections.Generic;
using System.Threading.Tasks;
using TruckPad.Api.Model.Enum;
using TruckPad.Domain.Model;

namespace TruckPad.Api.Interfaces
{
    public interface IMotoristaRepository : IRepository<Motorista>
    {
        Task<IEnumerable<Motorista>> GetVehicleOwners();
        Task<IEnumerable<Motorista>> GetVehicleOriginunLoaded();
        Task<IEnumerable<Motorista>> GetPeriod(Periodo Periodo);
    }
}
