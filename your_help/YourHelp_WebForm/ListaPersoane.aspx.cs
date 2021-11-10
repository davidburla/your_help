using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarieModele;
using LibrarieModele_Interfaces;

namespace YourHelp_WebForm
{
  public partial class Persoane : System.Web.UI.Page
  {
    IStocarePersoane stocarePersoane = (IStocarePersoane)new StocareFactory().GetTipStocare(typeof(Persoana));
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public IQueryable<Persoana> GetPersoane()
    {
      return stocarePersoane.GetPersoane().AsQueryable();
    }
  }
}