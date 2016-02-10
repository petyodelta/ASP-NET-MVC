﻿namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;

    public interface IDevicesServices
    {
        IQueryable<Device> GetAll();
    }
}
