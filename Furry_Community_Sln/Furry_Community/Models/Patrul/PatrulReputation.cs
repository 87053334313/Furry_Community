using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Furry_Community.Models.DataBase;

namespace Furry_Community.Models.Patrul
{
    public class PatrulReputation
    {
        public IEnumerable<reputation_from_the_patrolman> table_bad_persons;
        public IEnumerable<it_is_me> vse_it_is_me;
    }
}