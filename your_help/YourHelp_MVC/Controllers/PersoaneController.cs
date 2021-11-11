using LibrarieModele;
using LibrarieModele_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourHelp_WebForm;

namespace YourHelp_MVC.Controllers
{
  public class PersoaneController : Controller
  {
    IStocarePersoane stocarePersoane = (IStocarePersoane)new StocareFactory().GetTipStocare(typeof(Persoana));
    // GET: Persoane
    public ActionResult Index()
    {
        return View(stocarePersoane.GetPersoane());
    }
    // GET: Persoane/Persoana/id
    public ActionResult Details(int id)
    {
      return View(stocarePersoane.GetPersoana(id));
    }

    // Get: Persoane/Create
    public ActionResult Create()
    {
      return View(new Persoana());
    }

    // Post: Persoane/Create
    [HttpPost]
    public ActionResult Create(Persoana p)
    {
      try
      {
        var result = stocarePersoane.AddPersoana(p);
        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // Get: Persoane/Edit/id
    public ActionResult Edit(int id)
    {
      return View(stocarePersoane.GetPersoana(id));
    }

    // POST: Persoane/Edit/5
    [HttpPost]
    public ActionResult Edit(Persoana p)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var result = stocarePersoane.UpdatePersoana(p);;
        }

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

  }
}