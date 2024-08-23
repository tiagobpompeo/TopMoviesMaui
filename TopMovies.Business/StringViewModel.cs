using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TopMovies.Business.Models;

namespace TopMovies.Business
{
    public partial class StringViewModel : ObservableObject
    {
        public StringViewModel()
        {
            StringModel = new StringModel();
        }

        [ObservableProperty]
        private bool isRunning;
        public StringModel? StringModel { get; set; }

        [RelayCommand]
        public async void GetString()
        {
            IsRunning = true;

            var data = this.StringModel.myString;

            if (data == null)
            {

            }

            IsRunning = false;
        }
    }
}
