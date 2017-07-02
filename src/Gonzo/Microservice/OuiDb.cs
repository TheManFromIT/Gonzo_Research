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
            
            DownLoad("https://code.wireshark.org/review/gitweb?p=wireshark.git;a=blob_plain;f=manuf","C:\\temps\\db.txt");

            var lines = File.ReadAllLines("C:\\temps\\db.txt");

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

        protected virtual void DownLoad(String url, String fileName)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;

            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] bytes = ReadFully(response.GetResponseStream());

                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }

        public static byte[] ReadFully(Stream input)
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
