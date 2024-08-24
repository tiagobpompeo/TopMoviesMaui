using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TopMovies.Business.Models;

namespace TopMovies.Business
{
    public partial class StringViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isRunning;
        public StringModel? StringModel { get; set; }
        public GenericRepositoryBusiness genericRepositoryBusiness;

        public StringViewModel()
        {
            StringModel = new StringModel();
            genericRepositoryBusiness = new GenericRepositoryBusiness();
        }

     
        [RelayCommand]
        public async void GetString()
        {
            try
            {
                IsRunning = true;

                await genericRepositoryBusiness.PostAsync("", StringModel.myString);

                IsRunning = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
           
        }
    }
}
