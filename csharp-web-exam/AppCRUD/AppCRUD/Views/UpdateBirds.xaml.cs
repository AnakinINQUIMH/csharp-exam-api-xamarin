using AppCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using resources = AppCRUD.Resources.GlobalResource;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCRUD.Helpers;
using AppCRUD.Models;
using Xamarin.Essentials;
using System.Net;

namespace AppCRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateBirds : ContentPage
    {
        UpdateBirdsViewModel viewModel;
        private byte _typeQuery;
        /// <summary>
        /// Sin parametros indica que vas a agregar un registro
        /// </summary>
        public UpdateBirds()
        {
            InitializeComponent();
            BindingContext = viewModel = new UpdateBirdsViewModel();
            _typeQuery = 0; //0 for insert
            buttonAction.Text = "Insert";
        }
        /// <summary>
        /// Con parametros indica que vas a modificar un registro
        /// </summary>
        /// <param name="bird"></param>
        public UpdateBirds(BirdsModel bird)
        {
            InitializeComponent();
            BindingContext = viewModel = new UpdateBirdsViewModel(bird);
            _typeQuery = 1; //1 for update
            buttonAction.Text = "Update";
        }

        private string ValidForm()
        {
            string message = "";

            List<string> fieldsWithError = new List<string>();

            if (viewModel.BirdsModel.Name == null)
                fieldsWithError.Add(resources.labelName);

            if (viewModel.BirdsModel.Feeding == null)
                fieldsWithError.Add(resources.labelFeeding);


            if (fieldsWithError.Count > 0)
            {
                message = string.Format("Campos requeridos: " + " {0}.", string.Join(", ", fieldsWithError));
            }

            return message;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                GeneralResponseModel generalResponse = null;
                string validForm = ValidForm();
                if (!String.IsNullOrEmpty(validForm))
                {
                    await DisplayAlert("Error", validForm, "Ok");
                    return;
                }
                using (new HUD("Cargando"))
                {
                    BirdsModel birds = new BirdsModel() { Id = viewModel.BirdsModel.Id, Name = viewModel.BirdsModel.Name, Feeding = viewModel.BirdsModel.Feeding, TypeId = viewModel.BirdsModel.TypeId };
                    generalResponse = await viewModel.Service.CreateOrUpdateBirdAsync(_typeQuery, birds);
                    await DisplayAlert(generalResponse.Status == HttpStatusCode.OK.ToString()?"Success":"Error", generalResponse.Message, "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "Sin conexión a internet", "Ok");
            }

        }
    }
}