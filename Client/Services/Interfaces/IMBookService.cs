﻿using EmbPortal.Shared.Requests;
using EmbPortal.Shared.Requests.MeasurementBooks;
using EmbPortal.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    public interface IMBookService
    {
        Task<List<MBookResponse>> GetMBooksByWorkOrderId(int orderId);
        Task<PaginatedList<MBookHeaderResponse>> GetMBooksByUserIdPagination(int pageIndex, int pageSize, string search, int status);
        Task<IResult<MBookResponse>> GetMBooksById(int id);
        Task<List<WorkOrderItemStatusResponse>> GetCurrentMBItemsStatus(int id);
        Task<IResult> DeleteMeasurementBook(int id);
        Task<IResult<int>> CreateMeasurementBook(MBookRequest request);
        Task<IResult> UpdateMeasurementBook(int id, MBookRequest request);
        Task<IResult> PublishMeasurementBook(int id);
        Task<IResult> ChangeMeasurer(int id, ChangeOfficerRequest request);
        Task<IResult> ChangeValidator(int id, ChangeOfficerRequest request);
    }
}
