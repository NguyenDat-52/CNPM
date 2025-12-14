using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace QuanLyKhachSan.Models
{
    public partial class QLKSEntities : DbContext
    {
        public QLKSEntities()
            : base("name=QLKSEntities") // Ensure Web.config has this name
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // throw new UnintentionalCodeFirstException(); // Comment out if running without EDMX
        }
    
        public virtual DbSet<TAI_KHOAN> TAI_KHOAN { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public virtual DbSet<LOAI_PHONG> LOAI_PHONG { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<ALBUM_ANH_PHONG> ALBUM_ANH_PHONG { get; set; }
        public virtual DbSet<DICH_VU> DICH_VU { get; set; }
        public virtual DbSet<DAT_PHONG> DAT_PHONG { get; set; }
        public virtual DbSet<SU_DUNG_DV> SU_DUNG_DV { get; set; }
        public virtual DbSet<HOA_DON> HOA_DON { get; set; }
        public virtual DbSet<HOA_DON_TAM> HOA_DON_TAM { get; set; }
        public virtual DbSet<DANH_GIA> DANH_GIA { get; set; }
        public virtual DbSet<VW_DOANH_THU_NGAY> VW_DOANH_THU_NGAY { get; set; }

        public virtual int SP_TINH_HOA_DON(int maDP)
        {
            var pMaDP = new System.Data.SqlClient.SqlParameter("MA_DP", maDP);
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreCommand("SP_TINH_HOA_DON @MA_DP", pMaDP);
        }

        public virtual int SP_SU_DUNG_DICH_VU(int maDP, int maDV, int soLuong)
        {
            // Note: Use simple Insert statement if SP doesn't exist, or call SP
            // Assuming SP exists as per SQL script (Wait, I didn't write SP_SU_DUNG_DICH_VU in SQL script!)
            // I need to add SP_SU_DUNG_DICH_VU to SQL script or implement logic here.
            // Let's implement logic directly or call SP if I added it. Reviewing SQL Script...
            // I only added SP_TINH_HOA_DON. I should add SP_SU_DUNG_DICH_VU to SQL or handle here.
            // Check StaffController: it calls db.SP_SU_DUNG_DICH_VU(MaDatPhong, MaDichVu, SoLuong);
            // I will add the SP to SQL script and here.
            var pMaDP = new System.Data.SqlClient.SqlParameter("MA_DP", maDP);
            var pMaDV = new System.Data.SqlClient.SqlParameter("MA_DV", maDV);
            var pSoLuong = new System.Data.SqlClient.SqlParameter("SO_LUONG", soLuong);
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreCommand("INSERT INTO SU_DUNG_DV(MA_DP, MA_DV, SO_LUONG) VALUES(@MA_DP, @MA_DV, @SO_LUONG)", pMaDP, pMaDV, pSoLuong);
        }
    }
}
