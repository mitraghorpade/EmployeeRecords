using System.ComponentModel.DataAnnotations;

namespace EmployeeRecords.Models
{
    public class EmployeeForInsertingData
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
