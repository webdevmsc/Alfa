using AlfaProject.Models;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Create
{
    public class CreateRequest : IRequest<CreateResponse>
    {
        public FullNameValue FullNameValue { get; set; }
        public string Login { get; set; }
    }
}