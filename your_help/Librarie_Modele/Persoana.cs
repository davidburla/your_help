using System;
using System.Data;

namespace LibrarieModele
{
  public class Persoana
  {
    public int id { get; set; }
    public string nume { get; set; }
    public string prenume { get; set; }
    public string email { get; set; }
    public string pass { get; set; }
    public string telefon { get; set; }

    public Persoana()
    {

    }

    public Persoana(string nume, string prenume, string email, string pass, string telefon, int id = 0 )
    {
      this.id = id;
      this.nume = nume;
      this.prenume = prenume;
      this.email = email;
      this.pass = pass;
      this.telefon = telefon;
    }

    public Persoana ( DataRow linieDB)
    {
      id = Convert.ToInt32(linieDB["id"].ToString());
      nume = linieDB["nume"].ToString();
      email = linieDB["email"].ToString();
      telefon = linieDB["telefon"].ToString();
      prenume = linieDB["prenume"].ToString();
      pass = linieDB["password"].ToString();
    }
  }
}
