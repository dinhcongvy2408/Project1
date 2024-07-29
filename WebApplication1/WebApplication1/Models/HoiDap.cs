﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class HoiDap
    {
        public int MaHd { get; set; }
        public string CauHoi { get; set; } = null!;
        public string TraLoi { get; set; } = null!;
        public DateTime NgayDua { get; set; }
        public string MaNv { get; set; } = null!;

        public virtual NhanVien MaNvNavigation { get; set; } = null!;
    }
}
