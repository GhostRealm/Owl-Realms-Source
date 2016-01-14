using System.Collections.Specialized;
using System.Collections.Generic;
using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Web;
using db;
using MySql.Data.MySqlClient;

namespace server.credits
{
    class add : IRequestHandler
    {
        public void HandleRequest(HttpListenerContext context)
        {
            string status;
            using (var db = new Database())
            {
                var query = HttpUtility.ParseQueryString(context.Request.Url.Query);

                var cmd = db.CreateQuery();
                cmd.CommandText = "SELECT id FROM accounts WHERE uuid=@uuid";
                cmd.Parameters.AddWithValue("@uuid", query["guid"]);
                object id = cmd.ExecuteScalar();

                if (id != null)
                {
                    //                    int amount = int.Parse(query["jwt"]);
                    //                    cmd = db.CreateQuery();
                    //                    cmd.CommandText = "UPDATE stats SET credits = credits + @amount WHERE accId=@accId";
                    //                    cmd.Parameters.AddWithValue("@accId", (int)id);
                    //                    cmd.Parameters.AddWithValue("@amount", amount);
                    int result = (int)cmd.ExecuteNonQuery();
                    if (result > 0)
                        status = "Donate Today! Donate to owlrealm30@gmail.com on paypal.        For more info on donators plz refer to http://www.doomedrealms.enjin.com/forum/m/17624149/viewthread/9704431-donators ";
                    else
                        status = "Donate Today! Donate to owlrealm30@gmail.com on paypal.        For more info on donators plz refer to http://www.doomedrealms.enjin.com/forum/m/17624149/viewthread/9704431-donators ";
                    //                    status = "Internal error :(";
                }
                else
                    status = "Account not exists :(";
            }

            var res = Encoding.UTF8.GetBytes(
@"<html>
    <head>
        <title>Help the Owner!</title>
    </head>
    <body style='background: #333333'>
        <h1 style='color: #EEEEEE; text-align: center'>
            " + status + @"
        </h1>
Or use this link:
https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=BAULU9DB3PQLL
    </body>
</html>");
            context.Response.OutputStream.Write(res, 0, res.Length);
        }
    }
}