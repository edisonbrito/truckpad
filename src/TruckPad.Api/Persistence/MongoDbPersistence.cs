using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckPad.Api.Persistence
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {
            MotoristaMap.Configure();
        }
    }
}
