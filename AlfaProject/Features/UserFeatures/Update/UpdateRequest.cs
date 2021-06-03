using AlfaProject.Models;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Update
{
    public class UpdateRequest : IRequest<UpdateResponse>
    {
        public string Id { get; set; }
        public FullNameValue FullName { get; set; }
        public string Login { get; set; }
    }
}