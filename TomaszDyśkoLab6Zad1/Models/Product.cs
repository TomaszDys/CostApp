namespace TomaszDyśkoLab6Zad1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        /// <summary>
        /// Id produktu
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa produktu
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Ilość sztuk produktu
        /// </summary>
        public int NumberOfPieces { get; set; }
        /// <summary>
        /// Cena produktu
        /// </summary>
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }
    }
}
