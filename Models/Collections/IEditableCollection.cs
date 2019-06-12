using System.Collections.Generic;

namespace ArtAuction.Models.Collections
{
    public interface IEditableCollection<T>
    {
        List<T> Objects { get; }
        void AddObject(T obj);
        void RemoveObject(string id);
        void UpdateObject(T obj);
        T FindObject(string id);
    }
}
