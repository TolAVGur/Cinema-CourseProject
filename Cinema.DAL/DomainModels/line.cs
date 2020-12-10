namespace Cinema.DAL.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class line
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HallId { get; set; }

        [Key]
        [Column("line", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line1 { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seads { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
