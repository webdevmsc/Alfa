using System.Collections.Generic;
using AlfaProject.Models;

namespace AlfaProject.Features.UserFeatures.GetAll
{
    public record GetAllResponse(IEnumerable<User> Users);
}