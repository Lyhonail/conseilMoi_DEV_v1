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
using Java.Lang;

namespace conseilMoi.Resources.Classes
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtTypeProfil { get; set; }

        public TextView txtIdProduit { get; set; }

        public TextView txtDate { get; set; }

        public TextView txtNomProduit { get; set; }
    }

    public class ListViewAdapterHistorique:BaseAdapter
    {
        private Activity activity;
        private List<Historiques> lstHistorique;

        public ListViewAdapterHistorique(Activity activity,List<Historiques>lstHistorique)
        {
            this.activity = activity;
            this.lstHistorique = lstHistorique;
            
        }
    
        public override int Count
        {
            get
            {
                return lstHistorique.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return long.Parse(lstHistorique[position].GetIdProduit());
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListViewDataHistorique, parent, false);
            var txtTypeProfil = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtIdProduit = view.FindViewById<TextView>(Resource.Id.textView2);
            var txtNomProduit = view.FindViewById<TextView>(Resource.Id.textView4);
            var txtDate = view.FindViewById<TextView>(Resource.Id.textView3);
            
            txtIdProduit.Text = "" + lstHistorique[position].GetIdProduit();
            txtNomProduit.Text = "" + lstHistorique[position].GetNomProduit();
            txtDate.Text = "" + lstHistorique[position].Getdate();
            
            return view;
        }
    }
}