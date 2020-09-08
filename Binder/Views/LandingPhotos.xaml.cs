using System;
using System.Collections.Generic;
using System.Globalization;
using Binder.Models;
using Xamarin.Forms;
using Binder.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Binder.Services;

namespace Binder.Views
{
    public class BoolToObjectConverter<T> : IValueConverter
    {
        public T TrueObject { set; get; }

        public T FalseObject { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TrueObject : FalseObject;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((T)value).Equals(TrueObject);
        }
    }

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
