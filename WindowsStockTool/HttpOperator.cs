using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStockTool
{
    class HttpOperator
    {
        public static string HttpGet(string URL, string Data, string RequestContentTypeCharset, string ResponseStreamEncoding)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL + Data);
                Request.Method = "GET";
                Request.ContentType = "text/html;charset=" + RequestContentTypeCharset;
                Request.Timeout = 5000;

                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                Stream ResponseStream = Response.GetResponseStream();
                StreamReader ResponseStreamReader = new StreamReader(ResponseStream, Encoding.GetEncoding(ResponseStreamEncoding));
                string ReturnString = ResponseStreamReader.ReadToEnd();

                ResponseStreamReader.Close();
                ResponseStream.Close();

                return ReturnString;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught: " + e.Data);

                return "ERROR";
            }
        }

        public static bool HttpDownload(string URL, string Filename)
        {
            bool Downloaded = false;
            long Pos = 0;
            FileStream DownloadingFileStream;

            if (File.Exists(Filename))
            {
                DownloadingFileStream = File.OpenWrite(Filename);
                Pos = DownloadingFileStream.Length;

                DownloadingFileStream.Seek(Pos, SeekOrigin.Current);
            }
            else
            {
                DownloadingFileStream = new FileStream(Filename, FileMode.Create);
                Pos = 0;
            }

            try
            {
                HttpWebRequest DownloadRequest = (HttpWebRequest)HttpWebRequest.Create(URL);

                if (Pos > 0) DownloadRequest.AddRange((int)Pos);

                Stream DownloadStream = DownloadRequest.GetResponse().GetResponseStream();
                byte[] ByteContent = new byte[512];
                int ReadingSize = DownloadStream.Read(ByteContent, 0, 512);

                while (ReadingSize > 0)
                {
                    DownloadingFileStream.Write(ByteContent, 0, ReadingSize);

                    ReadingSize = DownloadStream.Read(ByteContent, 0, 512);
                }

                DownloadingFileStream.Close();
                DownloadStream.Close();

                Downloaded = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught: " + e.Data);
                DownloadingFileStream.Close();
            }

            return Downloaded;
        }

        public static long GetRemoteFileSize(string URL)
        {
            long Size = 0;

            try
            {
                HttpWebRequest GetSizeRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
                GetSizeRequest.Method = "HEAD";
                HttpWebResponse GetSizeResponse = (HttpWebResponse)GetSizeRequest.GetResponse();
                Size = GetSizeResponse.ContentLength;

                GetSizeResponse.Close();

                return Size;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught: " + e.Data);

                return Size;
            }
        }
    }
}
