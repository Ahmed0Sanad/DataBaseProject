using BAL;
using BAL.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace College.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            
            var courses = _unitOfWork.Courses.GetAll();
            return View(courses);
        }

        public IActionResult Details([FromRoute] int id)
        {
            var course = _unitOfWork.Courses.Get(id);
            ViewBag.Pre = _unitOfWork.Courses.GetPrequestes(id);
            return View(course);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Course = _unitOfWork.Courses.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course , List<int> selectedPrerequisites)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Add(course);
             
                _unitOfWork.Courses.AddPrequestes(course.Id, selectedPrerequisites);
               
            
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var Course = _unitOfWork.Courses.Get(id);
            ViewBag.Course = _unitOfWork.Courses.GetAll().Where(c=>c.Id!=id);

            return View(Course);
        }
        [HttpPost]
        public IActionResult Edit(Course course,List<int> selectedPrerequisites)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Update(course);
                _unitOfWork.Courses.UpdatePrequestes(course.Id, selectedPrerequisites);

             
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id) 
        {
            var course = _unitOfWork.Courses.Get(id);
            ViewBag.Pre = _unitOfWork.Courses.GetPrequestes(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Delete(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Courses.Delete(course);
                  
                }
                catch (Exception ex) 
                {
                    return RedirectToAction("Delete",course.Id);
                }
           
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
  
    }
}
