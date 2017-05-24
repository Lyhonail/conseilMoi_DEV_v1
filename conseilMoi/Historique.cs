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
using ZXing.Mobile;
using conseilMoi.Resources.Classes;
using conseilMoi.Resources.MaBase;

namespace conseilMoi
{
    [Activity(Label = "Historique")]
    public class Historique : Activity
    {
        ListView lstData;
        List<Historiques> lstSource = new List<Historiques>();
        MaBase db = new MaBase();
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            db.ExistBase(this);
            SetContentView(Resource.Layout.Historique);

            /*var lv = FindViewById<TextView>(Resource.Id.textViewTest);
            lv.Text = db.SelectIdProduittest();*/

            lstData = FindViewById<ListView>(Resource.Id.listView);
            LoadData();


            lstData.ItemClick += (s, e) => {
                for (int i = 0; i < lstData.Count; i++)
                {
                    if (e.Position == i)
                    {
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.DarkGray);
                    }
                    else
                    {
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                    }

                    //Bindind data 
                    var txtproduitid = e.View.FindViewById<TextView>(Resource.Id.textView1);
                    var txttypeid = e.View.FindViewById<TextView>(Resource.Id.textView2);
                    var txtnameproduit = e.View.FindViewById<TextView>(Resource.Id.textView4);
                    var txtdate = e.View.FindViewById<TextView>(Resource.Id.textView3);
                    
                }

            };
            //*****************************************************************************//
            MobileBarcodeScanner.Initialize(Application);

            var menuProfil = FindViewById<ImageView>(Resource.Id.imageViewHistoriqueProfil);
            var menuHistorique = FindViewById<ImageView>(Resource.Id.imageViewHistoriqueHistorique);
            var menuScanner = FindViewById<ImageView>(Resource.Id.imageViewHistoriqueScann);
            var menuConseil = FindViewById<ImageView>(Resource.Id.imageViewHistoriqueConseil);
            var menuAvertissement = FindViewById<ImageView>(Resource.Id.imageViewHistoriqueAvertissement);


            menuProfil.Click += delegate
            {
                StartActivity(typeof(Profil));
            };
            menuHistorique.Click += delegate
            {
                StartActivity(typeof(Historique));
            };

            menuConseil.Click += delegate
            {
                StartActivity(typeof(Conseil));
            };

            //Clik sur le bouton scanner
            menuScanner.Click += async (sender, e) =>
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (result != null)
                {
                    //Intent garde la variable ID Produit et la transmet à l'activité Produit
                    Intent produit = new Intent(this, typeof(Produit));
                    produit.PutExtra("IDproduit", result.Text);
                    StartActivity(produit);
                }
                else { }
            };

            menuAvertissement.Click += delegate
            {
                StartActivity(typeof(Avertissement));
            };

        }

        private void LoadData()
        {
            lstSource = db.SelectHistorique();
            var adapter = new ListViewAdapterHistorique(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}