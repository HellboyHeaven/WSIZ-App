using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Application.Controllers;

[Route("api")]
[ApiController]
 public class APIController: ControllerBase
{
    [HttpGet]
    public ActionResult<bool> Api() => Ok(true);
}