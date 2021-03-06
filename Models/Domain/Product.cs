﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{

    public class Product
    {
        /// <summary>
        /// Auto Incremented Product Id
        /// </summary>      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Name of the product
        /// </summary>
        [Required]
        public string ProductName { get; set; }
        /// <summary>
        /// Description of the product
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Stock Count
        /// </summary>
        public int StockCount { get; set; }
    }
}
