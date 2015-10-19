using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marquite.Test.Models
{
    public class SampleFormModel
    {
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }

        public bool IsActive { get; set; }

    }
}