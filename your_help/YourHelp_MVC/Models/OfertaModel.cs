using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourHelp_MVC.Models
{
  public class OfertaModel
  {
    public Offer oferta { get; set; }
    public List<Persoana> persoane { get; set; }
    public List<Serviciu> servicii { get; set; }
    public OfertaModel()
    {
      oferta = new Offer();
      persoane = new List<Persoana>();
      servicii = new List<Serviciu>();
    }

    public OfertaModel(List<Persoana> persoane_, List<Serviciu> servicii_)
    {
      oferta = new Offer();
      persoane = persoane_;
      servicii = servicii_;
    }

    public OfertaModel( Offer oferta_, List<Persoana> persoane_, List<Serviciu> servicii_)
    {
      oferta = oferta_;
      persoane = persoane_;
      servicii = servicii_;
    }
  }
}