using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckPad.Api.Helper;
using TruckPad.Api.Interfaces;
using TruckPad.Api.Model.Enum;
using TruckPad.Domain.Model;

namespace TruckPad.Api.Repository
{
    public class MotoristaRepository : BaseRepository<Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Motorista>> GetVehicleOriginunLoaded()
        {
            var motoristas = await DbSet.FindAsync(Builders<Motorista>.Filter.Eq(x => x.CargaParaVoltaDestino, false));
            return motoristas.ToList();
        }

        public async Task<IEnumerable<Motorista>> GetVehicleOwners()
        {
            var motoristas = await DbSet.FindAsync(Builders<Motorista>.Filter.Eq(x => x.VeiculoProprio, true));
            return motoristas.ToList();
        }

        public async Task<IEnumerable<Motorista>> GetPeriod(Periodo Periodo)
        {
            IEnumerable<Motorista> result = null;

            switch (Periodo)
            {
                case Periodo.Dia:
                    result = await GetPeriodDay();
                    break;
                case Periodo.Semana:
                    result = await GetPeriodWeek();
                    break;
                case Periodo.Mes:
                    result = await GetPeriodMonth();
                    break;
                default:
                    result = await GetPeriodDay();
                    break;
            };

            return result;
        }

        public async Task<IEnumerable<Motorista>> GetPeriodDay()
        {
            var dayNow = await DbSet
                .FindAsync(Builders<Motorista>
                .Filter.Gt(x => x.Veiculo.DataPassagemTerminal, DateTime.Today));

            return dayNow.ToList();
        }

        public async Task<IEnumerable<Motorista>> GetPeriodWeek()
        {
            var dataSemana = DateHelper.GetDateOfWeek();
            var filterBuilder = Builders<Motorista>.Filter;

            var filter = filterBuilder.Gte(x => x.Veiculo.DataPassagemTerminal, new BsonDateTime(dataSemana.Item1.Date)) &
                filterBuilder.Lte(x => x.Veiculo.DataPassagemTerminal, new BsonDateTime(dataSemana.Item2.Date));

            var searchResult = await DbSet
                .FindAsync(filter);

            return searchResult.ToList();
        }

        public async Task<IEnumerable<Motorista>> GetPeriodMonth()
        {
            var dataMes = DateHelper.GetDateOfMonth();
            var filterBuilder = Builders<Motorista>.Filter;

            var filter = filterBuilder.Gte(x => x.Veiculo.DataPassagemTerminal, new BsonDateTime(dataMes.Item1)) &
                filterBuilder.Lte(x => x.Veiculo.DataPassagemTerminal, new BsonDateTime(dataMes.Item2));

            var searchResult = await DbSet
                .FindAsync(filter);

            return searchResult.ToList();
        }

        //Faltar fazer agrupamento
        public async Task<List<Motorista>> GetVehicleType()
        {
            var all = await DbSet.FindAsync(Builders<Motorista>.Filter.Empty);
                                          
            var a = all.ToList();

            return null;            
        }
    }
}
