using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NivelAccesDate_SQLServer;
using System.Configuration;
using LibrarieModele;
using LibrarieModele_Interfaces;
using NivelAccesDate_SQL;

namespace YourHelp_WebForm
{
  public class StocareFactory
  {
    public IStocareFactory GetTipStocare(Type tipEntitate)
    {
      var formatSalvare = ConfigurationManager.AppSettings["FormatSalvare"];
      if (formatSalvare != null)
      {
        switch (formatSalvare)
        {
          default:
          case "BazaDate_SQLServer":

            if (tipEntitate == typeof(Persoana))
            {
              return new AdministrarePersoane();
            }
            else if (tipEntitate == typeof(Categorie))
            {
              return new AdministrareCategorii();
            }
            else if (tipEntitate == typeof(Offer))
            {
              return new AdministrareOferte();
            }
            else if (tipEntitate == typeof(Serviciu))
            {
              return new AdministrareServicii();
            }
            break;

          case "BazaDate_Oracle":
            if (tipEntitate == typeof(Persoana))
            {
              return new AdministrarePersoane();
            }
            else if (tipEntitate == typeof(Categorie))
            {
              return new AdministrareCategorii();
            }
            else if (tipEntitate == typeof(Offer))
            {
              return new AdministrareOferte();
            }
            else if (tipEntitate == typeof(Serviciu))
            {
              return new AdministrareServicii();
            }
            break;
        }
      }
      return null;
    }
  }
}