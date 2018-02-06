namespace TicaretProje.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Resims = new HashSet<Resim>();
        }

        public int urunId { get; set; }

        [StringLength(50)]
        public string urunAdi { get; set; }

        [StringLength(150)]
        public string aciklama { get; set; }

        public int? alısFiyat { get; set; }

        public int? satisFiyat { get; set; }

        public int? kategoriID { get; set; }

        public int? resimID { get; set; }

        public virtual Kategori Kategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resims { get; set; }

        public virtual Resim Resim { get; set; }
    }
}
