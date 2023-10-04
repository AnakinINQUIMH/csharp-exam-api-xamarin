using System;
using System.Collections.Generic;
using System.Text;

namespace AppCRUD.Models
{
    public class TypeBirdsModel
    {
        public List<string> getTypes
        {
            get
            {
                
                List<string> types = new List<string>();
                types.Add("");
                types.Add("Chipes");
                types.Add("Gorriones");
                types.Add("Mosqueros");
                return types;
            }
        }

    }
}
