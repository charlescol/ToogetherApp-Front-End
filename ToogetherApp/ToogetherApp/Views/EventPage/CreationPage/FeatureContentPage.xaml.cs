using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeatureContentPage : ContentPage
    {
        public ObservableCollection<FeatureView> Views { get; set; } = new ObservableCollection<FeatureView>();
        int current_index = 0;
        bool initialized = false;
        public FeatureContentPage(string senderClassID)
        {
            InitializeComponent();
            BindingContext = this;

            var description = new FeatureContent
            {
                IconsSource = new List<string>() { "bold_icon.png", "italic_icon.png", "underline_icon.png", "color_icon.png", "font_icon.png" },
                IconsClassID = new List<string>() { "Bold", "Italic", "Underline", "Color", "Font" },
                Content = new Description(),
                Title = "Description",
                Name = "Description",
                IconsText = new List<string>() { "Gras", "Italique", "Souligner", "Couleur", "Police" }
            };
            var descriptionView = FeatureViewFactory.Create(description);
            Views.Add(descriptionView);

            var map = new FeatureContent
            {
                IconsSource = new List<string>() { "location_icon.png", "addPin_icon.png" },
                IconsClassID = new List<string>() { "Location", "Pin"},
                Content = new MapLocation(),
                Title = "Carte",
                Name = "Map",
                IconsText = new List<string>() { "Adresse", "Pin" }

            }; Views.Add(FeatureViewFactory.Create(map));
            var date = new FeatureContent
            {
                IconsSource = new List<string>() { "date_icon.png", "date_icon.png" },
                IconsClassID = new List<string>() { "Beginning", "End"},
                Content = new Date(),
                Title = "Date",
                Name = "Date",
                IconsText = new List<string>() { "Début", "Fin" }

            }; Views.Add(FeatureViewFactory.Create(date));
            var tags = new FeatureContent
            {
                IconsSource = new List<string>() { "add_icon.png" },
                IconsClassID = new List<string>() { "Add" },
                Content = new Tags(),
                Title = "Tags",
                Name = "Tags",
                IconsText = new List<string>() { "Ajouter" }

            }; Views.Add(FeatureViewFactory.Create(tags));
            var actors = new FeatureContent
            {
                IconsSource = new List<string>() { "add_icon.png" },
                IconsClassID = new List<string>() { "Add"},
                Content = new Actors(),
                Title = "Acteurs",
                Name = "Actors",
                IconsText = new List<string>() { "Ajouter" }

            }; Views.Add(FeatureViewFactory.Create(actors));
            var presentation = new FeatureContent
            {
                IconsSource = new List<string>() { "photo_icon.png", "gallery_icon.png" },
                IconsClassID = new List<string>() { "Photo", "Gallery" },
                Content = new Presentation(),
                Title = "Présentation",
                Name = "Presentation",
                IconsText = new List<string>() { "Photo", "Gallerie" }

            }; Views.Add(FeatureViewFactory.Create(presentation));
            var diverse = new FeatureContent
            {
                IconsSource = new List<string>() { },
                Content = new Diverse(),
                Title = "Divers",
                Name = "Diverse",
                IconsText = new List<string>() { }

            }; Views.Add(FeatureViewFactory.Create(diverse));


            for(int i=0; i < Views.Count; i++)
            {
                Views[i].HandlerClickedEvent += OnIconClicked;
                if (Views[i].ClassId == senderClassID)
                {
                    current_index = i;
                    title_view.Text = Views[current_index].Title;
                }
            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            foreach (var view in Views)
            {
                view.WidthRequest = width;
            }
            collection_view.ScrollTo(current_index, animate: false);
        }
        void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (initialized)
            {
                if (e.CenterItemIndex != current_index)
                {
                    current_index = e.CenterItemIndex;
                    title_view.Text = Views[current_index].Title;
                }
            }
            else
            {
                if (e.CenterItemIndex == current_index)
                {
                    initialized = true;
                }
            }
        }
        void OnIconClicked(string classID)
        {
            ((IFeatureContent)Views[current_index].CurrentView).OnIconClicked(classID);
        }
    }
}