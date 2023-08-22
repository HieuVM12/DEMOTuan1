using Microsoft.AspNetCore.Mvc;
using projectef.Data;
using projectef.Models;
using System.Linq;
namespace projectef.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhanVienController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<NhanVien> objNhanVienList = _db.NhanViens;
            return View(objNhanVienList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NhanVien obj)
        {
            if (ModelState.IsValid) {
                _db.NhanViens.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var nvFromDb = _db.NhanViens.Find(id);
            // var nvFromDbFirst = _db.NhanViens.FirstOrDefault(x => x.Id == id);
            return View(nvFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NhanVien obj)
        {
            if (ModelState.IsValid)
            {
                _db.NhanViens.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var nvFromDb = _db.NhanViens.Find(id);
            // var nvFromDbFirst = _db.NhanViens.FirstOrDefault(x => x.Id == id);
            return View(nvFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.NhanViens.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.NhanViens.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}
