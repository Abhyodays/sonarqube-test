using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly ITempAgreementService _service;
        public RentalController(ITempAgreementService service)
        {
            _service = service;
        }

        [Authorize(Roles = "User")]
        [HttpGet("{userMail}")]
        public ActionResult<IEnumerable<TempAgreement>>GetAll(string userMail)
        {
            var agreements = _service.GetAll(userMail);
            return Ok(agreements);
        }
        [Authorize(Roles ="User")]
        [HttpGet("{userMail}/{id}")]
        public ActionResult<TempAgreement>GetById(string userMail, int id)
        {
            var agreement = _service.GetById(id);
            if(agreement == null)
            {
                return BadRequest("Agreement not found!");
            }
            return agreement;
        }
        [Authorize(Roles ="User")]
        [HttpPost]
        public ActionResult<TempAgreement> Add(TempAgreement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agreement = _service.Add(model);
            return Ok(agreement);
        }
        [Authorize(Roles ="User")]
        [HttpPut]
        public ActionResult<TempAgreement> Edit(TempAgreement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedAgreement = _service.Edit(model);
            return Ok(updatedAgreement);
        }

        [Authorize (Roles ="User")]
        [HttpDelete("{id}")]
        public ActionResult<TempAgreement> Delete(int id)
        {
            var res = _service.Delete(id);
            if(res == "Failed")
            {
                return BadRequest("Agreement not found");
            }
            return Ok(new { message = "deleted" });
        }
    }
}
