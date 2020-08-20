using System;
using System.Collections.Generic;

namespace CrudMVCCore.Models
{
    public partial class Graphics
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int? Rssi { get; set; }
    }
}
