using OrdersSystem.Models;
using OrdersSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdersSystem.Web.Areas.Admin.ViewModels.Users
{
    public class UserEditModel : IMapFrom<User>, IMapTo<User>
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [UIHint("String")]
        public string Email { get; set; }

        // public ICollection<SelectListItem> Roles { get; set; }
    }
}