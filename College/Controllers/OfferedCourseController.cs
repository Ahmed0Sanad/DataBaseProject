using BAL.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class OfferedCourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OfferedCourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        [HttpGet]
        public IActionResult Offer([FromRoute] int id)
        {
            ViewBag.course = _unitOfWork.Courses.Get(id);
            return View();
        }
        [HttpPost]
        public IActionResult Offer([FromRoute] int id, OfferedCourse offeredCourse)
        {
            offeredCourse.CourseId = id;
            offeredCourse.Id = 0;
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.OfferdCourse.Add(offeredCourse);
                    //_unitOfWork.Complete();
                    return RedirectToAction("index");
                }
                catch
                {
                    return RedirectToAction("Offer", id);

                }
              
            }
            else
            {
                return View();
            }
        }
        public IActionResult Index()
        {
            var offerdCourses= _unitOfWork.OfferdCourse.GetAll();
            return View(offerdCourses);
        }
  
        public IActionResult Details([FromRoute]int id, [FromRoute] int year) 
        {
            var offeredCourse = _unitOfWork.OfferdCourse.GetWithYear(id, year);
            return View(offeredCourse);
        }
        [HttpGet]
        public IActionResult Edit([FromRoute]int id, [FromRoute] int year) 
        {

            var offeredCourse = _unitOfWork.OfferdCourse.GetWithYear(id, year);
            return View(offeredCourse);
        }
        [HttpPost]
        public IActionResult Edit(OfferedCourse offeredCourse) 
        {
           
            if (ModelState.IsValid)
            {
                _unitOfWork.OfferdCourse.Update(offeredCourse);
           
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id, [FromRoute] int year)
        {
            var course = _unitOfWork.OfferdCourse.GetWithYear(id, year);
            return View(course);
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] int id, [FromRoute] int year,int delete)
        {
            var course = _unitOfWork.OfferdCourse.GetWithYear(id, year);
            _unitOfWork.OfferdCourse.Delete(course);
              
                return RedirectToAction("index");
         
        }
        [HttpGet]
        public IActionResult Enroll([FromRoute] int id, [FromRoute] int year) 
        {
            var course = _unitOfWork.OfferdCourse.GetWithYear(id,year);
            ViewBag.Students=_unitOfWork.OfferdCourse.GetStudentsForCourse(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Enroll([FromRoute] int id, [FromRoute] int year, List<int> Students) 
        {
  
                _unitOfWork.OfferdCourse.AddStudents(id,year,Students);
        
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddInstructor([FromRoute] int id, [FromRoute] int year)
        {
            var course = _unitOfWork.OfferdCourse.GetWithYear(id, year);
            ViewBag.ins=_unitOfWork.OfferdCourse.GetInstructorsForCourse(course);
            return View(course);

        }
        [HttpPost]
        public IActionResult AddInstructor([FromRoute] int id, [FromRoute] int year, List<int> Instructors)
        {
          
            
                _unitOfWork.OfferdCourse.AddInstructor(id,year, Instructors);

               

            
            return RedirectToAction("Index");
        }
    }
}
