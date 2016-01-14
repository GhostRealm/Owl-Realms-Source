using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using db;

namespace server.@char
{
    internal class list : IRequestHandler
    {
        public void HandleRequest(HttpListenerContext context)
        {
            NameValueCollection query;
            using (var rdr = new StreamReader(context.Request.InputStream))
                query = HttpUtility.ParseQueryString(rdr.ReadToEnd());

            using (var db = new Database())
            {
                List<ServerItem> filteredServers = null;
                Account a = db.Verify(query["guid"], query["password"]);
                if (a != null)
                {
                    if (a.Banned)
                    {
                        filteredServers = YoureBanned();
                    }
                    else
                    {
                        filteredServers = GetServersForRank(a.Rank);
                    }
                }
                else
                {
                    filteredServers = GetServersForRank(0);
                }

                var chrs = new Chars
                {
                    Characters = new List<Char>(),
                    NextCharId = 2,
                    MaxNumChars = 1,
                    Account = db.Verify(query["guid"], query["password"]),
                    Servers = filteredServers
                };
                Account dvh = null;
                if (chrs.Account != null)
                {
                    db.GetCharData(chrs.Account, chrs);
                    db.LoadCharacters(chrs.Account, chrs);
                    chrs.News = db.GetNews(chrs.Account);
                    dvh = chrs.Account;
                }
                else
                {
                    chrs.Account = Database.CreateGuestAccount(query["guid"]);
                    chrs.News = db.GetNews(null);
                }

                var ms = new MemoryStream();
                var serializer = new XmlSerializer(chrs.GetType(),
                    new XmlRootAttribute(chrs.GetType().Name) {Namespace = ""});

                var xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = true;
                xws.Encoding = Encoding.UTF8;
                XmlWriter xtw = XmlWriter.Create(context.Response.OutputStream, xws);
                serializer.Serialize(xtw, chrs, chrs.Namespaces);
                db.Dispose();
            }
        }

        public static List<ServerItem> GetServersForRank(int r)
        {
            List<ServerItem> slist = GetServers();
            var removedServers = new List<ServerItem>();

            foreach (ServerItem i in slist)
                if (i.RankRequired > r)
                    removedServers.Add(i);

            foreach (ServerItem i in removedServers)
                slist.Remove(i);

            return slist;
        }

        public static List<ServerItem> GetServers()
        {
            var Servers
                = new List<ServerItem>
                {
                    new ServerItem
                    {
                        Name = "R has u",
                         Lat = 38.50,
                         Long = 92.50,
                        DNS = "127.0.0.1",
                        Usage = 0.2,
                        AdminOnly = false,
                        RankRequired = 0
                    },

   //                 new ServerItem
   //                 {
  //                      Name = "Colab Realms",
  //                       Lat = 38.50,
  //                       Long = 92.50,
  //                      DNS = "98.162.184.140",
  //                      Usage = 0.2,
  //                      AdminOnly = false,
  //                      RankRequired = 11
 //                   },
 //                    new ServerItem
 //                   {
 //                       Name = "Eternal Realms",
 //                       Lat = 40.24,
 //                       Long = -82.85,
 //                       DNS = "71.64.30.10",
 //                       Usage = 0.2,
 //                       AdminOnly = false,
 //                       RankRequired = 11
 //                   },
 //                   new ServerItem
 //                   {
 //                       Name = "Epic Realms",
 //                       Lat = 37.08,
 //                       Long = 94.51,
 //                       DNS = "67.183.179.199",
 //                       Usage = 0.2,
 //                       AdminOnly = false,
 //                       RankRequired = 11
 //                   },
 //                       new ServerItem
 //                   {
 //                       Name = "Astyric's Wonderland",
 //                       Lat = 53.95,
//                        Long = 1.08,
//                        DNS = "86.8.69.7",
//                        Usage = 0.2,
//                        AdminOnly = false,
//                        RankRequired = 1
//                    },
//                    new ServerItem
//                    {
//                        Name = "Testing",
//                        Lat = 22.28,
//                        Long = 114.16,
//                        DNS = "198.27.110.71",
//                        Usage = 0.2,
//                        AdminOnly = false,
//                        RankRequired = 3
//                    },
                    new ServerItem
                    {
                        Name = "Local",
                        Lat = 22.28,
                        Long = 114.16,
                       DNS = "127.0.0.1",
                       Usage = 0.2,
                       AdminOnly = false,
                        RankRequired = 11
                    }
                };
            return Servers;
        }

        public static List<ServerItem> YoureBanned()
        {
            var Servers
                = new List<ServerItem>
                {
                    new ServerItem
                    {
                        Name = "You're Banned!",
                        Lat = 22.28,
                        Long = 114.16,
                        DNS = "",
                        Usage = 0.2,
                        AdminOnly = false
                    }
                };
            return Servers;
        }
    }
}