namespace FirstRestApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinqView")]
    public partial class LinqView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal UnitPrice { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Quantity { get; set; }

        [StringLength(15)]
        public string City { get; set; }
    }
}
