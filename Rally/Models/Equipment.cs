namespace Rally.Models
{
    public enum EquipmentType
    {

    }
    public class Equipment
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Rotation { get; set; }
        public string? Location { get; set; }
        public EquipmentType? Type { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
    }
}