using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusinessLogicLayer.ViewModels.Pages.Profile
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PrivateUser User { get; set; }
        public ObservableCollection<string> Tags { get; set; } = new ObservableCollection<string>();
        public ICommand AddTagCommand { private set; get; }
        public ICommand RemoveTagCommand { private set; get; }
        public ICommand PublishProfilePictureCommand { private set; get; }
        public ProfileViewModel(PrivateUser user = null)
        {
            if (user != null)
            {
                User = new PrivateUser(user);
                foreach (var tag in User.PublicUser.Tags) Tags.Add(tag);
            }
            else
                User = new PrivateUser();
                
            AddTagCommand = new Command<string>((tag) => Tags.Add(tag));
            RemoveTagCommand = new Command<string>((tag) => Tags.Remove(tag));
            PublishProfilePictureCommand = new Command<string>(PublishProfilePicture);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool PublishData()
        {
            foreach (var tag in Tags) User.PublicUser.Tags.Add(tag);
            AppLogic.User = User;
            return true;
        }
        public void PublishProfilePicture(string imageSource) 
        { 
            ProfilePictureUri = "myUri"; 
        }
        public string Description
        {
            get { return User.PublicUser.Description; }
            set
            {
                User.PublicUser.Description = value;
                OnPropertyChanged("Description");
            }
        }
        public string ProfilePictureUri
        {
            get { return User.PublicUser.ProfilePictureUri; }
            set
            {
                User.PublicUser.ProfilePictureUri = value;
                OnPropertyChanged("ProfilePictureUri");
            }
        }
        public ImageSource _profileSource;
        public ImageSource ProfileSource
        {
            get { return _profileSource; }
            set
            {
                _profileSource = value;
                OnPropertyChanged("ProfileSource");
            }
        }
    }
}
