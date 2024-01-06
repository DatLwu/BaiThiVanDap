using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuuTienDat_174.Models{
    [Table("SinhViens")]
    public class SinhVien{
        [Key]
        public string MaSinhVien { get; set; }
        public int SoBaoDanh { get; set; }
        public double Diem { get; set; }
        public ICollection<SinhVienHumg>? SinhVienHumg {get; set;}
        
    }
}