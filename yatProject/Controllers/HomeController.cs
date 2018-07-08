using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yatProject.Models;
using yatProject.classes;

namespace yatProject.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult rezSeceneklerTekneGetir()
        {


            return View();
        }
        [HttpPost]
        public ActionResult rezSeceneklerTekneGetir(string seciliRezSaati, string seciliRezTarihi, string seciliTurSaati, string seciliKisiSayisi, string seciliTurTipi)
        {
            rezervasyon.kisiSayisi = seciliKisiSayisi;
            rezervasyon.rezSaati = seciliRezSaati;
            rezervasyon.rezTarihi = seciliRezTarihi;
            rezervasyon.turSaati = seciliTurSaati;
            rezervasyon.turTipi = seciliTurTipi;

            var musaitTekneIdleri = musaitTekneIdleriniGetir(int.Parse(rezervasyon.rezSaati), int.Parse(rezervasyon.turSaati));
            if (availableTekneler.tekneIdleri != null)
            {
                availableTekneler.tekneIdleri.Clear();
            }

            availableTekneler.tekneIdleri = musaitTekneIdleri;


            return RedirectToAction("tekneleriListele", "tekneler");
        }
        public ActionResult About()
        {
            var db = new ApplicationDbContext();
            var Users = db.Users.ToList();

            return View(Users);
        }

        public ActionResult Contact()
        {
            var reiz = dbTekneEntities.baglan().tblYatRezSaatleris.ToList();

            return View(reiz);
        }

        private Dictionary<string, List<bool>> tariheGoreTeknelerRezBilgileriGetir(string tarih)
        {


            var butunSaatler = dbTekneEntities.baglan().tblYatRezSaatleris.Where(x => x.dayDate == tarih).ToList();



            var tekneVeRezSaatleri = new Dictionary<string, List<bool>>();



            foreach (var s in butunSaatler)
            {
                string key = s.productId.ToString();
                List<bool> saatler = new List<bool>();
                saatler.Insert(0, s.s0 ?? false);
                saatler.Insert(1, s.s1 ?? false);
                saatler.Insert(2, s.s2 ?? false);
                saatler.Insert(3, s.s3 ?? false);
                saatler.Insert(4, s.s4 ?? false);
                saatler.Insert(5, s.s5 ?? false);
                saatler.Insert(6, s.s6 ?? false);
                saatler.Insert(7, s.s7 ?? false);
                saatler.Insert(8, s.s8 ?? false);
                saatler.Insert(9, s.s9 ?? false);
                saatler.Insert(10, s.s10 ?? false);
                saatler.Insert(11, s.s11 ?? false);
                saatler.Insert(12, s.s12 ?? false);
                saatler.Insert(13, s.s13 ?? false);
                saatler.Insert(14, s.s14 ?? false);
                saatler.Insert(15, s.s15 ?? false);
                saatler.Insert(16, s.s16 ?? false);
                saatler.Insert(17, s.s17 ?? false);
                saatler.Insert(18, s.s18 ?? false);
                saatler.Insert(19, s.s19 ?? false);
                saatler.Insert(20, s.s20 ?? false);
                saatler.Insert(21, s.s21 ?? false);
                saatler.Insert(22, s.s22 ?? false);
                saatler.Insert(23, s.s23 ?? false);



                tekneVeRezSaatleri.Add(key, saatler);
            }


            return tekneVeRezSaatleri;





        }

        private Dictionary<string, Dictionary<string, List<bool>>> tariheGoreTeknelerRezBilgileriniGetir(string baslamaTarihi, string bitisTarihi)
        {
            var tarihTekneSaatler = new Dictionary<string, Dictionary<string, List<bool>>>();
            var baslangic = DateTime.Parse(baslamaTarihi);
            var bitis = DateTime.Parse(bitisTarihi);
            int kacGu = (bitis - baslangic).Days;

            for (int i = 0; i <= kacGu; i++)
            {
                var basla = baslangic.ToString("dd.MM.yyyy");
                var butunSaatler = dbTekneEntities.baglan().tblYatRezSaatleris.Where(x => x.dayDate == basla).ToList();

                var tekneVeRezSaatleri = new Dictionary<string, List<bool>>();

                foreach (var s in butunSaatler)
                {
                    string key = s.productId.ToString();
                    List<bool> saatler = new List<bool>();
                    saatler.Insert(0, s.s0 ?? false);
                    saatler.Insert(1, s.s1 ?? false);
                    saatler.Insert(2, s.s2 ?? false);
                    saatler.Insert(3, s.s3 ?? false);
                    saatler.Insert(4, s.s4 ?? false);
                    saatler.Insert(5, s.s5 ?? false);
                    saatler.Insert(6, s.s6 ?? false);
                    saatler.Insert(7, s.s7 ?? false);
                    saatler.Insert(8, s.s8 ?? false);
                    saatler.Insert(9, s.s9 ?? false);
                    saatler.Insert(10, s.s10 ?? false);
                    saatler.Insert(11, s.s11 ?? false);
                    saatler.Insert(12, s.s12 ?? false);
                    saatler.Insert(13, s.s13 ?? false);
                    saatler.Insert(14, s.s14 ?? false);
                    saatler.Insert(15, s.s15 ?? false);
                    saatler.Insert(16, s.s16 ?? false);
                    saatler.Insert(17, s.s17 ?? false);
                    saatler.Insert(18, s.s18 ?? false);
                    saatler.Insert(19, s.s19 ?? false);
                    saatler.Insert(20, s.s20 ?? false);
                    saatler.Insert(21, s.s21 ?? false);
                    saatler.Insert(22, s.s22 ?? false);
                    saatler.Insert(23, s.s23 ?? false);



                    tekneVeRezSaatleri.Add(key, saatler);
                }
                tarihTekneSaatler.Add(baslangic.ToString("dd.MM.yyyy"), tekneVeRezSaatleri);

                baslangic = baslangic.AddDays(1);
            }

            return tarihTekneSaatler;

        }

        private List<string> musaitTekneIdleriniGetir(int rezZamani, int turSaati)
        {
            List<string> musaitTekneID = new List<string>();
            List<string> musaitTarihi = new List<string>();


            int gunSayisi = (int.Parse(rezervasyon.rezSaati) + int.Parse(rezervasyon.turSaati)) / 24;
            int forBaslama = rezZamani;
            int forBitis = turSaati + rezZamani;

            int ardisikGunler = 0;
            var bitisGunu = DateTime.Parse(rezervasyon.rezTarihi).AddDays(gunSayisi);
            string bitisTarihiHesapla = bitisGunu.ToString("dd.MM.yyyy");

            var tarihTekneSaat = tariheGoreTeknelerRezBilgileriniGetir(rezervasyon.rezTarihi, bitisTarihiHesapla);
            foreach (var tarih in tarihTekneSaat)
            {
                ardisikGunler++;


                foreach (var item in tarihTekneSaat[tarih.Key])
                {
                    bool buTekneMusait = true;

                    for (int i = forBaslama; i < forBitis; i++)
                    {
                        if (i == 24)
                        {
                            break;
                        }

                        if (item.Value[i])
                        {

                        }
                        else
                        {
                            buTekneMusait = false;

                            break;

                        }
                    }
                    if (buTekneMusait)
                    {
                        musaitTekneID.Add(item.Key);
                        musaitTarihi.Add(tarih.Key);
                    }

                }

                if (ardisikGunler > 0)
                {
                    forBaslama = 0;
                    forBitis = 24;
                    if (gunSayisi == ardisikGunler)
                    {
                        forBitis = (rezZamani + turSaati) % 24;
                    }
                    //tarihTekneSaat[tarih.Key][musaitTarihi[0]][]
                }
            }

            if (gunSayisi > 0)
            {

                var baslangicim = DateTime.Parse(rezervasyon.rezTarihi);

                List<string> ayniTarihMusaitler = new List<string>();
                var tariMusaitler = new Dictionary<string, List<string>>();

                for (int i = 0; i < musaitTarihi.Count; i++)
                {
                    var basla = baslangicim.ToString("dd.MM.yyyy");
                    if (musaitTarihi[i] == basla)
                    {
                        ayniTarihMusaitler.Add(musaitTekneID[i]);

                        if (i == musaitTarihi.Count - 1)
                        {
                            tariMusaitler.Add(basla, ayniTarihMusaitler);
                            baslangicim = baslangicim.AddDays(1);


                        }
                    }
                    else
                    {


                        tariMusaitler.Add(basla, ayniTarihMusaitler);
                        baslangicim = baslangicim.AddDays(1);
                        ayniTarihMusaitler = new List<string>();
                        i--;
                    }
                }
                if (tariMusaitler.Count == gunSayisi+1)
                {


                    var ilkgunDate = DateTime.Parse(rezervasyon.rezTarihi);

                    var ilkGunStr = ilkgunDate.ToString("dd.MM.yyyy");
                    var sonrakiGunStr = ilkgunDate.AddDays(1).ToString("dd.MM.yyyy");
                    var enSonGunStr = ilkgunDate.AddDays(gunSayisi).ToString("dd.MM.yyyy");
                    List<string> aynen = new List<string>();
                    for (int i = 0; i < gunSayisi; i++)
                    {


                        tariMusaitler[sonrakiGunStr] = tariMusaitler[ilkGunStr].Intersect(tariMusaitler[sonrakiGunStr]).ToList();

                        ilkgunDate = ilkgunDate.AddDays(1);
                        ilkGunStr = ilkgunDate.ToString("dd.MM.yyyy");
                        sonrakiGunStr = ilkgunDate.AddDays(1).ToString("dd.MM.yyyy");

                    }
                    if (tariMusaitler[enSonGunStr].Count > 0)
                    {
                        musaitTekneID = tariMusaitler[enSonGunStr];
                    }
                    else
                    {
                        musaitTekneID = null;
                    }
                }
                else
                {
                    musaitTekneID = null;
                }
            }

            if (musaitTekneID != null && musaitTekneID.Count == 0)
            {
                musaitTekneID = null;
            }

            return musaitTekneID;
        }

        public void sqlGunEkle()
        {
            int sayac =50;
            if (Request.QueryString["kactane"]!=null)
            {
                sayac = int.Parse(Request.QueryString["kactane"]);
            }
            

            for (int i = 0; i < sayac; i++)
            {
                var row = new tblYatRezSaatleri();

                row.dayDate = "11.08.2018";
                row.productId = i;
                row.s0 = true;
                row.s1 = true;
                row.s2 = true;
                row.s3 = true;
                row.s4 = true;
                row.s5 = true;
                row.s6 = true;
                row.s7 = true;
                row.s8 = true;
                row.s9 = true;
                row.s10 = true;
                row.s11 = true;
                row.s12 = true;
                row.s13 = true;
                row.s14 = true;
                row.s15 = true;
                row.s16 = true;
                row.s17 = true;
                row.s18 = true;
                row.s19 = true;
                row.s20 = true;
                row.s21 = true;
                row.s22 = true;
                row.s23 = true;
                dbTekneEntities.baglan().tblYatRezSaatleris.Add(row);

            }
            dbTekneEntities.baglan().SaveChanges();



        }
       
        public void re()
        {
            var sonuc = dbTekneEntities.baglan().tblYatRezSaatleris.ToList();

            foreach (var item in sonuc)
            {
                foreach (var r in sonuc)
                {
                    if (item.productId == r.productId && item.dayDate == r.dayDate)
                    {
                        dbTekneEntities.baglan().tblYatRezSaatleris.Remove(r);
                        dbTekneEntities.baglan().SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}