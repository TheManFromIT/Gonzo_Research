using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gonzo.Microservice
{
    public class OuiDb
    {

        protected List<OuiRecord> db = new List<OuiRecord>();

        public OuiDb()
        {

        }


        public Boolean TryFind(String Mac, out OuiRecord Found)
        {

            foreach (var record in db)
            {
                if (Mac.StartsWith(record.Oui))
                {
                    Found = record;
                    return true;
                }
            }

            Found = null;
            return false;
        }

        public void Load()
        {
           
            var dataFile = DownLoad("https://code.wireshark.org/review/gitweb?p=wireshark.git;a=blob_plain;f=manuf");

            var lines = dataFile.Split('\n');

            foreach (var line in lines)
            {

                if (!String.IsNullOrEmpty(line) && !line.TrimStart().StartsWith("#"))
                {

                    var data = line.Split('\t');

                    if (data.Length < 3)
                    {
                        var parts = data[1].Split('#');

                        String manufacturer = String.Empty;
                        String description = String.Empty;

                        if (parts.Length == 1)
                        {
                            manufacturer = parts[0].Trim();
                        }
                        else
                        {
                            manufacturer = parts[0].Trim();
                            description = parts[1].Trim();
                        }

                        var record = new OuiRecord()
                        {
                            Oui = data[0],
                            Manufacturer = manufacturer,
                            Description = description
                        };

                        db.Add(record);

                    }
                    else
                    {

                        var record = new OuiRecord()
                        {
                            Oui = data[0],
                            Manufacturer = data[1],
                            Description = data[2].Replace("#", String.Empty).Trim()
                        };

                        db.Add(record);

                    }

                }

            }

        }

        protected virtual String DownLoad(String url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;

            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                var data = UTF8Encoding.UTF8.GetString(ReadAll(response.GetResponseStream()));

                return data;
                
            }

        }

        public static byte[] ReadAll(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
