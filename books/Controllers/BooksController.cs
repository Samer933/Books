using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using books.Models;
using books.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;
using System.Net;
using System.Web.Services.Description;

namespace books.Controllers
{
    public class BooksController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public BooksController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Books
        public ActionResult Index()
        {



            var books = _dbContext.Books.Include(m => m.Category).ToList();


           

            return View(books);
        }


        public ActionResult Create()
        {
            var viewModel = new BookFormViewModel()
            {
                Categories = _dbContext.Categories.Where(m => m.IsActive).ToList()
            };



            return View("BookForm",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookFormViewModel model)
        {

            if (!ModelState.IsValid)
            {

                model.Categories = _dbContext.Categories.Where(m => m.IsActive).ToList();
                return View("BookForm", model);
            }

            if (ModelState.IsValid)
            {


                var book = new Books
                {
                    Title = model.Title,
                    Author = model.Author,
                    Description = model.Description,
                    CategoryId = model.CategoryId
                };


                _dbContext.Books.Add(book);

                _dbContext.SaveChanges();
            }



            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? idBook)

        {


            Debug.Print(idBook.ToString());


            if (idBook == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var book = _dbContext.Books.Find(idBook);


            if (book == null)
            {
                return HttpNotFound();
            }


            var viewModel = new BookFormViewModel
            {

                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                Categories = _dbContext.Categories.Where(m => m.IsActive).ToList()
            };

            return View("BookForm", viewModel);

        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = _dbContext.Books.Include(m => m.Category).SingleOrDefault(m => m.Id == id);

            if (book == null)
            {
                return HttpNotFound();

            }

            return View(book);
        }

    }
}