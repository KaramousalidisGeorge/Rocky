using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;//pinaka Category,no queries entity made it all
            return View(objList);
        }
       // GET - CREATE
        public IActionResult Create()
        {
            
            return View();
        }
       
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]//SECURITY,panta stis post methodous
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);//these two commands adding the new category
            _db.SaveChanges();//these two commands adding the new category
            return RedirectToAction("Index");//me to poy ginetai i eisagwgi na emfanizontai oles oi katigories
        }

        //GET - EDIT
        public IActionResult Edit(int? id) // this receives by index.cshtml asp-route-Id="@obj.CategoryId"
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]//SECURITY,panta stis post methodous
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(obj);//these two commands adding the new category
                _db.SaveChanges();//these two commands adding the new category
                return RedirectToAction("Index");//me to poy ginetai i eisagwgi na emfanizontai oles oi katigories
            }
            return View(obj);

        }

        //GET - DELETE
        public IActionResult Delete(int? id) // this receives by index.cshtml asp-route-Id="@obj.CategoryId"
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]//SECURITY,panta stis post methodous
        public IActionResult DeletePost(ApplicationType obj)
        {

            // var obj1 = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ApplicationType.Remove(obj);//these two commands adding the new category
            _db.SaveChanges();//these two commands adding the new category
            return RedirectToAction("Index");//me to poy ginetai i eisagwgi na emfanizontai oles oi katigoriesreturn View(obj);

        }
    }
}
