using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WikiNepalData.Model
{
    public class NepalDataModel
    {
        public int Id { get; set; }

        [StringLength(20 , MinimumLength =3)]
        [Required]  
        public string Title { get; set; }

        [StringLength(100000, MinimumLength = 20)]
        [Required]
        public string Paragraph { get; set; }

        
        public string Image { get; set; }

    }
}
