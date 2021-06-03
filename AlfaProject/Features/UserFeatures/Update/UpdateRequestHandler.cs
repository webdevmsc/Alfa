using System.Threading;
using System.Threading.Tasks;
using AlfaProject.Repositories;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Update
{
    public class UpdateRequestHandler : IRequestHandler<UpdateRequest, UpdateResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public Task<UpdateResponse> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.Id);
            var userToUpdate = user.ContinueWithNewFullNameAndLogin(request.FullName, request.Login);
            _userRepository.Update(userToUpdate);
            return Task.FromResult(new UpdateResponse(userToUpdate));
        }
    }
}