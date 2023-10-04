using AppCRUD.Models;
using AppCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadListBirds : ContentPage
    {
        ReadListBirdsViewModel viewModel;
        public ReadListBirds()
        {
            InitializeComponent();
            BindingContext = viewModel = new ReadListBirdsViewModel();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                viewModel.LoadBirdsModelCommand.Execute(null);
            }
            
            
            
        }

        private async void Editar_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            BirdsModel item = (BirdsModel)button.BindingContext;

            if (item != null)
            {
                await Navigation.PushAsync(new UpdateBirds(item));
            }
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            BirdsModel item = (BirdsModel)button.BindingContext;
            GeneralResponseModel response = null;
            if (item != null)
            {
                
                string action = await DisplayActionSheet($"¿Desea eliminar el ave: {item.Name}", "Cancelar", "Eliminar");
                if (action == "Eliminar")
                {
                    response = await viewModel.Service.DeleteBirdAsync(item.Id);
                   if( response!=null)
                    await DisplayAlert(response.Status, response.Message, "Aceptar");

                    viewModel.LoadBirdsModelCommand.Execute(null);
                }
            }
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateBirds()); //Sin parametros significa que va a insertar un registro
        }

        private async void OnBirdSelect(object sender, SelectedItemChangedEventArgs e)
        {
            BirdsModel selectBird = (BirdsModel)e.SelectedItem;
            await DisplayAlert("Alimentacion", selectBird.Feeding, "Ok");

        }
    }
}