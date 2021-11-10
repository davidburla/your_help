using LibrarieModele;
using LibrarieModele_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourHelp_WebForm
{
  public partial class ListaServicii : System.Web.UI.Page
  {
    IStocareServiciu stocareServicii = (IStocareServiciu)new StocareFactory().GetTipStocare(typeof(Serviciu));
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public IQueryable<Serviciu> GetServicii()
    {
      return stocareServicii.GetServicii().AsQueryable();
    }
  }
}