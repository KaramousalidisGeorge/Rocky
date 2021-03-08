using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _db;
        


        public QuestionController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: QuestionController
        public IActionResult Index()
        {
            var webClient = new WebClient();
            //var json = webClient.DownloadString(@"C:\Users\Γιώργος\Desktop\Rocky\Rocky\wwwroot\countries.json");
            var json = webClient.DownloadString(@"C:\Users\Γιώργος\Desktop\Rocky\Rocky\wwwroot\publish-survey.json");
           //// var countries = JsonConvert.DeserializeObject<Countries>(json);
            var questions1 = JsonConvert.DeserializeObject<Root>(json);


            return View(questions1);
        }



        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]//SECURITY,panta stis post methodous
        public IActionResult Create(Question obj)
        {
            var webClient = new WebClient();
            string json = webClient.DownloadString(@"C:\Users\Γιώργος\Desktop\Rocky\Rocky\wwwroot\publish-survey.json");
            
         List<Question> questionsList=JsonConvert.DeserializeObject<List<Question>>(json);
            //var questions1 = JsonConvert.DeserializeObject<Question>(json);
            // var questions2 = JsonConvert.DeserializeObject<Question>(json);

            // _db.Root.Add(questions1);
            foreach (var item in questionsList)
            {
               
                _db.Question.Add(obj);
            }
            _db.SaveChanges();
            // _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: QuestionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View();
        }

        

        // GET: QuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
