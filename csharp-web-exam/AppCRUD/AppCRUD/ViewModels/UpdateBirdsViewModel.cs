using AppCRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using resources = AppCRUD.Resources.GlobalResource;
namespace AppCRUD.ViewModels
{
   public class UpdateBirdsViewModel :BaseViewModel
    {
        public BirdsModel BirdsModel { get; set; }
        public TypeBirdsModel TypeBirdsModel { get; set; }
        public UpdateBirdsViewModel()
        {
            Title = resources.TitleCreate;
            TypeBirdsModel = new TypeBirdsModel();
            BirdsModel = new BirdsModel();

        }
        public UpdateBirdsViewModel( BirdsModel bird)
        {
              
            Title = resources.TitleUpdate;
            TypeBirdsModel = new TypeBirdsModel();
            BirdsModel = new BirdsModel() { Id= bird.Id, Name = bird.Name, Feeding = bird.Feeding, TypeId = bird.TypeId };

        }
    }
}
