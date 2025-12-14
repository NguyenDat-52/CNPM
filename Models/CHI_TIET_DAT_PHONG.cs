using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Models
{
    // Keeping name CHI_TIET_DAT_PHONG as per DbContext, assuming it maps to service usage
    // or maybe the user meant details of the room booking?
    // Given SP_SU_DUNG_DICH_VU(MaDatPhong, MaDichVu, Soluong), this table likely links them.
    public partial class CHI_TIET_DAT_PHONG
    {
        [Key]
        [Column(Order = 0)]
        public int MA_DAT_PHONG { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MA_DICH_VU { get; set; }

        public int SO_LUONG { get; set; }
        public decimal DON_GIA { get; set; }
        public decimal THANH_TIEN { get; set; }

        public virtual DAT_PHONG DAT_PHONG { get; set; }
        public virtual DICH_VU DICH_VU { get; set; }
    }
}
