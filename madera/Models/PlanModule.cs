using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    public class PlanModule
    {
        [ForeignKey(typeof(Plan))] 
        public int PlanId { get; set; }

        [ForeignKey(typeof(Module))] 
        public int ModuleId { get; set; }
    }
}
