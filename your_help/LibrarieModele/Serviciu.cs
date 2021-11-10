using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibrarieModele
{
  class Serviciu
  {
    public int id_serviciu { get; set; }
    public string nume_serviciu { get; set; }
    public string descriere { get; set; }
    public int id_categorie { get; set; }

    public Serviciu()
    {
    }

    public Serviciu(string nume_serviciu, string descriere, int id_categorie,
      int id_serviciu = 0)
    {
      this.id_serviciu = id_serviciu;
      this.nume_serviciu = nume_serviciu;
      this.descriere = descriere;
      this.id_categorie = id_categorie;
    }
    public Serviciu(DataRow linieDB)
    {
      id_serviciu = Convert.ToInt32(linieDB["id_serviciu"].ToString());
      nume_serviciu = linieDB["nume_serviciu"].ToString();
      descriere = linieDB["descriere"].ToString();
      id_categorie = Convert.ToInt32(linieDB["id_categorie"].ToString());
    }

  }
}
