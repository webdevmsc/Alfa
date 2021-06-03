using MediatR;

namespace AlfaProject.Features.UserFeatures.Delete
{
    public class DeleteRequest : IRequest<DeleteResponse>
    {
        public string Id { get; set; }
    }
}