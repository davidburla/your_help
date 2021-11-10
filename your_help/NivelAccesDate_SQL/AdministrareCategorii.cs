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
  public class AdministrareCategorii: IStocareCategorie
  {
    private const int PRIMUL_TABEL = 0;
    private const int PRIMA_LINIE = 0;

    public List<Categorie> GetCategorii()
    {
      var result = new List<Categorie>();
      var dsCategorii = SqlDBHelper.ExecuteDataSet("select * from dbo.categories", CommandType.Text);

      foreach (DataRow linieDB in dsCategorii.Tables[PRIMUL_TABEL].Rows)
      {
        result.Add(new Categorie(linieDB));
      }
      return result;
    }
    public Categorie GetCategorie(int id)
    {
      Categorie result = null;
      var dsCategorii = SqlDBHelper.ExecuteDataSet("select * from dbo.categories where id_category = @id_category", CommandType.Text,
          new SqlParameter("@id_category", id));

      if (dsCategorii.Tables[PRIMUL_TABEL].Rows.Count > 0)
      {
        DataRow linieDB = dsCategorii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
        result = new Categorie(linieDB);
      }
      return result;
    }
    public bool AddCategorie(Categorie cat)
    {
      return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.categories VALUES (@Nume)", CommandType.Text,
                new SqlParameter("@Nume", cat.nume_categorie));
    }
    public bool UpdateCatgorie(Categorie cat)
    {
      return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.categories set name_category = @Nume where id_category = @id_category", CommandType.Text,
                new SqlParameter("@Nume", cat.nume_categorie),
                new SqlParameter("@id_category", cat.id_categorie));
    }
  }
}
