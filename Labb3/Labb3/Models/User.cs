using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Labb3.Models
{
    [DebuggerDisplay("{ID}:{Username}")]
    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; }

        [RegularExpression(@"\b[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}\b", ErrorMessage="Felaktig mailadress")]
        public string Email { get; set; }
    }
}