using System.Threading;
using System.Threading.Tasks;
using AlfaProject.Repositories;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Delete
{
    public class DeleteRequestHandler : IRequestHandler<DeleteRequest, DeleteResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteRequestHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }


        public Task<DeleteResponse> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            var deletingUser = _userRepository.GetById(request.Id);
            var deletedUser = deletingUser.ContinueWithIsDeleted(true);
            _userRepository.Update(deletedUser);
            return Task.FromResult(new DeleteResponse($"User has been deleted"));
        }
    }
}