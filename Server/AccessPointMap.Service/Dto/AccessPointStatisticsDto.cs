﻿using System.Collections.Generic;

namespace AccessPointMap.Service.Dto
{
    public class AccessPointStatisticsDto
    {
        public int AllRecords { get; set; }
        public int InsecureRecords { get; set; }
        public IEnumerable<string> TopBrands { get; set; }
        public IEnumerable<AccessPointDto> TopAreaAccessPoints { get; set; }
        public IEnumerable<string> TopSecurityTypes { get; set; }
        public IEnumerable<double> TopFrequencies { get; set; }
    }
}
