using LibrarieModele;
using LibrarieModele_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YourHelp_MVC.Models;
using YourHelp_WebForm;

namespace YourHelp_MVC.Controllers
{
  public class OfertaController : Controller
  {
    IStocareOffer stocareOferte = (IStocareOffer)new StocareFactory().GetTipStocare(typeof(Offer));
    IStocarePersoane stocarePersoane = (IStocarePersoane)new StocareFactory().GetTipStocare(typeof(Persoana));
    IStocareServiciu stocareServicii = (IStocareServiciu)new StocareFactory().GetTipStocare(typeof(Serviciu));

    // GET: Oferta
    public ActionResult Index()
    {
        return View(stocareOferte.GetOffers());
    }

    public ActionResult Create()
    {
      var servicii = stocareServicii.GetServicii();
      var persoane = stocarePersoane.GetPersoane();
      return View(new OfertaModel(persoane, servicii));
    }

    // Post: Oferta/Create
    [HttpPost]
    public ActionResult Create(OfertaModel ofM)
    {
      if(ModelState.IsValid)
      {
        stocareOferte.AddOffer(ofM.oferta);
      }
      return View("Index", stocareOferte.GetOffers());

    }
  }
}