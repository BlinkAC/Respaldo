using System;
using System.Collections.Generic;

#nullable disable

namespace Respaldo.Models
{
    public partial class User
    {
        public int ProductId { get; set; }
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string Email { get; set; }
    }
}
