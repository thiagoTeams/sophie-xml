using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SophieXML.Areas.Identity.Pages.Dashboard
{
    //[Authorize(Roles = RolePrefix.AdminSys + "," + RolePrefix.Admin + "," + RolePrefix.Developer + "," + RolePrefix.Manager)]
    //[Authorize(Roles = RolePrefix.Admin + "," + RolePrefix.Developer + "," + RolePrefix.Moderator)]
    //[Authorize(Policy = "RequireAdministratorRoleForCMS")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

    }
}

