using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FavoriteList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //this will take care of the action:
        //Home/AddToFavList?Name=songname
        public ActionResult AddToFavList(string Name)
        {
            // setup the session 
            if (Session["FavList"] == null)
            {
                Session.Add("FavList", new HashSet<string>());
            }
            // fetch the list from the session 
            HashSet<string> FavList = (HashSet<string>)Session["FavList"];

            FavList.Add(Name);// added the song to the fav list

            //save list back in session
            Session["FavList"] = FavList;

            ViewBag.FavList = FavList;// sending the favlist to the view

            return View("About");


        }
    }
}