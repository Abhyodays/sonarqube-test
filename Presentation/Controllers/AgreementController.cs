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
    public class AgreementController : ControllerBase
    {
        private readonly IAgreementService _service;
        public AgreementController(IAgreementService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult<IEnumerable<Agreement>> GetAll()
        {
            var agreements = _service.GetAll();
            return Ok(agreements);
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public ActionResult<Agreement> Add(Agreement model)
        {
            if (ModelState.IsValid)
            {
                var agreement = _service.Add(model);
                return Ok(agreement);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Authorize(Roles ="Admin")]
        public ActionResult<Agreement> Edit(Agreement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agreement = _service.Edit(model);
            if(agreement != null)
            {
                return Ok(agreement);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {
            var res = _service.Delete(id);
            if (res == "Failed")
            {
                return NotFound();
            }
            return Ok(new {Message="deleted"});
        }
        [HttpGet("{id}")]
        [Authorize(Roles ="Admin")]
        public ActionResult<Agreement> GetById(int id)
        {
            var agreement = _service.GetById(id);
            if (agreement != null)
            {
                return Ok(agreement);
            }
            return NotFound("No agreement found");
        }
        [HttpGet("{userMail}/all")]
        [Authorize(Roles ="User")]
        public ActionResult<IEnumerable<Agreement>> GetUserAgreements(string userMail)
        {
            var agreements = _service.GetUserAgreements(userMail);
            return Ok(agreements);
        }
        [HttpPut("return")]
        [Authorize(Roles ="User")]
        public ActionResult<Agreement> RequestToReturn(Agreement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(model.Status != AgreementStatus.Rented)
            {
                return BadRequest("Already requested");
            }
            var agreement = _service.RequestToReturn(model);
            if(agreement == null)
            {
                return NotFound("No agreement exist");
            }
            return Ok(agreement);
        }
        [HttpGet("returns")]
        [Authorize(Roles ="Admin")]
        public ActionResult<IEnumerable<Agreement>> GetReturnRequest()
        {
            return Ok(_service.GetReturnRequests());
        }

        [HttpPut("returns/accept")]
        [Authorize(Roles ="Admin")]
        public ActionResult<Agreement> AcceptReturn(Agreement agreement)
        {
            return Ok(_service.AcceptReturn(agreement));
        }
    }
}
