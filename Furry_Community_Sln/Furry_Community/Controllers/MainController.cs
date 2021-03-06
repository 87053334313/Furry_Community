using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using Furry_Community.Models.DataBase;
using Furry_Community.Models.AddPerson;
using Furry_Community.Models;
using Furry_Community.Models.PoiskPoId;
using Furry_Community.Models.VseZayavkiPapka;
using Furry_Community.Models.Patrul;

namespace Furry_Community.Controllers
{
    public class MainController : Controller
    {
        // GET: Main

        public ActionResult Registration()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
        Furry_DB db = new Furry_DB();
        public ActionResult ItIsMeAll()
        {
                 
           
                var zapros = from t in db.it_is_me
                             select t;
                ViewBag.zapr1 = (Object)zapros;
                
                return View();
        }


        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public string DeletePersonReal(int id)
        {
            try
            {
                var _del = db.it_is_me.Where(str => str.ID_I == id).FirstOrDefault();
                db.it_is_me.Remove(_del);
                db.SaveChanges();
                return "Delete was sucsess";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        public string AddPersonReal(string f, string s, string p)
        {
            try
            {

                var person = new it_is_me()
                {
                    First_name = f,
                    Second_name = s,
                    Patronymic = p,
                    ID_how_to_contact_me = 1,
                    ID_reputation = 1,
                    Parol = "123"
                };
                db.it_is_me.Add(person);
                db.SaveChanges();
                return "Vse uspeshno dobavilos";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }


        [HttpPost]
        public string UpdateReal(int id,string name,string second,string pat,string parol)
        {
            try
            {
                var upt = db.it_is_me.Where(x => x.ID_I == id).FirstOrDefault();
                upt.First_name = name;
                upt.Second_name = second;
                upt.Patronymic = pat;
                upt.Parol = parol;
                db.SaveChanges();
                return "Все успешно обновилось";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }


        public ActionResult AddFromFullRegistration(string fname, string sname, string tname, string parol, string tel, string email)
        {
            try
            {
                how_to_contact_me id_how = new how_to_contact_me()
                {
                    email = email,
                    tepelhone = tel

                };
                db.how_to_contact_me.Add(id_how);
                db.SaveChanges();

                var predZapr = db.how_to_contact_me.Where(x => (x.email == email && x.tepelhone == tel)).FirstOrDefault();
                int id_this = predZapr.ID_how_to_contact_me;

                int rep = 1;

                it_is_me me_new = new it_is_me()
                {
                    First_name=fname,
                    Second_name=sname,
                    Patronymic=tname,
                    ID_how_to_contact_me= id_this,
                    ID_reputation=rep,
                    Parol=parol
                };
                db.it_is_me.Add(me_new);
                db.SaveChanges();
                string uspex="Всё успешно добавилось";
                ViewData["uspex"] = uspex;
                return View("VseUspeshno");
            }
            catch(Exception ex)
            {

                string oshibka="Произошла ошибка"+"\n"+ex.ToString();
                ViewData["oshibka"] = oshibka;
                return View("Oshibka");

            }
        }



        public ActionResult Vvod_Dlya_AllInformation(string name, string parol)
        {
            //try
            //{
            if (db.it_is_me.Where(x => x.Parol == parol).Any() && db.how_to_contact_me.Where(x=>x.email==name).Any())
            {
                var stroka_po_email = db.how_to_contact_me.Where(x => x.email == name).FirstOrDefault();
                int id_po_email = stroka_po_email.ID_how_to_contact_me;
                var this_rez = db.it_is_me.Where(x => x.Parol == parol && x.ID_how_to_contact_me==id_po_email).FirstOrDefault();
                int this_id = this_rez.ID_I;
                if (!db.all_information.Any(o => o.it_is_me == this_id))
                {
                    your_id = this_id;
                    all_information new_all_inf = new all_information() { it_is_me = this_id, id_all = this_id };
                    db.all_information.Add(new_all_inf);
                    db.SaveChanges();
                    ViewData["id"] = this_id;
                    //класс(модель) для передачи в представление
                    it_is_me need_person = db.it_is_me.Where(x => x.ID_I == this_id).FirstOrDefault();
                    return View("All_Information_Profil", need_person);
                }
                else
                {
                    your_id = this_id;
                    ViewData["id"] = this_id;
                    //класс(модель) для передачи в представление
                    it_is_me need_person = db.it_is_me.Where(x => x.ID_I == this_id).FirstOrDefault();
                    return View("All_Information_Profil", need_person);
                }
            }
            else
            {
                return View("Takoy_Polzovatel_Ne_Sushestvuet");
            }
            //}
            //catch(Exception ex)
            //{
            //    ViewData["ex"] ="Проищошла ошибка при вводе данных"+"\n"+ex.ToString();
            //    return View("Oshibka");
            //}
        }

        public ActionResult All_Information_Vvod()
        {
            return View();
        }


        public ActionResult Help_Start()
        {
            return View();
        }
        public static int your_id;
        public ActionResult StartProfil_PoId()
        {
            int this_id = your_id;
            it_is_me need_person = db.it_is_me.Where(x => x.ID_I == this_id).FirstOrDefault();
            return View("All_Information_Profil", need_person); 
        }
        public ActionResult Help_text()
        {
            if (!db.help.Where(x=>x.ssylka_id==your_id).Any())
            {
                ViewBag.MyPriutHelp = null;
                return View();
            }
            IEnumerable<help> spisok_moih_pomoshey = from table in db.help
                                                     where table.ssylka_id == your_id
                                                     select table;

            ViewBag.MyPriutHelp = spisok_moih_pomoshey;
            return View();
        }


        public ActionResult Help_Text_Redact()
        {
           
            return View();
        }

        public ActionResult Zapolnenie_Pomoshi(string text_to_help, string text_i_need_help)
        {
            help izmen = db.help.Where(x => x.ssylka_id == your_id).FirstOrDefault();
            izmen.How_can_i_help = text_to_help;
            izmen.What_help_do_I_need = text_i_need_help;
            db.SaveChanges();
            ViewData["newHelp"] = "Изменения успешно обновлены:";
            help myhelpindex = db.help.Where(x => x.ssylka_id== your_id).FirstOrDefault();
            return View("Help_Text",myhelpindex);
        }


        public ActionResult AddFoto(string foto)
        {

            if (String.IsNullOrEmpty(foto))
            {
                return View("Oshibka");
            }
            byte[] imageByte =  System.IO.File.ReadAllBytes(foto);
            
            it_is_me this_class=db.it_is_me.Where(x => x.ID_I == your_id).FirstOrDefault();
            this_class.Photo = imageByte;
            db.SaveChanges();
            it_is_me me = db.it_is_me.Where(x => x.ID_I == your_id).FirstOrDefault();
            return View("All_Information_Profil", me);
        }


        public ActionResult Help_I_Found()
        {
            var your_zayavki = from tab in db.I_found
                               where tab.ssylka_id == your_id
                               select tab;
            List<I_found> your_spisok_I_found = your_zayavki.ToList();
            ViewData["I_Found_Zayavki_Vse"] = your_spisok_I_found;
            return View("Help_I_Found_Your_Zayavki");
        }


        public ActionResult Add_I_Found(string geolocation, string information, DateTime date_found, string animal_photo)
        {
            I_found add_to_i_Found = new I_found();
            add_to_i_Found.geolocation = geolocation;
            add_to_i_Found.information = information;
            add_to_i_Found.ssylka_id = your_id;
            byte[] image_byte=null;
            if(!String.IsNullOrEmpty(animal_photo))
            image_byte=System.IO.File.ReadAllBytes(animal_photo);
            add_to_i_Found.animal_photo = image_byte;
            add_to_i_Found.date_found = date_found;
            db.I_found.Add(add_to_i_Found);
            db.SaveChanges();
            var vse_stroki = from table in db.I_found
                             where table.ssylka_id == your_id
                             select table;
            ViewData["I_Found_Zayavki_Vse"] = vse_stroki;
            return View("Help_I_Found_Your_Zayavki");
        }

        public ActionResult DeleteYour_I_Found_PoId(int id_num)
        {
          I_found stroka_del_i_found = db.I_found.Where(x => x.ID_I_found == id_num).FirstOrDefault();
            db.I_found.Remove(stroka_del_i_found);
            db.SaveChanges();
            if (db.I_found.Where(x => x.ssylka_id == your_id).Any())
            {
                var vse_stroki = from table in db.I_found
                                 where table.ssylka_id == your_id
                                 select table;
                ViewData["I_Found_Zayavki_Vse"] = vse_stroki;
                return View("Help_I_Found_Your_Zayavki");
            }
            else
            {
                ViewData["I_Found_Zayavki_Vse"] = null;
                return View("Help_I_Found_Your_Zayavki");
            }
        }

        public ActionResult Help_I_Lost()
        {
            if (db.I_have_lost.Where(x => x.ssylka_id == your_id).Any())
            {

                var rez = from table in db.I_have_lost
                          where table.ssylka_id == your_id
                          select table;
                ViewData["I_Have_Lost"] = rez;
                return View("Help_I_Lost");
            }
            else
            {
                ViewData["I_Have_Lost"] = null;
                return View("Help_I_Lost");
            }
        }


        public ActionResult Add_I_Have_Lost(string adv, string support, string foto)
        {
            byte[] fotoinByte;
            if (String.IsNullOrEmpty(foto))
            {
                fotoinByte = null;
            }
            else { 
                fotoinByte = System.IO.File.ReadAllBytes(foto); 
            }

            I_have_lost new_I_have_lost = new I_have_lost()
            {
                advertisment = adv, support = support, ssylka_id = your_id, photo = fotoinByte
            };
            db.I_have_lost.Add(new_I_have_lost);
            db.SaveChanges();


            if (db.I_have_lost.Where(x => x.ssylka_id == your_id).Any())
            {

                var rez = from table in db.I_have_lost
                          where table.ssylka_id == your_id
                          select table;
                ViewData["I_Have_Lost"] = rez;
                return View("Help_I_Lost");
            }
            else
            {
                ViewData["I_Have_Lost"] = null;
                return View("Help_I_Lost");
            }
        }

        public ActionResult Delete_I_Found(int id_num)
        {
           I_have_lost str_for_delete =db.I_have_lost.Where(x => x.ID_I_have_lost == id_num).FirstOrDefault();
            db.I_have_lost.Remove(str_for_delete);
            db.SaveChanges();

            if (db.I_have_lost.Where(x => x.ssylka_id == your_id).Any())
            {

                var rez = from table in db.I_have_lost
                          where table.ssylka_id == your_id
                          select table;
                ViewData["I_Have_Lost"] = rez;
                return View("Help_I_Lost");
            }
            else
            {
                ViewData["I_Have_Lost"] = null;
                return View("Help_I_Lost");
            }
        }



        public ActionResult Update_I_Have_Lost(string nagr, string infa, int id_red,string foto)
        {
            
            
            var rez_to_update = db.I_have_lost.Where(x => x.ID_I_have_lost == id_red).FirstOrDefault();
            if (!String.IsNullOrEmpty(nagr))
            {
                rez_to_update.advertisment = nagr;
            }
            if (!String.IsNullOrEmpty(infa))
            {
                rez_to_update.support = infa;
            }
            if (!String.IsNullOrEmpty(foto))
            {
                byte[] massivFoto = System.IO.File.ReadAllBytes(foto);
                rez_to_update.photo = massivFoto;
            }
            db.SaveChanges();


            if (db.I_have_lost.Where(x => x.ssylka_id == your_id).Any())
            {

                var rez = from table in db.I_have_lost
                          where table.ssylka_id == your_id
                          select table;
                ViewData["I_Have_Lost"] = rez;
                return View("Help_I_Lost");
            }
            else
            {
                ViewData["I_Have_Lost"] = null;
                return View("Help_I_Lost");
            }
        }

        public ActionResult Vhod_Admina()
        {
            return View();
        }

        public ActionResult Admin_Shelters()
        {
            IEnumerable<id_shelter> zapros = from table in db.id_shelter
                         select table;
            ViewData["adminShelters"] = zapros;
            return View();
        }

        public ActionResult Delete_Priut_Administration(int num_del_id)
        {
            id_shelter del_shel = db.id_shelter.Where(x => x.ID_shelter1 == num_del_id).FirstOrDefault();
            db.id_shelter.Remove(del_shel);
            db.SaveChanges();
            
            IEnumerable<id_shelter> zapros = from table in db.id_shelter
                                             select table;
            ViewData["adminShelters"] = zapros;
            return View("Admin_Shelters");
        }


        public ActionResult Add_Priut_Administration(string name, string adress, string tel, string vid)
        {
            id_shelter add_shelter = new id_shelter() { Name_of_shelter = name, Address_of_shelter = adress, Telephone = tel, vid_animals = vid };
            db.id_shelter.Add(add_shelter);
            db.SaveChanges();
            IEnumerable<id_shelter> zapros = from table in db.id_shelter
                                             select table;
            ViewData["adminShelters"] = zapros;

            return View("Admin_Shelters");
        }


        public ActionResult Update_Priut_Administration(int id,string name, string adress, string tel, string vid)
        {
            id_shelter shelter_izmen = db.id_shelter.Where(x => x.ID_shelter1 == id).FirstOrDefault();
            if (!String.IsNullOrEmpty(name))
            {
                shelter_izmen.Name_of_shelter = name;
            }
            if (!String.IsNullOrEmpty(adress))
            {
                shelter_izmen.Address_of_shelter=adress;
            }
            if (!String.IsNullOrEmpty(tel))
            {
                shelter_izmen.Telephone = tel;
            }
            if (!String.IsNullOrEmpty(vid))
            {
                shelter_izmen.vid_animals = vid;
            }
            db.SaveChanges();


            IEnumerable<id_shelter> zapros = from table in db.id_shelter
                                             select table;
            ViewData["adminShelters"] = zapros;

            return View("Admin_Shelters");
        }

        public ActionResult Poteruyashki_vse()
        {
            var zapros = from table in db.I_have_lost
                         select table;
            ViewData["poteryashki"] = zapros;
            return View();
        }

        public ActionResult Naydenishi_vse()
        {
            var zapros = from table in db.I_found
                         select table;
            ViewData["naydenishi"] = zapros;
            return View();
        }

        public ActionResult PoiskPoId()
        {
            return View();
        }

        public ActionResult Poisk_Po_Id(int id)
        {
            if (!db.it_is_me.Where(x => x.ID_I == id).Any())
            {
                PoiskIDClass poisk = null;
                ViewBag.net_takogo = "Извините, такого участниа нет";
                return View("PoiskPoId", poisk);
            }
            else
            {
                it_is_me me = db.it_is_me.Where(x => x.ID_I == id).FirstOrDefault();
                int id_contact = me.ID_how_to_contact_me;
                PoiskIDClass poisk = new PoiskIDClass()
                {
                    me_names = me,
                    me_telephone = db.how_to_contact_me.Where(x => x.ID_how_to_contact_me == id_contact).FirstOrDefault()
                };
                ViewBag.net_takogo = null;
                return View("PoiskPoId", poisk);
            }
        }
        public ActionResult Novosti()
        {
            IEnumerable<SsylkaNaVideo> zapros = from table in db.SsylkaNaVideo
                         select table;
            ViewBag.vsenovosti = zapros;
            return View();
        }


        public ActionResult AddSsylkaNaYouTube()
        {
            IEnumerable<SsylkaNaVideo> kolekts =db.SsylkaNaVideo.Where(x => x.PersonId == your_id);
            ViewBag.YourVidosi = kolekts;
            return View();
        }

        public ActionResult AddVideoProfil(string ssylka)
        {
            SsylkaNaVideo addVideo = new SsylkaNaVideo();
            addVideo.PersonId = your_id;
            addVideo.SsylkaNaYouTube = ssylka;
            db.SsylkaNaVideo.Add(addVideo);
            db.SaveChanges();
            IEnumerable<SsylkaNaVideo> kolekts = db.SsylkaNaVideo.Where(x => x.PersonId == your_id);
            ViewBag.YourVidosi = kolekts;
            return View("AddSsylkaNaYouTube");
        }

        public ActionResult DeleteVideo(int delId)
        {
            SsylkaNaVideo delvideo = db.SsylkaNaVideo.Where(x => x.Id == delId && x.PersonId == your_id).FirstOrDefault();
            
            db.SsylkaNaVideo.Remove(delvideo);
            db.SaveChanges();

            IEnumerable<SsylkaNaVideo> kolekts = db.SsylkaNaVideo.Where(x => x.PersonId == your_id);
            ViewBag.YourVidosi = kolekts;
            return View("AddSsylkaNaYouTube");
        }


        public ActionResult Admin_Manager_Video()
        {
            var zaprose = from table in db.SsylkaNaVideo
                          select table;
            ViewBag.zapros = zaprose;
            return View();
        }

        public ActionResult DelVideoAdmin(int idToDel)
        {
            if (db.SsylkaNaVideo.Where(x => x.Id == idToDel).Any())
            {
                var del =db.SsylkaNaVideo.Where(x => x.Id == idToDel).FirstOrDefault();
                db.SsylkaNaVideo.Remove(del);
                db.SaveChanges();
            }

            var zaprose = from table in db.SsylkaNaVideo
                          select table;
            ViewBag.zapros = zaprose;
            return View("Admin_Manager_Video");
        }

        public ActionResult VhodPoRolAdmina(string NameRolAdmin, string ParolRolAdmin) 
        {
            if (NameRolAdmin == "priuts" && ParolRolAdmin == "parolpriuts")
            {
                ViewBag.oshibka = null;
                return View("AminPriutStranitsa");
            }
            else if (NameRolAdmin == "ohrana" && ParolRolAdmin == "parolohrana")
            {
                ViewBag.oshibka = null;
                return View("AminOhranaStranitsa");
            }
            else 
            {
                ViewBag.oshibka = "Вы ввели неправильные данные";
                return View("Vhod_Admina");
            }
        }

        public ActionResult Priuts_Help_Otdelno_Pozhertvovat() 
        {
            return View();
        }

        public ActionResult Otpravit_Svou_pomosh( string MyHelp) 
        {
            if (String.IsNullOrEmpty(MyHelp)) 
            {
                return View("Vi_Ne_Zapolnily_Tekstovoe_Pole");
            }
            else
            {
                //your_id
                help addNewHelp =new help() {How_can_i_help = MyHelp, ssylka_id = your_id };
                db.help.Add(addNewHelp);
                db.SaveChanges();
                return View("Vasha_Zayavka_Uspeshna_Otpravlena");
            }
        }

        public ActionResult Priuts_Help_Zaprosit_Pomosh_Ot_Priutov() 
        {
            return View();
        }

        public ActionResult Pomosh_Ot_Priutiv(string pomosh_ot_priutov_text) 
        {
            if (String.IsNullOrEmpty(pomosh_ot_priutov_text))
            {
                return View("Vi_Ne_Zapolnily_Tekstovoe_Pole");
            }
            else
            {
                //your_id
                help addNewHelp = new help() { What_help_do_I_need = pomosh_ot_priutov_text, ssylka_id = your_id };
                db.help.Add(addNewHelp);
                db.SaveChanges();
                return View("Vasha_Zayavka_Uspeshna_Otpravlena");
            }
        }

        public ActionResult DeleteIdZayavkiPriutPolzovatelem(int delZayavPriut)
        {
            if (!(db.help.Where(x => x.ID_help == delZayavPriut && x.ssylka_id == your_id).Any()))
            {
                ViewBag.StrokaOshibkiPriut = "У вас нет такого id";
                return View("Udalenie_id_zayavka_priuta");
            }

                help del_help = db.help.Where(x => x.ID_help == delZayavPriut && x.ssylka_id == your_id).FirstOrDefault();

                    db.help.Remove(del_help);
                    db.SaveChanges();
                    ViewBag.Udalenie_ID_priut_zayavku = null;
                    return View("Udalenie_id_zayavka_priuta");


        }

        public ActionResult ZayavkiOtPolzovateleyKPriutam()
        {
            ZayavkiVseClass vse_dannie_dluya_managera =new ZayavkiVseClass();
            IEnumerable<help> spiok_vse_help = from table in db.help
                                               select table;
            IEnumerable<it_is_me> spisok_vse_it_is_me = from table in db.it_is_me
                                                        select table;
            IEnumerable<how_to_contact_me> spisok_vse_how_to_contact_me = from table in db.how_to_contact_me
                                                                          select table;
            vse_dannie_dluya_managera.vse_help = spiok_vse_help;
            vse_dannie_dluya_managera.vse_how_to_contact_me = spisok_vse_how_to_contact_me;
            vse_dannie_dluya_managera.vse_it_is_me = spisok_vse_it_is_me;

            IEnumerable<response_from_the_manager> spisok_nashih_otvetov = from table in db.response_from_the_manager
                                                                           select table;
            vse_dannie_dluya_managera.vse_response_ot_managera = spisok_nashih_otvetov;

            return View(vse_dannie_dluya_managera);
        }

        static int id_zayavki_otvet; 
        public ActionResult OtvetitPolzovatelyu(int id_zayavki)
        {
            try
            {
                Furry_Community.Models.VseZayavkiPapka.ZayavkiVseClass new_class = new Furry_Community.Models.VseZayavkiPapka.ZayavkiVseClass();
                new_class.id_zayavki = id_zayavki;
                new_class.vse_help = from table in db.help
                                     where table.ID_help == id_zayavki
                                     select table;
                int id_person = (from table in db.help
                                 where table.ID_help == id_zayavki
                                 select table.ssylka_id).FirstOrDefault().Value;
                new_class.vse_it_is_me = from table in db.it_is_me
                                         where table.ID_I == id_person
                                         select table;
                int id_how_to_contact_me = (from table in db.it_is_me
                                            where table.ID_I == id_person
                                            select table.ID_how_to_contact_me).FirstOrDefault();
                new_class.vse_how_to_contact_me = from table in db.how_to_contact_me
                                                  where table.ID_how_to_contact_me == id_how_to_contact_me
                                                  select table;
                id_zayavki_otvet = id_zayavki;

                return View(new_class);
            }
            catch (Exception ex) 
            {
                ViewBag.nettakoyzayavki = "Вы ошиблись при вводе заявки, такой не существует, будьте внимательней";
                return View("Oshibka");
            }
        }
        
         
        
 
        public ActionResult Otpravit_otvet_polzovatelu(string otvetPolzovatelu) 
        {

            int id_person = (from table in db.help
                             where table.ID_help == id_zayavki_otvet
                             select table.ssylka_id).FirstOrDefault().Value;

            response_from_the_manager dobavit_otvet_v_bazu =new response_from_the_manager()
            {
                Id_polzovatelya = id_person,
                Stroka_otveta = otvetPolzovatelu,
                Id_Zayavki = id_zayavki_otvet
            };
            db.response_from_the_manager.Add(dobavit_otvet_v_bazu);
            db.SaveChanges();
            return View("VseUspeshno");
        }

        public ActionResult UdalitIdZayavki(int id_del_zayavka) 
        {
            help del_zayav = (from table in db.help
                                               where table.ID_help == id_del_zayavka
                                               select table).FirstOrDefault();

            db.help.Remove(del_zayav);
            db.SaveChanges();


            /////
            ZayavkiVseClass vse_dannie_dluya_managera = new ZayavkiVseClass();
            IEnumerable<help> spiok_vse_help = from table in db.help
                                               select table;
            IEnumerable<it_is_me> spisok_vse_it_is_me = from table in db.it_is_me
                                                        select table;
            IEnumerable<how_to_contact_me> spisok_vse_how_to_contact_me = from table in db.how_to_contact_me
                                                                          select table;
            vse_dannie_dluya_managera.vse_help = spiok_vse_help;
            vse_dannie_dluya_managera.vse_how_to_contact_me = spisok_vse_how_to_contact_me;
            vse_dannie_dluya_managera.vse_it_is_me = spisok_vse_it_is_me;

            IEnumerable<response_from_the_manager> spisok_nashih_otvetov = from table in db.response_from_the_manager
                                                                           select table;
            vse_dannie_dluya_managera.vse_response_ot_managera = spisok_nashih_otvetov;

            return View("ZayavkiOtPolzovateleyKPriutam", vse_dannie_dluya_managera);

        }



        public ActionResult UdalitIdNashegoOtveta(int id_del_nashOtvet) 
        {
            response_from_the_manager otvet_del = (from table in db.response_from_the_manager
                                                   where table.Id == id_del_nashOtvet
                                                   select table).FirstOrDefault();
            db.response_from_the_manager.Remove(otvet_del);
            db.SaveChanges();
            /////
            ZayavkiVseClass vse_dannie_dluya_managera = new ZayavkiVseClass();
            IEnumerable<help> spiok_vse_help = from table in db.help
                                               select table;
            IEnumerable<it_is_me> spisok_vse_it_is_me = from table in db.it_is_me
                                                        select table;
            IEnumerable<how_to_contact_me> spisok_vse_how_to_contact_me = from table in db.how_to_contact_me
                                                                          select table;
            vse_dannie_dluya_managera.vse_help = spiok_vse_help;
            vse_dannie_dluya_managera.vse_how_to_contact_me = spisok_vse_how_to_contact_me;
            vse_dannie_dluya_managera.vse_it_is_me = spisok_vse_it_is_me;

            IEnumerable<response_from_the_manager> spisok_nashih_otvetov = from table in db.response_from_the_manager
                                                                           select table;
            vse_dannie_dluya_managera.vse_response_ot_managera = spisok_nashih_otvetov;

            return View("ZayavkiOtPolzovateleyKPriutam", vse_dannie_dluya_managera);
        }


        public ActionResult ProsmotrOtvetaNaZayavki() 
        {
            IEnumerable<response_from_the_manager> otvet = from table in db.response_from_the_manager
                                                           where table.Id_polzovatelya == your_id
                                                           select table;
            Furry_Community.Models.VseOtvetyProsmotrPolz.ProsmotrOtveta otv = new Furry_Community.Models.VseOtvetyProsmotrPolz.ProsmotrOtveta();
            otv.otvet = otvet;

            return View(otv);
        }



        public ActionResult Patrol_manage_reputation() 
        {
            IEnumerable<reputation_from_the_patrolman> vse_bad_pers = from table in db.reputation_from_the_patrolman
                                                                      select table;
            PatrulReputation class_patrol = new PatrulReputation();
            class_patrol.table_bad_persons = vse_bad_pers;
            return View(class_patrol);
        }

        public ActionResult Patrol_add_bad_id(string str_zamech, int bad_id) 
        {
           reputation_from_the_patrolman new_bad_guy =new reputation_from_the_patrolman();
            new_bad_guy.Comment_of_remark = str_zamech;
            new_bad_guy.Id_polzovatelya = bad_id;
            db.reputation_from_the_patrolman.Add(new_bad_guy);
            db.SaveChanges();
            ViewBag.FromPartol = 1;
            return View("VseUspeshno");
        }

        public ActionResult Del_stoka_zamechanie(int id_to_del) 
        {
            reputation_from_the_patrolman rep_ro_del = db.reputation_from_the_patrolman.Where(x => x.Id == id_to_del).FirstOrDefault();
            db.reputation_from_the_patrolman.Remove(rep_ro_del);
            db.SaveChanges();
            ViewBag.FromPartol = 1;
            return View("VseUspeshno");
        }

    }


}