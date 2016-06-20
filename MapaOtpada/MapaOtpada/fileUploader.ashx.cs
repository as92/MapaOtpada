
using System;
using System.Web;
using System.IO;
public class fileUploader : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        HttpPostedFile file = context.Request.Files[0];

        if (file.ContentLength > 0)
        {
            //do something
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}