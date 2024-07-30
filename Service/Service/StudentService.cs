using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Service.Service
{
    public class StudentService
    {
        private readonly FPTContext _db;
        public StudentService(FPTContext db)
        {
            _db = db; 
        }

        public async Task<List<Student>> GetAllStudent()
        {
            var students = await _db.Students.Include(s => s.Grade).Select(s => new Student
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Grade = new Grade
                {
                    GradeName = s.Grade.GradeName
                }
            })
            .ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByID(int id)
        {
            Student student = await _db.Students.FindAsync(id);
            return student;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            Student s = await _db.Students.FindAsync(student.StudentId);
            if(s != null)
            {
                return null;
            }

            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        } 

        public async Task<Student> UpdateStudent(Student student)
        {
            var s = await _db.Students.FindAsync(student.StudentId);

            if(s == null)
            {
                return null;
            }
            
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;  
            s.GradeId = student.GradeId;

            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var s = await _db.Students.FindAsync(id);

            if (s == null)
            {
                return null;
            }

            _db.Students.Remove(s);
            await _db.SaveChangesAsync();

            return s;
        }
    }
}
