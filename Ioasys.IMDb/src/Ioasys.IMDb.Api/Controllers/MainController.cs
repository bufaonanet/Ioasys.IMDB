﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(ModelStateDictionary modelState, object result = null)
        {
            if (!modelState.IsValid)
            {
                return BadRequest(new { success = false, data = result });
            }

            return Ok(new { success = true, data = result });
        }

        protected ActionResult CustomResponse( object result = null)
        {          

            return Ok(new { success = true, data = result });
        }



    }
}