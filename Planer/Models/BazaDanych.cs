using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Models
{
    public class BazaDanych
    {
        public int Id { get; set; }
        public string NazwaBazy { get; set; }

        public BazaDanych()
        {

        }

        public BazaDanych(int _Id, string _nazwaBazy)
        {
            Id = _Id;
            NazwaBazy = _nazwaBazy;
        }
    }
}
