using AlfaProject.Models;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Create
{
    public record CreateRequest(FullNameValue FullNameValue, string Login) : IRequest<CreateResponse>;
}