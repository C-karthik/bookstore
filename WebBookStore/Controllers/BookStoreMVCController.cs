using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBookStore.Models;

namespace WebBookStore.Controllers
{
    public class BookStoreMVCController : Controller
    {
        ModelOperation modelOperation = new ModelOperation();
        
        public ActionResult Index()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View();
        }

        public ActionResult BookStore()
        {
            return View();
        }

        public ActionResult User()
        {
            return View();
        }

        public ActionResult Details()
        {
            IEnumerable<BookStoreModel> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61245/api/");
               
                var responseTask = client.GetAsync("BookStore");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookStoreModel>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
                else 
                {
                    books = Enumerable.Empty<BookStoreModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            if (TempData["message"] != null)
            {
                TempData.Keep();
                return View(books);
            }
            else
            {
                TempData["message"] = "Invalid credetials";
                return RedirectToAction("LogHere", "Login");
            }
           
        }

       
        public ActionResult AddBooks()
        {
            return View(new BookStoreModel());
        }

        
        [HttpPost]
        public ActionResult AddBooks(BookStoreModel storeModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61245/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<BookStoreModel>("BookStore", storeModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(storeModel);
        }



        public ActionResult BookDetails()
        {
            IEnumerable<BookStoreModel> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61245/api/");

                var responseTask = client.GetAsync("BookStore");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookStoreModel>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
                else
                {
                    books = Enumerable.Empty<BookStoreModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            if (TempData["message"] != null)
            {
                TempData.Keep();
                return View(books);
            }
            else
            {
                TempData["message"] = "Invalid credetials";
                return RedirectToAction("LogHere", "Login");
            }

        }

        [HttpPost]
        public ActionResult AddFavBook( int id)
        {
            BookStoreModel books = null;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61245/api/");
              
                var responseTask = client.GetAsync("BookStore?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookStoreModel>();
                    readTask.Wait();

                    books = readTask.Result;
                }
            }

            return RedirectToAction("FavList");
        }
    

        public ActionResult FavList()
        {
            IEnumerable<BookStoreModel> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61245/api/");

                var responseTask = client.GetAsync("BookStore/GetFavList");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookStoreModel>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
                else
                {
                    books = Enumerable.Empty<BookStoreModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            if (TempData["message"] != null)
            {
                TempData.Keep();
                return View(books);
            }
            else
            {
                TempData["message"] = "Invalid credetials";
                return RedirectToAction("LogHere", "Login");
            }

        }



       
        public ActionResult Purchase(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61245/api/");
               
                var deleteTask = client.DeleteAsync("BookStore/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("FavList");
                }
            }
            return RedirectToAction("FavList");
        }
   
    }
}
