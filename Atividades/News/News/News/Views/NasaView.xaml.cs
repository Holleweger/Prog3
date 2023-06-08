using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Views
{
    public partial class NasaView : ContentPage
    {
        public NasaView()
        {
            InitializeComponent();
            Task.Run(async () => await Initialize("Nasa"));
        }

        public NasaView(string scope)
        {
            InitializeComponent();
            Title = $"{scope} news";
            Task.Run(async () => await Initialize(scope));
        }

        private async Task Initialize(string scope)
        {
            var viewModel = Resolver.Resolve<NasaViewModel>();
            BindingContext = viewModel;
            await viewModel.Initialize(scope);
        }
    }
}