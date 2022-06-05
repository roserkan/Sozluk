﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
