using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Api.Models
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        [ForeignKey("EquipmentId")]
        public Equipment? Equipment { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}