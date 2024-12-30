using BAL.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var students = _unitOfWork.Students.GetAll();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student) 
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Add(student);
                //_unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details([FromRoute]int id)
        {
            var student=_unitOfWork.Students.Get(id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id) 
        {
            var student = _unitOfWork.Students.Get(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Update(student);
          
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id) 
        {
            
                var student = _unitOfWork.Students.Get(id);
                return View(student);
         
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Students.Delete(student);
         
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Grade([FromRoute] int id)
        {
            
            return View(_unitOfWork.Students.GetGrades(id));
        }
    }
}
