using InventoryBeginner.Interfaces;
using InventoryBeginner.Models;
using InventoryBeginner.Tools;
using Microsoft.AspNetCore.Mvc;

namespace InventoryBeginner.Controllers
{
    public class UnitsController : Controller
    {
        //private readonly InventoryContext _context;
        //public UnitsController(InventoryContext context)
        //{
        //    _context = context;
        //}

        private readonly IUnit _unitRepo;

        public UnitsController(IUnit unitRepo)
        {
            _unitRepo = unitRepo;
        }

        public IActionResult Index(string sortExpresion = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            ViewBag.SearchText = SearchText;
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("id");
            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.ApplySort(sortExpresion);
            ViewData["sortModel"] = sortModel;

            PaginatedList<Unit> units = _unitRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);

            //int totRec = ((PaginatedList<Unit>)units).TotalRecords;

            var pager = new PagerModel(units.TotalRecords, pg, pageSize);
            pager.SortExpresion = sortExpresion;
            ViewBag.Pager = pager;

            return View(units);
        }
        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }
        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
                //_context.Units.Add(unit);
                //_context.SaveChanges();
                _unitRepo.Create(unit);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            //Unit unit = _context.Units.FirstOrDefault(u => u.Id == id);
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }
        public IActionResult Edit(int id)
        {
            //Unit unit = _context.Units.FirstOrDefault(u => u.Id == id);
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }
        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            //_context.Units.Attach(unit);
            //_context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_context.SaveChanges();
            _unitRepo.Edit(unit);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            //Unit unit = _context.Units.FirstOrDefault(u => u.Id == id);
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }
        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            //_context.Units.Attach(unit);
            //_context.Entry(unit).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //_context.SaveChanges();
            _unitRepo.Delete(unit);
            return RedirectToAction("Index");
        }
    }
}
