using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LuuTienDat_174.Models{
    [Table("SinhVienHumgs")]
    public class SinhVienHumg{
        [Key]
        public int SoThuTu { get; set; }
        public string MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        public SinhVien? SinhVien {get; set;}
        public string TenSinhVien { get; set; }
        
    }
}