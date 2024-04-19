using _02.FluentValidation.Models.DTO;
using _02.FluentValidation.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02.FluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        AkademiIstanbulContext context;

        public StudentController()
        {
           context = new AkademiIstanbulContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllStudentsResponseDto> model = context.Students.Select( x => new GetAllStudentsResponseDto()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                UniversityName = x.University.Name
            }).ToList();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult AddStudent(CreateStudentRequestDto model)
        {
            Student student = new Student();
            student.Name = model.Name;
            student.Surname = model.Surname;
            student.Email = model.Email;
            student.Phone = model.Phone;
            student.BirthDate = model.BirthDate;

            context.Students.Add(student);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id , UpdateStudentRequestDto model)
        {
            Student student = context.Students.FirstOrDefault(x => x.Id == id);

            if(student == null)
            {
                return NotFound();
            }

            student.Name = model.Name;
            student.Surname=model.Surname;
            student.Email=model.Email;
            student.Phone=model.Phone;
            student.BirthDate = model.BirthDate;

            context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student student = context.Students.FirstOrDefault(x => x.Id == id);

            if(student == null)
            {
                return NotFound();
            }

            student.IsDeleted = true;
            context.SaveChanges();

            return Ok(student);
        }
    }
}
