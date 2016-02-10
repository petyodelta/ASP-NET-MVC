﻿namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ICategoriesServices
    {
        IQueryable<Category> GetAll();
    }
}
