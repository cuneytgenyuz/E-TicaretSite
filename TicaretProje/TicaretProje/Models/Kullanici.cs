namespace TicaretProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        public int kullaniciId { get; set; }

        [StringLength(50)]
        public string adi { get; set; }

        [StringLength(50)]
        public string soyadi { get; set; }

        [StringLength(50)]
        public string kullaniciAdi { get; set; }

        [StringLength(50)]
        public string parola { get; set; }

        [StringLength(50)]
        public string mail { get; set; }

        public DateTime? dogumTarihi { get; set; }

        public int? rolID { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
