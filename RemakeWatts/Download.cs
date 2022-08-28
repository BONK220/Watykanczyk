using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemakeWatts
{
    public class Download
    {
        public void download(String url, String path)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(url);
            string filename = Path.GetFileName(uri.AbsolutePath);
            client.DownloadFileAsync(uri, $"{path}/{filename}");
        }
    }
}
