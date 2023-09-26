using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_web_exam_api
{
    public class GetBirdTypeResponseModel
{
        public List<BirdsAndTypeModel> ListBirds { get; set; }
        public GeneralResponseModel GeneralResponseModel { get; set; }
    }
}
