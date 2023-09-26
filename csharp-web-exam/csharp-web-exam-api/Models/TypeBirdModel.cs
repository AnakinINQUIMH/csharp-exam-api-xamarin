using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_web_exam_api
{
    public class TypeBirdModel
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<BirdsModel> Birds
        {
            get; set;
        }
    }
}
