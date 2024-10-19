using DALStudent.Entities;
using Microsoft.EntityFrameworkCore;
using DALStudent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALStudent.Interface
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbcontext; // Dependency Injection from the Data Access Layer DBContext

        public StudentRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
             return await _dbcontext.Students.ToListAsync();
        }
		public async Task<Student?> GetStudentByIdAsync(int id)
		{
			return await _dbcontext.Students.FindAsync(id);
		}
		public  async Task AddStudentAsync(Student student)
        {
            await _dbcontext.Students.AddAsync(student);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateStudentAsync(Student student)
        {
            _dbcontext.Students.Update(student);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteStudentAsync(int id)
        {
            var student = await _dbcontext.Students.FindAsync(id);
            _dbcontext.Students.Remove(student);
            await _dbcontext.SaveChangesAsync();
        }

    }
}
