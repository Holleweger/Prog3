using System;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using News.Models;
using News.Services;
using Xamarin.Forms;

namespace News.ViewModels
{
    public class NasaViewModel : ViewModel
    {
        private readonly NasaService nasaService;

        public Root CurrentNews { get; set; }

        public NasaViewModel(NasaService nasaService)
        {
            this.nasaService = nasaService;
        }

        public async Task Initialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "global" => NasaScope.Global,
                _ => NasaScope.Global
            };

            await Initialize(resolvedScope);
        }

        public async Task Initialize(NasaScope scope)
        {
            CurrentNews = await nasaService.GetNasa(scope);
        }

        public ICommand ItemSelected =>
            new Command(async (selectedItem) =>
            {
                var selectedPhoto = selectedItem as Photo;
                var url = selectedPhoto.img_src;
                await Navigation.NavigateTo($"{url}");
            });
    }
}
