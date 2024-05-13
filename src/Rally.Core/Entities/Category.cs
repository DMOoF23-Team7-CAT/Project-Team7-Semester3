using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;

        public ICollection<Track> Tracks { get; set; } = new List<Track>();
        public ICollection<SignBase> SignBases { get; set; } = new List<SignBase>();
    }
}