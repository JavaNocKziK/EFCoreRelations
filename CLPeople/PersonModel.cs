using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLPeople
{
    public class PersonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AreaModelId { get; set; }
        public int PlaceModelId { get; set; }
        public int SpaceModelId { get; set; }
    }
}
