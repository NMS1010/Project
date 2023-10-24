using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class VacXin
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? Nccid { get; set; }
        public string? TieuChuan { get; set; }
        public string? SoLo { get; set; }
    }
}
