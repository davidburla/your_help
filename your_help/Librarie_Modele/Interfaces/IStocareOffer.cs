using System;
using System.Collections.Generic;
using System.Text;
using LibrarieModele;


namespace LibrarieModele_Interfaces
{
  public interface IStocareOffer: IStocareFactory
  {
    List<Offer> GetOffers();

    Offer GetOffer(int id_persoana, int id_serviciu);

    bool AddOffer(Offer o);

    bool UpdateOffer(Offer o);
  }
}
