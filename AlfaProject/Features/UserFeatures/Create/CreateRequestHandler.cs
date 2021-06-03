using System.Threading;
using System.Threading.Tasks;
using AlfaProject.Repositories;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Create
{
    public class CreateRequestHandler : IRequestHandler<CreateRequest, CreateResponse>
    {
        private IUserRepository _userRepository;
        
        public CreateRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<CreateResponse> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            _userRepository.Insert(request);
        }
    }
}