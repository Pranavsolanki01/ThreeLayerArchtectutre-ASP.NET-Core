using BLLStudent.Services;
using DALStudent.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PLStudent.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService; // Dependency Injection form the Busseness Layer

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Read operations held here
        public async Task<IActionResult> Index()
        {

            var students = await _studentService.GetStudentsAsync();
            return View(students);
        }
        // adding the rest of the CRUD operations

        // Create operations held here
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddStudentAsync(student);
                return RedirectToAction("Index");
            }
			return View(student);
		}

        // Edit operation held here

        public async Task<IActionResult> Edit(int id)
		{
			var student = await _studentService.GetStudentByIdAsync(id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if(ModelState.IsValid)
			{
				await _studentService.UpdateStudentAsync(student);
				return RedirectToAction("Index");
			}
			return View(student);
		}


		// Delete operation held here
		public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if(student == null) return NotFound();
			return View(student);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeletePOSt(int id)
		{
			await _studentService.DeleteStudentAsync(id);
			return RedirectToAction("Index");
		}
	}
}
