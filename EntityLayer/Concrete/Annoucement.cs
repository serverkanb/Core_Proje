using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Annoucement
    {
        public int AnnoucementId { get; set; }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }

        public string Content { get; set; }
    }
}
