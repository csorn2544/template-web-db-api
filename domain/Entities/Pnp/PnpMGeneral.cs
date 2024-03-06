using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities.Pnp
{
    public partial class PnpMGeneral
    {
        public int Id { get; set; }
        public string Typegroup { get; set; } = null;
        public string Typename { get; set; } = null;
        public string Typevalue { get; set; } = null;
        public string Typeevent { get; set; } = null;
        public ulong? DeletedFlag { get; set; } = null;
    }   
}
