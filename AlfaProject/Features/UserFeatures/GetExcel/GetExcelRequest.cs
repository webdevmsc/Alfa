using System.IO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlfaProject.Features.UserFeatures.GetExcel
{
    public record GetExcelRequest : IRequest<byte[]>;
}