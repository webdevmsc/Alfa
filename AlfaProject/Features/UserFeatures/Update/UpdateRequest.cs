using AlfaProject.Models;
using MediatR;

namespace AlfaProject.Features.UserFeatures.Update
{
    public record UpdateRequest(string Id, FullNameValue FullName, string Login) : IRequest<UpdateResponse>;
}