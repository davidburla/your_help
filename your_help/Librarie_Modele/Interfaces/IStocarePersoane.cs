using System;
using System.Collections.Generic;
using System.Text;
using LibrarieModele;


namespace LibrarieModele_Interfaces
{
  public interface IStocarePersoane: IStocareFactory
  {
    List<Persoana> GetPersoane();

    Persoana GetPersoana(int id);

    bool AddPersoana(Persoana p);

    bool UpdatePersoana(Persoana p);
  }
}
