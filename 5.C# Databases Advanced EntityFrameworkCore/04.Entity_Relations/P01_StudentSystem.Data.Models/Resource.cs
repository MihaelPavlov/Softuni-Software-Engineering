using System.ComponentModel.DataAnnotations;
using P01_StudentSystem.Data.Enumerations;

namespace P01_StudentSystem.Data.Models
{
   public class Resource
    {
        public int ResourceId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        //TODO: Not Unicode
        public string Url { get; set; }

        public ResourceTypeEnum ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
