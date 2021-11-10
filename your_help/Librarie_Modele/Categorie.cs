using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibrarieModele
{
  public class Categorie
  {
    public int id_categorie { get; set; }
    public string nume_categorie { get; set; }

    public Categorie(string nume_categorie, int id_categorie = 0)
    {
      this.id_categorie = id_categorie;
      this.nume_categorie = nume_categorie;
    }

    public Categorie()
    {
    }

    public Categorie(DataRow linieDB)
    {
      nume_categorie = linieDB["name_category"].ToString();
      id_categorie = Convert.ToInt32(linieDB["id_category"].ToString());
    }
  }
}
