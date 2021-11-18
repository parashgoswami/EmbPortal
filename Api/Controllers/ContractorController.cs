﻿using Api.Models;
using Application.Contractors.Command;
using Application.Contractors.Query;
using Application.CQRS.Contractors.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests;
using Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ContractorController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyList<ContractorResponse>>> GetContractors()
        {
            return Ok(await Mediator.Send(new GetContractorsQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ContractorResponse>>> GetContractorsWithPagination([FromQuery] GetContractorsWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContractorResponse>> GetContractor(int id)
        {
            return Ok(await Mediator.Send(new GetContractorByIdQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateContractor(ContractorRequest request)
        {
            CreateContractorCommand command = new CreateContractorCommand(name: request.Name);

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateContractor(int id, ContractorRequest request)
        {
            EditContractorCommand command = new EditContractorCommand(id: id, name: request.Name);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var command = new DeleteContractorCommand(id);
            await Mediator.Send(command);

            return NoContent();
        }
    }
}