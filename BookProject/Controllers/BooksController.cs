using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookProject.Controllers
{
    public class BooksController : Controller
    {
        BooksDbContext context = new BooksDbContext();

        public ActionResult Index()
        {
            List<Book> books = context.Books.ToList();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            Book book = context.Books.SingleOrDefault(b => b.BookID == id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = context.Books.Single(p => p.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            Book _book = context.Books.Single(p => p.BookID == id);

            if (ModelState.IsValid)
            {
                _book.BookName = book.BookName;
                _book.ISBN = book.ISBN;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            Book book = context.Books.Single(p => p.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            Book _book = context.Books.Single(p => p.BookID == id);
            context.Books.Remove(_book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}