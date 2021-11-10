using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarieModele_Interfaces
{
  public interface IStocareServiciu: IStocareFactory
  {
    List<Serviciu> GetServicii();

    Serviciu GetServiciu(int id);

    bool AddServiciu(Serviciu s);

    bool UpdateServiciu(Serviciu s);
  }
}
