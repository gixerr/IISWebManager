using IISWebManager.Application.DTO;

namespace IISWebManager.Application.Queries.ApplicationPools
{
    public class GetDetailedApplicationPool : IQuery<ApplicationPoolGetDetailedDto>
    {
        public string Name { get; set; }

        public GetDetailedApplicationPool(string name)
        {
            Name = name;
        }
    }
}