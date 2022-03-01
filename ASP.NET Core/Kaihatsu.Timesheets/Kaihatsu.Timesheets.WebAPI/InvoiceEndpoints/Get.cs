using Kaihatsu.Timesheets.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.InvoiceEndpoints
{
    public partial class InvoiceEndpoint
    {
        [HttpGet]
        [Route("{contractId}")]
        public async Task<ActionResult<IReadOnlyCollection<Invoice>>> GetInvoicetByContractId([FromRoute] int contractId, CancellationToken token)
        {
            _logger.LogTrace("GetInvoicetByContractId id: {0}", contractId);
            IReadOnlyCollection<Invoice> entities = await _service.GetByIdAsync(contractId, token);
            return new ActionResult<IReadOnlyCollection<Invoice>>(entities);
        }

        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyCollection<Employee>>> GetClientsFromPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken token)
        //{
        //    _logger.LogTrace("GetClientsFromPagination skip: {0}, take: {1}" + take, skip);

        //    IReadOnlyCollection<Client> entities = await _service.GetFromPaginationAsync(skip, take, token);
        //    return new ActionResult<IReadOnlyCollection<Client>>(entities);
        //}
    }
}
