using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Furry_Community.Models.VseZayavkiPapka
{
    public class ZayavkiVseClass
    {
        public IEnumerable<Furry_Community.Models.DataBase.help> vse_help;
        public IEnumerable<Furry_Community.Models.DataBase.it_is_me> vse_it_is_me;
        public IEnumerable<Furry_Community.Models.DataBase.how_to_contact_me> vse_how_to_contact_me;
        public int id_zayavki = 0;
        public string stroka_otveta;
        public IEnumerable<Furry_Community.Models.DataBase.response_from_the_manager> vse_response_ot_managera;
    }
}