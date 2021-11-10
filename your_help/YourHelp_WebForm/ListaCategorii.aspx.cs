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
  public partial class ListaCategorii : System.Web.UI.Page
  {
    IStocareCategorie stocareCategorii = (IStocareCategorie)new StocareFactory().GetTipStocare(typeof(Categorie));
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public IQueryable<Categorie> GetCategorii()
    {
      return stocareCategorii.GetCategorii().AsQueryable();
    }
  }
}

