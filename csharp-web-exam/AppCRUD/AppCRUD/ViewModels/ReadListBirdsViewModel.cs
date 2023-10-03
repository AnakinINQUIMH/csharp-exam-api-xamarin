using AppCRUD.Helpers;
using AppCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using resources = AppCRUD.Resources.GlobalResource;
namespace AppCRUD.ViewModels
{
    public class ReadListBirdsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ListBirdsModel> BirdsModel { get; set; }
        public Command LoadBirdsModelCommand { get; set; }

        public ReadListBirdsViewModel()
        {
            Title = resources.TitleReadList;
            BirdsModel = new ObservableRangeCollection<ListBirdsModel>();
            try
            {
                LoadBirdsModelCommand = new Command(async () => await ExecuteLoadBirdsModelCommand());

            }
            catch (Exception)
            {

                throw;
            }

        }

         async Task ExecuteLoadBirdsModelCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                BirdsModel.Clear();
                IEnumerable<ListBirdsModel> listBirds = await Service.GetListBirdAsync();
                if (listBirds.ElementAt(0).generalResponseModel.Status=="200")
                {
                    BirdsModel.ReplaceRange(listBirds);
                }
                
            }
            catch (Exception e)
            {
                string error = e.InnerException.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
