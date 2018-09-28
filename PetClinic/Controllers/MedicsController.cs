using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetClinic.DataAccess.Models;
using PetClinic.Models;

namespace PetClinic.Controllers
{
    [Produces("application/json")]
    [Route("api/Medics")]
    public class MedicsController : Controller
    {
        private readonly PetClinicContext _dbContext;

        public MedicsController(PetClinicContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/medics
        [HttpGet]
        public IEnumerable<Medic> Get()
        {
            var medics = _dbContext.Medics.ToList();
            return medics;
        }

        // GET api/medics/5
        [HttpGet("{id}")]
        public Medic Get(int id)
        {
            var medic = _dbContext.Medics.Find(id);
            return medic;
        }

        // DELETE api/medics/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var medic = _dbContext.Medics.Find(id);

            if(medic == null)
            {
                return NotFound();
            }

            _dbContext.Medics.Remove(medic);
            _dbContext.SaveChanges();
            return Ok();
        }

        // POST api/medics
        [HttpPost]
        public IActionResult Post([FromBody] MedicDto medic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMedic = new Medic {
                Name = medic.Name.Trim(),
                Contact = medic.Contact.Trim()
            };

            _dbContext.Medics.Add(newMedic);
            _dbContext.SaveChanges();
            return Ok(newMedic.Id);
        }

        // PUT api/medics/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MedicDto medic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicToUpdate = _dbContext.Medics.Find(id);

            if (medicToUpdate == null)
            {
                return NotFound();
            }

            medicToUpdate.Name = medic.Name.Trim();
            medicToUpdate.Contact = medic.Contact.Trim();

            _dbContext.SaveChanges();
            return Ok();
        }
    }
}