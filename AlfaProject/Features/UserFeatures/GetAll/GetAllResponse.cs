using System.Collections.Generic;
using AlfaProject.Models;

namespace AlfaProject.Features.UserFeatures.GetAll
{
    public class GetAllResponse
    {
        public IEnumerable<User> Users { get; set; }

        public GetAllResponse(IEnumerable<User> users)
        {
            Users = users;
        }
    }
}