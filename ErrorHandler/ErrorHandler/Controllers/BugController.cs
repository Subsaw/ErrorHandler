using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ErrorHandler.Models;  

namespace ErrorHandler.Controllers
{
    public class BugController : Controller
    {

        private static IList<Bug> bugs = new List<Bug>
        {
            new Bug(){Id = 1, Title = "Lorem ipsum", Description = "Lorem ipsum etc ", Importance = 3},
            new Bug(){Id = 2, Title = "Bład w linijce 21", Description = "Ta linijka jest pusta a nie powinna", Importance = 10},
            new Bug(){Id = 3, Title = "Spadanie w linijce 99", Description = "Kod spada tam i jest wielka przerwa", Importance = 2},
        };

        // GET: BugController
        public ActionResult Index()
        {
            return View(bugs);
        }

        // GET: BugController/Details/5
        public ActionResult Details(int id)
        {
            return View(bugs.FirstOrDefault(x => x.Id == id));
        }

        // GET: BugController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BugController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bug bug)
        {
            bug.Id = bugs.Count + 1;
            bugs.Add(bug);
            return RedirectToAction("Index");
        }

        // GET: BugController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(bugs.FirstOrDefault(x => x.Id == id));
        }

        // POST: BugController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Bug bug)
        {
            Bug bug1 = bugs.FirstOrDefault(x => x.Id == id);
            bug1.Title = bug.Title;
            bug1.Description = bug.Description;
            bug1.Importance = bug.Importance;

            return RedirectToAction("Index");
        }

        // GET: BugController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bugs.FirstOrDefault(x => x.Id == id));
        }

        // POST: BugController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Bug bug1 = bugs.FirstOrDefault(x => x.Id == id);
            bugs.Remove(bug1);

            return RedirectToAction("Index");
        }
    }
}
