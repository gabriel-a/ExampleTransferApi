using System.Collections.Generic;
using System.Linq;
using ExampleTransferApi.DataInit;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTransferApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpRangeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Enumerable.Range(1, 50).Select(TransferItemsData.GetListOfIps).ToList();
        }
    }
}