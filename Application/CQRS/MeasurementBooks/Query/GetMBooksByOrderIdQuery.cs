﻿using Application.Interfaces;
using AutoMapper;
using MediatR;
using EmbPortal.Shared.Responses;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Application.Mappings;

namespace Application.CQRS.MeasurementBooks.Query
{
    public record GetMBooksByOrderIdQuery(int workOrderId) : IRequest<List<MBookResponse>>
    {
    }

    public class GetMBooksByOrderIdQueryHandler : IRequestHandler<GetMBooksByOrderIdQuery, List<MBookResponse>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetMBooksByOrderIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<MBookResponse>> Handle(GetMBooksByOrderIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.MeasurementBooks
                .Include(p => p.Items)
                    .ThenInclude(i => i.WorkOrderItem)
                .Where(p => p.WorkOrderId == request.workOrderId)
                .AsNoTracking()
                .ProjectToListAsync<MBookResponse>(_mapper.ConfigurationProvider);
        }
    }
}
