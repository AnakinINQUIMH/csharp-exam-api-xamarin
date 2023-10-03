using System;
using System.Collections.Generic;
using System.Text;

namespace AppCRUD.Models
{
    public class ListBirdsModel
    {
        public IEnumerable<BirdsModel> listBirds { get; set; }

       public  GeneralResponseModel generalResponseModel { get; set; }
    }
}
