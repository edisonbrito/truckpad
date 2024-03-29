﻿using System;
using System.Threading.Tasks;

namespace TruckPad.Api.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
