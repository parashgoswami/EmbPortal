using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.MeasurementBookAggregate;
using Domain.Entities.WorkOrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Uom> Uoms { get; set; }
        DbSet<Contractor> Contractors {get; set;}
        DbSet<WorkOrder> WorkOrders { get; set; }
        DbSet<WorkOrderItem> WorkOrderItems { get; set; }
        DbSet<MeasurementBook> MeasurementBooks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}