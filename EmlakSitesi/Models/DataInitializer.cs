using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace EmlakSitesi.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var sehir = new List<Sehir>()
            {
                new Sehir() {SehirAd="Ankara"},
                new Sehir() {SehirAd="İstanbul"},
                new Sehir() {SehirAd="İzmir"}
            };
            foreach (var item in sehir)
            {
                context.Sehirs.Add(item);
            }
            context.SaveChanges();

            var semt = new List<Semt>()
            {
                new Semt() {SemtAd="Sincan",SehirId=1},
                new Semt() {SemtAd="Kağıthane",SehirId=2},
                new Semt() {SemtAd="Torbalı",SehirId=3}
            };
            foreach (var item in semt)
            {
                context.Semts.Add(item);
            }
            context.SaveChanges();

            var mahalle = new List<Mahalle>()
            {
                new Mahalle() {MahalleAd="Plevne",SemtId=1},
                new Mahalle() {MahalleAd="İzzetpaşa",SemtId=2},
                new Mahalle() {MahalleAd="Talatpaşa",SemtId=3}
            };
            foreach (var item in mahalle)
            {
                context.Mahalles.Add(item);
            }
            context.SaveChanges();

            var durum = new List<Durum>()
            {
                new Durum() {DurumAd="Kiralık"},
                new Durum() {DurumAd="Satılık"}
            };
            foreach (var item in durum)
            {
                context.Durums.Add(item);
            }
            context.SaveChanges();

            var tip = new List<Tip>()
            {
                new Tip() {TipAd="Ev",DurumID=1},
                new Tip() {TipAd="Arsa",DurumID=1},
                new Tip() {TipAd="Ev",DurumID=2},
                new Tip() {TipAd="Arsa",DurumID=2},
            };
            foreach (var item in tip)
            {
                context.Tips.Add(item);
            }
            context.SaveChanges();

            var ilan = new List<Ilan>()
            {
                new Ilan() {Aciklama="3+1",Adres="plevne",OdaSayisi=3,BanyoSayisi=1,Kredi=true,Fiyat=2500,MahalleId=1,SemtId=1,SehirId=1,DurumId=1,TipId=1,Alan=250,Telefon="2122121212",Kat="2.kat",UserName="Mehdi"},
                new Ilan() {Aciklama="4+1",Adres="plevne",OdaSayisi=4,BanyoSayisi=2,Kredi=true,Fiyat=3500,MahalleId=2,SemtId=2,SehirId=2,DurumId=2,TipId=1,Alan=350,Telefon="2122121212",Kat="4.kat",UserName="Mehdi"},

            };
            foreach (var item in ilan)
            {
                context.Ilans.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);

            var resim = new List<Resim>()
            {
                new Resim() {ResimAd="1.jpg",IlanId=1},
                new Resim() {ResimAd="2.jpg",IlanId=1},
            };
            foreach (var item in resim)
            {
                context.Resims.Add(item);
            }
            context.SaveChanges();
        }
    }
}