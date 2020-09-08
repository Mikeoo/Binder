using System;
using System.Collections.Generic;
using Binder.Models;
using Xamarin.Forms;
using Binder.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Binder.Services;

namespace Binder.Views
{
    public partial class LandingPhotos : ContentPage
    {
        LandingPhotosViewModel viewModel;
        public HouseProfile HouseProfile { get; set; }
        public IList<HouseProfile> HouseList { get; set; }

        public LandingPhotos(LandingPhotosViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();
            BindingContext = HouseList;
      
        }
        public LandingPhotos()
        {
            InitializeComponent();
            InitializeData();



            BindingContext = this;
            
        }

        async void InitializeData()
        {
            var BinderDataStore = new MockBinderDataStore();
            HouseList = await BinderDataStore.GetHouseProfilesAsync();

        }
    }
}
