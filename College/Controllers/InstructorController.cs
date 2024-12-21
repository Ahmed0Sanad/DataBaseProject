using BAL.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public InstructorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var instructors = _unitOfWork.Instructors.GetAll();
            return View(instructors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Instructors.Add(instructor);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details([FromRoute] int id)
        {
            var ins = _unitOfWork.Instructors.Get(id);
            return View(ins);
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var ins = _unitOfWork.Instructors.Get(id);
            return View(ins);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Instructors.Update(instructor);
                _unitOfWork.Complete();
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
            var ins = _unitOfWork.Instructors.Get(id);
            return View(ins);
        }
        [HttpPost]
        public IActionResult Delete(Instructor instructor)
        {
            _unitOfWork.Instructors.Delete(instructor);
            _unitOfWork.Complete();
            return RedirectToAction("Index");

        }
    }
}
