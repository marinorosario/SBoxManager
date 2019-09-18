using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBoxManager.Data
{
    public class FileUpload
    {
        //[Required]
        //[Display(Name = "Titulo")]
        //[StringLength(60, MinimumLength = 3)]
        //public string Title { get; set; }

        //[Required]
        [Display(Name = "Foto")]
        public IFormFile Foto { get; set; }

        
    }
}
