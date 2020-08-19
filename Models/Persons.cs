using System;
using System.Collections.Generic;

namespace CrudMVCCore.Models
{
    public partial class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? Phone { get; set; }
    }
}
