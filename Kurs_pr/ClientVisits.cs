using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_pr
{
    internal class ClientVisits
    {
        public string VisClient;
        public string VisServ;
        public DateTime VisDate;

        public ClientVisits(string VisClient, string VisServ, DateTime VisDate)
        {
            this.VisClient = VisClient;
            this.VisServ = VisServ;
            this.VisDate = VisDate;
        }
            public override string ToString()
        {
            return VisClient+" "+VisServ+" "+VisDate;
        }
    
    }
}
