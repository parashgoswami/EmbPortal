﻿using Application.Interfaces;
using AutoMapper;
using EmbPortal.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.MBSheets.Query
{
    public record GetMBSheetsByMBookIdQuery(int MBookId) : IRequest<List<MBSheetResponse>>
    {
    }

    public class GetMBSheetsByMBookIdQueryHandler : IRequestHandler<GetMBSheetsByMBookIdQuery, List<MBSheetResponse>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetMBSheetsByMBookIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MBSheetResponse>> Handle(GetMBSheetsByMBookIdQuery request, CancellationToken cancellationToken)
        {
            var userQuery = _context.AppUsers.AsQueryable();
            var msheetQuery = _context.MBSheets
                                 .Include(p => p.Items)
                                 .AsQueryable();

            var query = from msheet in msheetQuery
                        join measurer in userQuery on msheet.MeasurerEmpCode equals measurer.UserName
                        join validator in userQuery on msheet.ValidatorEmpCode equals validator.UserName
                        join eic in userQuery on msheet.EicEmpCode equals eic.UserName
                        select new { msheet, measurer, validator, eic};

            var results = await query
                .Where(p => p.msheet.MeasurementBookId == request.MBookId)
                .OrderBy(p => p.msheet.MeasurementDate)
                .AsNoTracking()
                .ToListAsync();

            List<MBSheetResponse> response = new();
            foreach (var result in results)
            {
                var item = _mapper.Map<MBSheetResponse>(result.msheet);
                item.MeasurerName = result.measurer.DisplayName;
                item.ValidatorName = result.validator.DisplayName;
                item.EicName = result.eic.DisplayName;

                response.Add(item);
            }

            return response;
        }
    }
}
