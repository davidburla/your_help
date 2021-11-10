using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using LibrarieModele_Interfaces;
using NivelAccesDate_SQLServer;

namespace NivelAccesDate_SQL
{

  public class AdministrarePersoane: IStocarePersoane
  {
    private const int PRIMUL_TABEL = 0;
    private const int PRIMA_LINIE = 0;

    public List<Persoana> GetPersoane()
    {
      var result = new List<Persoana>();
            var dsPersoane = SqlDBHelper.ExecuteDataSet("select * from dbo.persoane", CommandType.Text);

            foreach (DataRow linieDB in dsPersoane.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add( new Persoana(linieDB));
            }
            return result;
    }
    public Persoana GetPersoana(int id)
    {
      Persoana result = null;
      var dsPersoane = SqlDBHelper.ExecuteDataSet("select * from dbo.persoane where id = @id_persoana", CommandType.Text,
          new SqlParameter("@id_persoana", id));

      if (dsPersoane.Tables[PRIMUL_TABEL].Rows.Count > 0)
      {
        DataRow linieDB = dsPersoane.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
        result = new Persoana(linieDB);
      }
      return result;
    }
    public bool AddPersoana(Persoana pers)
    {
      return SqlDBHelper.ExecuteNonQuery(
          "INSERT INTO dbo.persoane VALUES (@nume, @prenume @email, @password, @telefon)", CommandType.Text,
          new SqlParameter("@nume", pers.nume),
          new SqlParameter("@prenume", pers.nume),
          new SqlParameter("@email", pers.email),
          new SqlParameter("@password", pers.pass),
          new SqlParameter("@telefon", pers.telefon));
    }

    public bool UpdatePersoana(Persoana pers)
    {
      return SqlDBHelper.ExecuteNonQuery(
          "UPDATE dbo.persoane set nume = @nume, prenume = @prenume, email = @email, password = @password, telefon = @telefon where id = @id", CommandType.Text,
          new SqlParameter("@nume", pers.nume),
          new SqlParameter("@prenume", pers.nume),
          new SqlParameter("@email", pers.email),
          new SqlParameter("@password", pers.pass),
          new SqlParameter("@telefon", pers.telefon),
          new SqlParameter("@id", pers.id));
    }
  }
}
