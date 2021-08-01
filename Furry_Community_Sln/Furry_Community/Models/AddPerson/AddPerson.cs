using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Furry_Community.Models.DataBase;
namespace Furry_Community.Models.AddPerson
{
    public class AddPerson
    {
        public int ID_I { get; set; }
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public string Patronymic { get; set; }

        public int ID_how_to_contact_me { get; set; } = 1;
        public int ID_reputation { get; set; } = 1;



        public void ADD(string f, string s, string p)
        {
            this.First_name = First_name;
            this.Second_name = Second_name;
            this.Patronymic = Patronymic;
            using (Furry_DB db =new Furry_DB())
            {
                var rez = from t in db.it_is_me
                          select t;
                List<it_is_me> dbList = rez.ToList<it_is_me>();
                it_is_me person = new it_is_me() {
                    First_name = this.First_name,
                    Second_name = this.Second_name,
                    Patronymic = this.Patronymic,
                    ID_how_to_contact_me = this.ID_how_to_contact_me,
                    ID_reputation = this.ID_reputation
                };
                db.it_is_me.Add(person);
                db.SaveChanges();
            
            }
        }



         
    }
}