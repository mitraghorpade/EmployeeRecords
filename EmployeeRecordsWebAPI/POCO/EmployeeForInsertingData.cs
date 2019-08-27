using System.ComponentModel.DataAnnotations;

namespace EmployeeRecordsWebAPI.POCO
{
    public class EmployeeForInsertingData
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
