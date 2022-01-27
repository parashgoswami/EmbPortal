﻿using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using EmbPortal.Shared.Requests;
using System.Threading;
using System.Threading.Tasks;
using EmbPortal.Shared.Enums;

namespace Application.CQRS.WorkOrders.Command
{
    public record EditWorkOrderItemCommand(int id, int workOrderId, WorkOrderItemRequest data) : IRequest
    {
    }

    public class EditWorkOrderItemCommandHandler : IRequestHandler<EditWorkOrderItemCommand>
    {
        private readonly IAppDbContext _context;

        public EditWorkOrderItemCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditWorkOrderItemCommand request, CancellationToken cancellationToken)
        {
            var workOrder = await _context.WorkOrders
                .Include(p => p.Items)                    
                .FirstOrDefaultAsync(p => p.Id == request.workOrderId);

            if (workOrder == null)
            {
                throw new NotFoundException(nameof(workOrder), request.workOrderId);
            }

            if (workOrder.Status != WorkOrderStatus.CREATED)
            {
                throw new BadRequestException("Published/Completed Work Order cannot be updated");
            }
            

            workOrder.AddUpdateLineItem(
                id: request.id,
                description: request.data.Description,
                uomId: request.data.UomId,
                unitRate: request.data.UnitRate,
                poQuantity: request.data.PoQuantity
            );

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
