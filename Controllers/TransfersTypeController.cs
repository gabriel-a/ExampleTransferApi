using System;
using System.Collections.Generic;
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
        public IEnumerable<TransferType> Get()
        {
            return Enum.GetValues(typeof(TransferType)).Cast<TransferType>();
        }
    }
}