using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace PostLocateSoapExample
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 2; i++)
            {
                Parallel.Invoke(() =>
                {
                    GetRequest("37211");
                },
                    () =>
                    {
                        GetRequest("35633");
                    },
                    () =>
                    {
                        GetRequest("36066");
                    },
                    () =>
                    {
                        GetRequest("37217");
                    },
                    () =>
                    {
                        GetRequest("37211");
                    },
                    () =>
                    {
                        GetRequest("21345");
                    },
                    () =>
                    {
                        GetRequest("35633");
                    },
                    () =>
                    {
                        GetRequest("36066");
                    },
                    () =>
                    {
                        GetRequest("37217");
                    },
                    () =>
                    {
                        GetRequest("37211");
                    },
                    () =>
                    {
                        GetRequest("21345");
                    },
                    () =>
                    {
                        GetRequest("35633");
                    },
                    () =>
                    {
                        GetRequest("36066");
                    },
                    () =>
                    {
                        GetRequest("37217");
                    },
                    () =>
                    {
                        GetRequest("37211");
                    });
            }



        }

        static void GetRequest(String zip)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create("http://clwvpap030.ngic.com/postlocate/service.asmx?WSDL");

            request.Headers.Add(@"SOAP:Action");
            request.Accept = "text/xml";
            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";

            XmlDocument soapEnvelope = new XmlDocument();
            soapEnvelope.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                        "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                                            "<soap:Body>" +
                                                "<GetZIPInfo xmlns=\"http://innovativesystems.com/postlocate\">" +
                                                    "<ZIP>" + zip + "</ZIP>" +
                                                "</GetZIPInfo>" +
                                            "</soap:Body>" +
                                        "</soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelope.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    String result = rd.ReadToEnd();
                    Console.WriteLine(result);
                }

            }
        }
    }
}
