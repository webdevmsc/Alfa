using System;
using System.Threading;
using System.Threading.Tasks;
using AlfaProject.Models;
using AlfaProject.Repositories;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Create
{
    public class CreateRequestHandler : IRequestHandler<CreateRequest, CreateResponse>
    {
        private readonly IUserRepository _userRepository;
        
        public CreateRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<CreateResponse> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullNameValue, request.Login);
            _userRepository.Create(user);
            return Task.FromResult(new CreateResponse(user.Id, user.CreatedAt));
        }
    }
}