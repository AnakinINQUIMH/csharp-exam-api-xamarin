using System;
using System.Collections.Generic;
using System.Text;
using resources = AppCRUD.Resources.GlobalResource;
namespace AppCRUD.ViewModels
{
    public class DeleteBirdsViewModel : BaseViewModel
    {
        public DeleteBirdsViewModel()
        {
            Title = resources.TitleDelete;

        }
    }
}
