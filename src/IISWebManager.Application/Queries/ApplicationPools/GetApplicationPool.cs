using IISWebManager.Application.DTO;

namespace IISWebManager.Application.Queries.ApplicationPools
{
    public class GetApplicationPool : IQuery<ApplicationPoolGetDto>
    {
        public string Name { get; set; }
    }
}