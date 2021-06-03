using System;
using AlfaProject.Models;

namespace AlfaProject.Features.UserFeatures.Create
{
    public class CreateResponse
    {
        public CreateResponse(string id, DateTimeConvertibleValue createdAt)
        {
            Id = id;
            CreatedAt = createdAt;
        }
        public string Id { get; set; }
        public DateTimeConvertibleValue CreatedAt { get; set; }
    }
}