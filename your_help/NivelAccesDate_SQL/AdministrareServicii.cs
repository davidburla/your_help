using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using LibrarieModele_Interfaces;
using NivelAccesDate_SQLServer;
using NivelAccesDate_SQL;
using System.Data.SqlClient;
using System.Data;

namespace NivelAccesDate_SQL
{
  public class AdministrareServicii: IStocareServiciu
  {
    private const int PRIMUL_TABEL = 0;
    private const int PRIMA_LINIE = 0;
    public List<Serviciu> GetServicii()
    {
      var result = new List<Serviciu>();
      var dsServicii = SqlDBHelper.ExecuteDataSet("select * from dbo.services", CommandType.Text);

      foreach (DataRow linieBD in dsServicii.Tables[PRIMUL_TABEL].Rows)
      {
        var serviciu = new Serviciu(linieBD);
        //incarca entitatile aditionale
        serviciu.categorie = new AdministrareCategorii().GetCategorie(serviciu.id_categorie);
        result.Add(serviciu);
      }
      return result;
    }

    public Serviciu GetServiciu(int id)
    {
      Serviciu result = null;
      var dsServicii = SqlDBHelper.ExecuteDataSet("select * from dbo.services where id_service = @id_service", CommandType.Text,
          new SqlParameter("@id_service", id));

      if (dsServicii.Tables[PRIMUL_TABEL].Rows.Count > 0)
      {
        DataRow linieBD = dsServicii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
        result = new Serviciu(linieBD);
        //incarca entitatile aditionale
        result.categorie = new AdministrareCategorii().GetCategorie(result.id_categorie);
      }
      return result;

    }

    public bool AddServiciu(Serviciu s)
    {
      return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.services VALUES (@nume_serviciu, @descriere, @id_categorie )", CommandType.Text,
                new SqlParameter("@nume_serviciu", s.nume_serviciu),
                new SqlParameter("@descriere", s.descriere),
                new SqlParameter("@id_categorie", s.id_categorie)
            );
    }

    public bool UpdateServiciu(Serviciu s)
    {
      return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.services set name_service = @name_service, description = @description, id_category = @id_category where id_service = @id_service", CommandType.Text,
                 new SqlParameter("@nume_serviciu", s.nume_serviciu),
                new SqlParameter("@descriere", s.descriere),
                new SqlParameter("@id_categorie", s.id_categorie),
                new SqlParameter("@id_service", s.id_serviciu)
            );
    }
  }
}
