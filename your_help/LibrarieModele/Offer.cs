using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibrarieModele
{
  class Offer
  {
    public int id_persoana { get; set; }

    public int id_serviciu { get; set; }

    public bool is_valid { get; set; }

    public Offer()
    {
    }

    public Offer(int id_persoana, int id_serviciu, bool is_valid)
    {
      this.id_persoana = id_persoana;
      this.id_serviciu = id_serviciu;
      this.is_valid = is_valid;
    }

    public Offer (DataRow linieDB)
    {
      id_persoana = Convert.ToInt32(linieDB["id_persoana"].ToString());
      id_serviciu = Convert.ToInt32(linieDB["id_serviciu"].ToString());
      is_valid = Convert.ToBoolean(linieDB["is_valid"].ToString());
    }
  }
}
