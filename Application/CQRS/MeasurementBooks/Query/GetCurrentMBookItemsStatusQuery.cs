﻿using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using Domain.Entities.MeasurementBookAggregate;
using Domain.Entities.WorkOrderAggregate;
using EmbPortal.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.MeasurementBooks.Query;

public record GetCurrentMBookItemsStatusQuery(int MBookId) : IRequest<List<WorkOrderItemStatusResponse>>
{
}

public class GetCurrentMBookItemsStatusQueryHandler : IRequestHandler<GetCurrentMBookItemsStatusQuery, List<WorkOrderItemStatusResponse>>
{
    private readonly IAppDbContext _context;
    private readonly IMeasurementBookService _mBookService;

    public GetCurrentMBookItemsStatusQueryHandler(IAppDbContext context, IMeasurementBookService mBookService)
    {
        _context = context;
        _mBookService = mBookService;
    }

    public async Task<List<WorkOrderItemStatusResponse>> Handle(GetCurrentMBookItemsStatusQuery request, CancellationToken cancellationToken)
    {
        var wOrderQuery =  _context.WorkOrders.Include(p => p.Items).AsQueryable();

        var mBookQuery =  _context.MeasurementBooks.Include(p => p.Items).AsQueryable();

        var query = from mBook in mBookQuery
                    join wOrder in wOrderQuery
                    on mBook.WorkOrderId equals wOrder.Id
                    select new { mBook, wOrder };

        var result = await query.FirstOrDefaultAsync(p => p.mBook.Id == request.MBookId);

        
        if (result == null)
        {
            throw new NotFoundException(nameof(MeasurementBook), request.MBookId);
        }

        // Fetch the MB items status
        List<MBookItemQtyStatus> mbItemQtyStatuses = await _mBookService.GetMBItemsQtyStatus(result.mBook.Id);

        List<WorkOrderItemStatusResponse> itemStatusResponses = new();
        foreach (var item in result.mBook.Items)
        {
            var mbItemQtyStatus = mbItemQtyStatuses.Find(i => i.WorkOrderItemId == item.WorkOrderItemId);
            var workOrderItem = result.wOrder.Items.FirstOrDefault(i => i.Id == item.WorkOrderItemId);

            if(workOrderItem == null) {
                throw new NotFoundException(nameof(WorkOrderItem), item.WorkOrderItemId);
            }

            itemStatusResponses.Add(new WorkOrderItemStatusResponse
            {
                MBookItemId = item.Id,
                WorkOrderItemId = workOrderItem.Id,
                ServiceNo = workOrderItem.ServiceNo.ToString(),
                ItemDescription = workOrderItem.ShortServiceDesc,
                UnitRate = workOrderItem.UnitRate,                    
                Uom = workOrderItem.Uom,
                PoQuantity = workOrderItem.PoQuantity,
                CumulativeMeasuredQty = mbItemQtyStatus != null ? mbItemQtyStatus.TotalMeasuredQty : 0,
                AcceptedMeasuredQty = mbItemQtyStatus != null ? mbItemQtyStatus.AcceptedMeasuredQty : 0
            });
        }

        return itemStatusResponses;
    }
}
