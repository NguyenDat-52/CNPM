using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhachSan.Models
{
    // Placeholder or generic object if needed, added to Context previously
    public partial class DOI_TUONG
    {
        [Key]
        public int MA_DOI_TUONG { get; set; }
        public string TEN_DOI_TUONG { get; set; }
    }
}
