using Core;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }


    }
}
