using System;
using AlfaProject.Models;

namespace AlfaProject.Features.UserFeatures.Create
{
    public record CreateResponse(string Id, DateTimeConvertibleValue CreatedAt);
}