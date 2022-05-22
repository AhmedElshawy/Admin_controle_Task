using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Matrix_Task.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Products
        public async Task<IActionResult> Index(string name, int? category, int? code)
        {
            var dbModel = await _unitOfWork.Products.ListAllAsync(i=>i.ProductPropValues);
            ViewData["Categories"] = await _unitOfWork.Categories.ListAllAsync();

            if (name !=null)
            {
                return View(await _unitOfWork.Products.ListAllAsync(c => c.Name.Contains(name)));
            }
            if(category != null)
            {
                return View(await _unitOfWork.Products.ListAllAsync(c => c.CategoryId == category));
            }
            if (code != null)
            {
                return View(await _unitOfWork.Products.ListAllAsync(c => c.Id == code));
            }
            else
            {
                return View(dbModel);
            }
            
        }
     
        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "CategotyName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Add(product);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (await _unitOfWork.Products.ListAllAsync() == null)
            {
                return NotFound();
            }

            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "CategotyName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Products.Update(product);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool isFound = await ProductExists(product.Id);
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
            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Categories.ListAllAsync(), "Id", "Id", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> FillPropsValues(int id)
        {           

            var product = await _unitOfWork.Products.GetByIdAsync(id);
            var productPropValues = await _unitOfWork.ProductPropValues.GetByIdAsync(product.Id);

            var category = await _unitOfWork.Categories.GetByIdAsync(product.CategoryId);           
            var categoryProp = await _unitOfWork.CategoryProps.FindAsync(c=>c.CategoryId==category.Id);            

            ViewData["categoryProp"] = categoryProp;
           
            return View(productPropValues);
        }


        // POST: ProductPropValues/Create
        [HttpPost]
        public async Task<IActionResult> FillPropsValues([FromForm] ProductPropValues productPropValues , int id)
        {
            if (ModelState.IsValid)
            {
                productPropValues.ProductId = id;
                _unitOfWork.ProductPropValues.Add(productPropValues);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productPropValues);
        }

        private async Task<bool> ProductExists(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product != null) return true;
            return false;
        }
    }
}
