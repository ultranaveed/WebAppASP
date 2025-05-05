using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Repository.Irepository;
using Microsoft.AspNetCore.Authorization;
using WebApp.Utility;

namespace WebAppASP.Areas.Admin.Controllers{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller{
        
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork )
        {
            _unitOfWork=unitOfWork;
        }
        public IActionResult Index(){
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj){
            if(obj.Name ==obj.DisplayOrder.ToString()){
                ModelState.AddModelError("name","The Display Order cannot be same as name");
            }
            if(ModelState.IsValid){     
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id){
            if(id==null || id==0){
                return NotFound();
            }
            Category? categoryFromDB = _unitOfWork.Category.Get(u=>u.Id==id);
            if (categoryFromDB == null){
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category obj){
            
            if(ModelState.IsValid){     
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id){
            if(id==null || id==0){
                return NotFound();
            }
            Category? categoryFromDB = _unitOfWork.Category.Get(u=>u.Id==id);
            if (categoryFromDB == null){
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id){
            Category? obj = _unitOfWork.Category.Get(u=>u.Id==id);
            if(obj==null){
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}