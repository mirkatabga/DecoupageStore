﻿namespace DecoupageStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;
    using System;

    public class Product
    {
        private ICollection<ProductImage> images;

        public Product()
        {
            this.images = new HashSet<ProductImage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.productNameMaxLenght)]
        public string Name { get; set; }

        [Range(ValidationConstants.minProductPrice, int.MaxValue)]
        public decimal Price { get; set; }

        [DefaultValue(false)]
        public bool Negotiable { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool FinishedGoodsFlag { get; set; }

        [Required]
        [Range(ValidationConstants.minDaysToManufacture, ValidationConstants.maxDaysToManufacture)]
        public int DaysToManufacture { get; set; }

        public DateTime DateAdded { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int MaterialId { get; set; }

        public virtual Material Material { get; set; }

        public virtual ICollection<ProductImage> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }
    }
}