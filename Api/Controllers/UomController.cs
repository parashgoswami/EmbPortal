﻿using Api.Models;
using Application.CQRS.Uoms.Query;
using Application.Uoms.Command;
using Application.Uoms.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests;
using Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class UomController : ApiController
    {
        [HttpGet("dimension")]
        public async Task<ActionResult<IReadOnlyList<UomDimensionResponse>>> GetUomDimensions()
        {
            return Ok(await Mediator.Send(new GetUomDimensionsQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UomResponse>>> GetAllUoms()
        {
            return Ok(await Mediator.Send(new GetUomsQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UomResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UomResponse>> GetUomById(int id)
        {
            return Ok(await Mediator.Send(new GetUomByIdQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateUom(UomRequest request)
        {
            CreateUomCommand command = new CreateUomCommand(name: request.Name, dimension: request.Dimension);

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUom(int id, UomRequest request)
        {
            EditUomCommand command = new EditUomCommand(id: id, name: request.Name, dimension: request.Dimension);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUom(int id)
        {
            var command = new DeleteUomCommand(id);
            await Mediator.Send(command);

            return NoContent();
        }
    }
}