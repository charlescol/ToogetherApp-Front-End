using SQLite;

namespace DataLayer.Models
{
    /* Abstract class to create a model */
    public abstract class AbstractModel<TId>
    {
        [PrimaryKey]
        public TId Id { get; set; }
    }
}
