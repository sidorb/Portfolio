using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Web.Models
{
    public class PictureViewModel
    {
        public int PictureId { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public string Description { get; set; }
        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}