using System;
using System.Collections.Generic;

namespace CrudMVCCore.Models
{
    public partial class Gateways
    {
        public int Id { get; set; }
        public int? Mac { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
