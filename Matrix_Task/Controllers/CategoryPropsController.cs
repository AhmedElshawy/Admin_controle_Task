using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Matrix_Task.Controllers
{
    public class CategoryPropsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryPropsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CategoryProps
        public async Task<IActionResult> Index()
        {
            var dbModel = await _unitOfWork.CategoryProps.ListAllAsync(i=>i.Category);
            return View(dbModel);
        }    

        // GET: CategoryProps/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "CategotyName");
            return View();
        }

        // POST: CategoryProps/Create       
        [HttpPost]
        public async Task<IActionResult> Create( [FromForm] CategoryProp categoryProp,int id)
        {
            if (ModelState.IsValid)
            {
                categoryProp.CategoryId = id;
                _unitOfWork.CategoryProps.Add(categoryProp);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryProp);
        }

        // GET: CategoryProps/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (_unitOfWork.CategoryProps.ListAllAsync() == null)
            {
                return NotFound();
            }

            var categoryProp = await _unitOfWork.CategoryProps.GetByIdAsync(id);
            if (categoryProp == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "CategotyName", categoryProp.CategoryId);
            return View(categoryProp);
        }

        // POST: CategoryProps/Edit/5      
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] CategoryProp categoryProp)
        {
            if (id != categoryProp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                
                    _unitOfWork.CategoryProps.Update(categoryProp);
                    await _unitOfWork.CompleteAsync();  
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool isFound = await CategoryPropExists(categoryProp.Id);
                    if (!isFound)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "CategotyName", categoryProp.CategoryId);
            return View(categoryProp);
        }
        
        private async Task<bool> CategoryPropExists(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category != null) return true;
            return false;
        }
    }
}
