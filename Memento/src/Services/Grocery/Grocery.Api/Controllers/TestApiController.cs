using Grocery.Command.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Grocery.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestApiController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TestApiController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public string Get()
		{
			return "Result";
		}

		[HttpPost]
		public async Task<Guid> Post([FromBody] CreateProduct model)
		{
			var response = await _mediator.Send(model);
			return response.Result;
		}

		[HttpPut]
		public async Task<bool> Put(int id, [FromBody] UpdateProduct model)
		{
			var response = await _mediator.Send(model);
			return response.Result;
		}

		[HttpDelete]
		public async Task<bool> Delete(DeleteProduct model)
		{
			var response = await _mediator.Send(model);
			return response.Result;
		}
	}
}