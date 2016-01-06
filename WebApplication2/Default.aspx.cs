using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int small = 0;
            int average = 0;
            int big = 0;
            string strpath = "";
            HttpCookie reqCookie = Request.Cookies["path"];
            if (reqCookie != null)
            {
                strpath = reqCookie.Value;
            }
            else
            {
                strpath = AppDomain.CurrentDomain.BaseDirectory;
            }
            //strpath = AppDomain.CurrentDomain.BaseDirectory;
            string reqDir = Request.QueryString["dir"];
            if (reqDir != null)
            {
                string finalStrpath = strpath + reqDir + @"\";
                if (Directory.Exists(finalStrpath))
                {
                    if (reqDir == "..")
                    {
                        try
                        {
                            strpath = Directory.GetParent(strpath).FullName;
                        }
                        catch
                        {
                            
                        }
                    }
                    else
                    {
                        strpath = finalStrpath;
                    }
                }
            }

            string[] allFoundFiles = Directory.GetFiles(strpath, "*.*", SearchOption.AllDirectories);
            foreach (string file in allFoundFiles)
            {
                FileInfo tmpfl = new FileInfo(file);
                if (tmpfl.Length <= 10 * 1024 * 1024)
                { small++; }
                else if (tmpfl.Length >= 100 * 1024 * 1024)
                { big++; }
                else if (tmpfl.Length > 10 * 1024 * 1024 && tmpfl.Length <= 50 * 1024 * 1024)
                { average++; }

            }
            Sma.Text = small.ToString();
            Ave.Text = average.ToString();
            Bii.Text = big.ToString();
            Curr.Text = "<b>Current path: </b>" + strpath + "<br />";
            DirectoryInfo di = new DirectoryInfo(strpath);
            Dirs.Text += ("<a href = 'Default.aspx?dir=..'> ..</a><br/>");
           
                foreach (var fi in di.GetDirectories())
                {
                    Dirs.Text += ("<a href = 'Default.aspx?dir=" + fi.Name + "'> " + fi.Name + "</a><br/>");
                }
                Dirs.Text += "<br/>";
            foreach (var fi in di.GetFiles())
            {
                Dirs.Text += ("<a href = '" + strpath + fi.Name + "'> "  + fi.Name + "</a><br/>");
            }
            HttpCookie cookie = new HttpCookie("path", strpath);
            Response.Cookies.Add(cookie);
        }

        
    }
}