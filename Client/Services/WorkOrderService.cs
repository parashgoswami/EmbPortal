﻿using AntDesign;
using Client.Extensions;
using Client.Services.Interfaces;
using EmbPortal.Shared.Requests;
using EmbPortal.Shared.Requests.MeasurementBooks;
using EmbPortal.Shared.Responses;
using EmbPortal.Shared.Responses.WorkOrders;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly HttpClient _httpClient;
    public WorkOrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult<PurchaseOrder>> FetchPOFromSAP(string purchaseOrderNo)
    {
        var response = await _httpClient.GetAsync($"/api/WorkOrder/sap/{purchaseOrderNo}");
        return await response.ToResult<PurchaseOrder>();
    }

    public async Task<IResult<int>> ReFetchPOFromSAP(long purchaseOrderNo)
    {
        var response = await _httpClient.GetAsync($"/api/WorkOrder/sap/refetch/{purchaseOrderNo}");
        return await response.ToResult<int>();
    }

    public async Task<IResult<WorkOrderDetailResponse>> GetWorkOrderById(int id)
    {
        var response = await _httpClient.GetAsync($"/api/WorkOrder/{id}");
        return await response.ToResult<WorkOrderDetailResponse>();
    }

    public async Task<PaginatedList<WorkOrderResponse>> GetUserWorkOrdersPagination(int pageIndex, int pageSize, string search)
    {
        return await _httpClient.GetFromJsonAsync<PaginatedList<WorkOrderResponse>>
            ($"/api/WorkOrder/self?pageNumber={pageIndex}&pageSize={pageSize}&search={search}");
    }

    public async Task<IResult> DeleteWorkOrder(int id)
    {
        var response = await _httpClient.DeleteAsync($"/api/WorkOrder/{id}");
        return await response.ToResult();
    }

    public async Task<IResult<int>> CreateWorkOrder(WorkOrderRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/api/WorkOrder", request);
        return await response.ToResult<int>();
    }
    public async Task<List<WOItemStatusResponse>> GetWorkOrderItemStatus(int id)
    {
        return await _httpClient.GetFromJsonAsync<List<WOItemStatusResponse>>($"/api/WorkOrder/{id}/ItemStatus");
    }
    public async Task<IResult<List<PendingOrderItemResponse>>> GetPendingWorkOrderItems(int id)
    {
        var response = await _httpClient.GetAsync($"/api/WorkOrder/{id}/Item/Pending");
        return await response.ToResult<List<PendingOrderItemResponse>>();
    }

    public async Task<string> ExportToExcelAsync()
    {
        var response = await _httpClient.GetAsync($"/api/WorkOrder/Item/Download");
        var data = await response.Content.ReadAsStringAsync();
        return data;
    }

    public async Task<IResult> ChangeEngineerIncharge(int id, ChangeOfficerRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/WorkOrder/{id}/Transfer", request);
        return await response.ToResult();
    }
}
