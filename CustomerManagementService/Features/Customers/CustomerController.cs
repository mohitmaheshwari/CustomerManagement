using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CustomerManagementService.Features.Customers.Models;
using CustomerManagementService.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerManagementService.Features.Customers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(
            ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Customer>))]
        public async Task<IActionResult> All([FromQuery] CustomersQuery query)
        {
            var model = await _mediator.Send(query);

            return new ObjectResult(model)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Customer))]
        public async Task<IActionResult> Create([FromBody] CustomerCreateCommand command)
        {
            var model = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), new { model.Id }, model);
        }
    }
}
