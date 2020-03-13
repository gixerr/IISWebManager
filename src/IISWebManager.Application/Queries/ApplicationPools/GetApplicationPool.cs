using IISWebManager.Application.DTO.ApplicationPools;

namespace IISWebManager.Application.Queries.ApplicationPools
{
    public class GetApplicationPool : IQuery<ApplicationPoolGetDto>
    {
        public string Name { get; set; }
    }
}