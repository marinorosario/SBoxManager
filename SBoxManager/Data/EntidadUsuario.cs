using Microsoft.AspNetCore.Identity;
using SBoxManager.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data
{
    public class EntidadUsuario : IdentityUser
    {
        public virtual Persona Persona { get; set; }
    }
}
