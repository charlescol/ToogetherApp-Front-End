using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ToogetherApp.Droid.Service.SQLite.SQLLite_Droid))]
namespace ToogetherApp.Droid.Service.SQLite
{
    public class SQLLite_Droid : DataLayer.SQLLite.ISQLLite
    {
        public SQLiteAsyncConnection SQLiteConnection()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return new SQLiteAsyncConnection(Path.Combine(path, "MainDatabase.db"));
        }
    }
}