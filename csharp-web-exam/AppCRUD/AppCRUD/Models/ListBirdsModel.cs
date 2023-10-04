using System;
using System.Collections.Generic;
using System.Text;

namespace AppCRUD.Models
{
    public class ListBirdsModel
    {
        public IEnumerable<BirdsModel> ListBirds { get; set; }
        public GeneralResponseModel GeneralResponseModel { get; set; }
    }
}
