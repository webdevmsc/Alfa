using AlfaProject.Models;
using MediatR;

namespace AlfaProject.Features.UserFeatures.GetAll
{
    public record GetAllRequest : IRequest<GetAllResponse>;
}