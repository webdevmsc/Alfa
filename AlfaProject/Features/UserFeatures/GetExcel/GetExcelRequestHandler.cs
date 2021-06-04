using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AlfaProject.Repositories;
using ClosedXML.Excel;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AlfaProject.Features.UserFeatures.GetExcel
{
    public class GetExcelRequestHandler : IRequestHandler<GetExcelRequest, byte[]>
    {
        private readonly IUserRepository _userRepository;
        public GetExcelRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<byte[]> Handle(GetExcelRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "FirstName";
                worksheet.Cell(currentRow, 3).Value = "MiddleName";
                worksheet.Cell(currentRow, 4).Value = "LastName";
                worksheet.Cell(currentRow, 5).Value = "Login";
                worksheet.Cell(currentRow, 6).Value = "CreatedAt";
                worksheet.Cell(currentRow, 7).Value = "UpdatedAt";
                foreach (var user in users)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.Id;
                    worksheet.Cell(currentRow, 2).Value = user.FullName.FirstName;
                    worksheet.Cell(currentRow, 3).Value = user.FullName.MiddleName;
                    worksheet.Cell(currentRow, 4).Value = user.FullName.LastName;
                    worksheet.Cell(currentRow, 5).Value = user.Login;
                    worksheet.Cell(currentRow, 6).Value = user.CreatedAt.Value;
                    worksheet.Cell(currentRow, 7).Value = user.UpdatedAt.Value;
                }
                using (var stream = new MemoryStream())
                {
                    
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return Task.FromResult(content);
                }
            }
        }
    }
}