using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using LibrarieModele_Interfaces;
using NivelAccesDate_SQLServer;
using NivelAccesDate_SQL;
using System.Data.SqlClient;

namespace NivelAccesDate_SQL
{
  public class AdministrareOferte: IStocareOffer
  {
    private const int PRIMUL_TABEL = 0;
    private const int PRIMA_LINIE = 0;

    public List<Offer> GetOffers()
    {
      var result = new List<Offer>();
      var dsOferte = SqlDBHelper.ExecuteDataSet("select * from dbo.offer", CommandType.Text);

      foreach (DataRow linieBD in dsOferte.Tables[PRIMUL_TABEL].Rows)
      {
        var oferta = new Offer(linieBD);
        //incarca entitatile aditionale
        oferta.persoana = new AdministrarePersoane().GetPersoana(oferta.id_persoana);
        result.Add(oferta);
      }
      return result;
    }

    public Offer GetOffer(int id_persoana, int id_serviciu)
    {
      Offer result = null;
      var dOferte = SqlDBHelper.ExecuteDataSet("select * from dbo.offer where id_persoana = @id_persoana and id_serviciu = @id_serviciu", CommandType.Text,
          new SqlParameter("@id_persoana", id_persoana),
          new SqlParameter("@id_serviciu", id_serviciu));

      if (dOferte.Tables[PRIMUL_TABEL].Rows.Count > 0)
      {
        DataRow linieBD = dOferte.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
        result = new Offer(linieBD);
        //incarca entitatile aditionale
        result.persoana = new AdministrarePersoane().GetPersoana(result.id_persoana);
        result.servciu = new AdministrareServicii().GetServiciu(result.id_serviciu);
      }
      return result;
    }

    public bool AddOffer(Offer o)
    {
      return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.offer VALUES (@id_persoana, @id_serviciu, @is_valid)", CommandType.Text,
                new SqlParameter("@id_persoana", o.id_persoana),
                new SqlParameter("@id_serviciu", o.id_serviciu),
                new SqlParameter("@is_valid", o.is_valid)
            );
    }

    public bool UpdateOffer(Offer o)
    {
      return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.offer set is_valid = @is_valid where id_persoana=@id_persoana and id_serviciu = @id_serviciu", CommandType.Text,
                 new SqlParameter("@is_valid", o.is_valid),
                new SqlParameter("@id_persoana", o.id_persoana),
                new SqlParameter("@id_serviciu", o.id_serviciu)
            );
    }
  }
}
