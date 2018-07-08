using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yatProject.classes
{
    public class availableTekneler
    {

        public static List<string> tekneIdleri;

        private static availableTekneler Rez;
        private availableTekneler()
        {

        }
        public static availableTekneler Rezervasyon()
        {
            if (Rez == null)
            {
                Rez = new availableTekneler();
            }
            return Rez;
        }

    }
}