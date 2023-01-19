
using System.ComponentModel.DataAnnotations;
namespace AngularCRM.Model
{
    public class Notes
    {
        [Key]
        public int Sno { get; set; }
        public string Type { get; set; }
        public string Notify { get; set; }
        public string Description { get; set; }
    }
}
