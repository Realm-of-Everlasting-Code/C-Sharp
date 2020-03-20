using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    public class SomethingController : ControllerBase
    {
        private readonly IChangeSomethingInteractor _changeSomethingInteractor;
        public SomethingController(IChangeSomethingInteractor changeSomethingInteractor)
        {
            _changeSomethingInteractor = changeSomethingInteractor;
        }

        [HttpPost]
        public async Task<IActionResult> ChangeSomething(ChangeSomethingRequest request)
        {
            await _changeSomethingInteractor.ExecuteAsync(request);

            return Ok();
        }
    }
}
