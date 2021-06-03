using MediatR;

namespace AlfaProject.Features.UserFeatures.Delete
{
    public record DeleteRequest(string Id) : IRequest<DeleteResponse>;
}