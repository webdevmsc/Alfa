using System.Threading;
using System.Threading.Tasks;
using AlfaProject.Repositories;
using MediatR;

namespace AlfaProject.Features.UserFeatures.GetAll
{
    public class GetAllRequestHandler : IRequestHandler<GetAllRequest, GetAllResponse>
    {
        private IUserRepository _userRepository;

        public GetAllRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<GetAllResponse> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            return Task.FromResult(new GetAllResponse(users));
        }
    }
}