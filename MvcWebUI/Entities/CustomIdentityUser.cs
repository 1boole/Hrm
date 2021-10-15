using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Entities
{
    public class CustomIdentityUser:IdentityUser
    {
        public int DegreeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
