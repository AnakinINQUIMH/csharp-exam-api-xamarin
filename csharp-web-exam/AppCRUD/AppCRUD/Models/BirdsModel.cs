using AppCRUD.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCRUD.Models
{
    public class BirdsModel : ObservableObject
    {
        private int _Id = 0;
        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        public string Name { get; set; }
        public string Feeding { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
    }
}
