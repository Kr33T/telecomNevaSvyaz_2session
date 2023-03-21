using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using telecomNevaSvyaz_2.Classes;

namespace telecomNevaSvyaz_2
{
    public partial class Subscriber
    {
        public string FIO
        {
            get
            {
                return Surname + " " + Name[0] + "." + Patronymic[0] + ".";
            }
            set
            {

            }
        }

        public string FIOFull
        {
            get
            {
                return Surname + " " + Name + " " + Patronymic + " ";
            }
            set
            {

            }
        }
        public string ListServices
        {
            get
            {
                List<ConnectedServices> services = DBHelper.bm.ConnectedServices.Where(x => x.SubscribersID == SubscriberID).ToList();
                string strServices = "";
                for (int i = 0; i < services.Count; i++)
                {
                    if (i == services.Count - 1)
                    {
                        strServices = strServices + services[i].Service.Services;
                    }
                    else
                    {
                        strServices = strServices + services[i].Service.Services + ", ";
                    }
                }
                return strServices;
            }
            set
            {

            }
        }
    }
}
