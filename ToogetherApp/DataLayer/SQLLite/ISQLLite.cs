using SQLite;

namespace DataLayer.SQLLite
{
    /* Interface to implements to create a database instance for each OS */
    public interface ISQLLite
    {
        SQLiteAsyncConnection SQLiteConnection();
    }
}
