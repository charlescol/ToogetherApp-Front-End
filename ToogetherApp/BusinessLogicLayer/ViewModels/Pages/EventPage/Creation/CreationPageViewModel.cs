using BusinessLogicLayer.Adapters;
using ServiceLayer;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusinessLogicLayer.ViewModels.Pages.EventPage.Creation
{
    public class CreationPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DataLayer.Models.MapEvent Event { get; set; } = new DataLayer.Models.MapEvent();
        public ICommand OnPublishCommand { get; private set; }
        public CreationPageViewModel()
        {
            OnPublishCommand = new Command(async () => await OnPublishEvent());
        }
        public async Task<bool> OnPublishEvent()
        {
            return await EventService.PublishEvent(new MapEventAdapter().ToAppModel(Event));
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
