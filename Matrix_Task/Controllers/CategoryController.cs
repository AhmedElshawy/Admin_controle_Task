using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Matrix_Task.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var dbModel = await _unitOfWork.Categories.ListAllAsync(i=>i.CategoryProp);
            return View(dbModel);
        }

        //// GET: Categories/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["ParentCategotyId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "Id");
            ViewData["ParentCategotyId"] = await _unitOfWork.Categories.ListAllAsync();
            return View();
        }

        //// POST: Categories/Create       
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,CategotyName,ParentCategotyId")] Category category)
        {
            if (ModelState.IsValid)
            {
                 _unitOfWork.Categories.Add(category);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentCategotyId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "Id", category.ParentCategotyId);
            return View(category);
        }

        //// GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (await _unitOfWork.Categories.ListAllAsync() == null)
            {
                return NotFound();
            }

            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["ParentCategotyId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "Id", category.ParentCategotyId);
            return View(category);
        }

        //// POST: Categories/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategotyName,ParentCategotyId")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                    
                    _unitOfWork.Categories.Update(category);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool isFound = await CategoryExists(category.Id);
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
            ViewData["ParentCategotyId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "Id", category.ParentCategotyId);
            return View(category);
        }

        private async Task<bool> CategoryExists(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category != null) return true;
            return false;
        }
    }
}
