using System;
using System.Collections.Generic;
using System.Text;
using LibrarieModele;

namespace LibrarieModele_Interfaces
{
  public interface IStocareCategorie: IStocareFactory
  {
    List<Categorie> GetCategorii();
    Categorie GetCategorie(int id);
    bool AddCategorie(Categorie c);
    bool UpdateCatgorie(Categorie c);
  }
}
