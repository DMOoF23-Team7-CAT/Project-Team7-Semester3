using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;

        public ICollection<Track> Tracks { get; private set; }
        public ICollection<SignBase> SignBases { get; private set; }

        public Category()
        {
            Tracks = new List<Track>();
            SignBases = new List<SignBase>();
        }
    }
}