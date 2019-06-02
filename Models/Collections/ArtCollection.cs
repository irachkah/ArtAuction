using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtAuction.Models.Collections
{
    public class ArtCollection
    {
        public List<Painting> Items { get; }
        public Painting AddItem(Painting item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string id)
        {
            throw new NotImplementedException();
        }
    }
}
