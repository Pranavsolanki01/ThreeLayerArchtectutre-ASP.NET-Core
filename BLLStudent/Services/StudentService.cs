using DALStudent.Interface;
using DALStudent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLStudent.Services
{
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _studentRepository;  // Dependency Injection from the Data Access Layer  
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync(); //access to the data access layer --> interface -->IStudentRepository ---> method
        }
		public async Task<Student> GetStudentByIdAsync(int id)
		{
			return await _studentRepository.GetStudentByIdAsync(id);
		}
		public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }
        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateStudentAsync(student);
        }
        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }


    }
}
