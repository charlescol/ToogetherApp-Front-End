using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusinessLogicLayer.ViewModels.Pages
{
    /* ViewModel of the MapPage */
    public class MapPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DataLayer.SQLLite.DatabaseHandler _db;
        public MapPageViewModel() 
        {
            _db = BusinessLogicLayer.AppLogic.Connection;
        }
        /* Update all data of the map by getting all event in the database */
        public async Task<List<DataLayer.Models.MapEvent>> UpdateAllDataAsync()
        {
            return await _db.GetAllItemsAsync<DataLayer.Models.MapEvent, string>();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
