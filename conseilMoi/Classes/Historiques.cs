using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace conseilMoi.Resources.Classes
{
    public class Historiques
    {
        String id_produit;
        String nomProduit;
        String date;


        public void CreeHistorique(String idp,String np, String idd)
        {
            id_produit = idp;
            nomProduit = np;
            date = idd;
        }

        
        public String GetIdProduit()
        {
            return id_produit;
        }

        public String Getdate()
        {
            return date;

        }

        public String GetNomProduit()
        {
                return nomProduit;
          
        }
    }
}