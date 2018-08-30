using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planer.Models
{
    public class Polaczenie
    {
        public string serverName { get; set; }
        public string databaseName { get; set; }
        public string SQLLoginName { get; set; }
        public string loginPassword { get; set; }
    }
}
