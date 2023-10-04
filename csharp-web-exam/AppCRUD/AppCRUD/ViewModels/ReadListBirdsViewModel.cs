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
        public ObservableRangeCollection<BirdsModel> BirdsModel { get; set; }
        public Command LoadBirdsModelCommand { get; set; }

        public ReadListBirdsViewModel()
        {
            Title = resources.TitleReadList;
            BirdsModel = new ObservableRangeCollection<BirdsModel>();
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
                ListBirdsModel listBirds = await Service.GetListBirdAsync();
                if (listBirds.GeneralResponseModel.Status=="200" || listBirds.GeneralResponseModel.Status.ToUpper() == "OK")
                {
                    IEnumerable<BirdsModel> list = listBirds.ListBirds;
                    BirdsModel.ReplaceRange(list);
                }
                
            }
            catch (Exception e)
            {
                IsBusy = false;
                string error = e.InnerException.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
