using System;
using System.Dynamic;
using System.Linq;
using ExampleTransferApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTransferApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferTypesController : ControllerBase
    {
        // GET api/transfertypes
        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            dynamic wrapper = new ExpandoObject();
            wrapper.transferTypes = Enum.GetValues(typeof(TransferType)).Cast<TransferType>();;
            return wrapper;
        }
    }
}