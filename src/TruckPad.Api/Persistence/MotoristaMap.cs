using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckPad.Domain.Model;

namespace TruckPad.Api.Persistence
{
    public class MotoristaMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Motorista>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Sexo).SetIsRequired(true);
                map.MapMember(x => x.Idade).SetIsRequired(true);
                map.MapMember(x => x.VeiculoProprio).SetIsRequired(true);
                map.MapMember(x => x.CNH).SetIsRequired(true);
                map.MapMember(x => x.VeiculoProprio).SetIsRequired(true);
               map.MapMember(x => x.Veiculo).SetIsRequired(true);
            });
        }
    }
}
