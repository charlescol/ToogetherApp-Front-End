namespace ToogetherApp.Views
{
    public class Map : Xamarin.Forms.ContentView
    {
        /* Event */
        public delegate void EntitiesModifiedEvent(string json_content);
        /* Event Handler */
        public event EntitiesModifiedEvent HandlerEntitiesModified;
        public Map() : base()
        {
        }
        /* Update the json file which contains the map entities */
        public void SetEntities(string json_content)
        {
            HandlerEntitiesModified?.Invoke(json_content);
        }
    }
}
