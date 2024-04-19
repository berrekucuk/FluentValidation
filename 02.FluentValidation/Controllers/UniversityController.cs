using _02.FluentValidation.Models.DTO;
using _02.FluentValidation.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02.FluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        AkademiIstanbulContext db;

        public UniversityController()
        {
            db = new AkademiIstanbulContext();
        }

        [HttpPost]
        public IActionResult AddUniversity(CreateUniversityRequestDto model)
        {
            University university = new University();
            university.Name = model.Name;
            university.City = model.City;

            db.Universities.Add(university);
            db.SaveChanges();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUniversity(int id, UpdateUniversityRequestDto model)
        {
            University university = db.Universities.FirstOrDefault(x => x.Id == id);

            if (university == null)
            {
                return NotFound();
            }

            university.Name = model.Name;
            university.City = model.City;

            db.SaveChanges();
            return Ok(university);
        }
    }
}
