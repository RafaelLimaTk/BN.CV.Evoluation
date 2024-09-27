using AutoMapper;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class MainController : ControllerBase
{
    public readonly IMapper _mapper;
    public readonly IMediator _mediator;

    public MainController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    protected IActionResult CustomResponse<T>(T result)
    {
        try
        {
            return Ok(new ResultResponse<T> { success = true, type = "success", message = "", Data = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultResponse<T> { success = false, type = "error", message = ex.Message, Data = result });
        }
    }
}
