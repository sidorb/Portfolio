using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain
{
    public class Picture
    {
        public virtual int PictureId { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string Description { get; set; }
        
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
