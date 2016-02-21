﻿namespace OrdersSystem.Web.Areas.Admin.ViewModels.Users
{
    using Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}