using System;
using System.Collections.Generic;

namespace CrudMVCCore.Models
{
    public partial class Beacons
    {
        public int Id { get; set; }
        public int? Mac { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public int? Rssi1 { get; set; }
        public int? Rssi2 { get; set; }
        public int? Rssi3 { get; set; }
        public int? Rssi4 { get; set; }
    }
}
