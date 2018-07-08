using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yatProject.classes
{
    class rezervasyon
    {

        public static string kisiSayisi;
        public static string rezTarihi;
        public static string rezSaati;
        public static string turSaati;
        public static string turTipi;

        private static rezervasyon Rez;
        private rezervasyon ()
        {
            
        }
        public static rezervasyon Rezervasyon(  )
        {
            if (Rez==null)
            {
                Rez = new rezervasyon();
            }
            return Rez;
        }

        
    }
}