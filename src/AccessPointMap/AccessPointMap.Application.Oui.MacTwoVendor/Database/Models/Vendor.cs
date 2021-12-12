﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AccessPointMap.Application.Oui.MacToVendor.Database.Models
{
    public class Vendor
    {
        [Column("mac")]
        public int MacAddress { get; set; }
        
        [Column("vendor")]
        public string Name { get; set; }
        
        [Column("registry")]
        public string Registry { get; set; }

        [Column("organization")]
        public string OrganizationName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("visibility")]
        public int Visibility { get; set; }
    }
}
