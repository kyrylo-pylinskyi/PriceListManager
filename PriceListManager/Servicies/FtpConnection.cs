using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Servicies
{
    public class FtpConnection
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Path { get; set; }
        public string File { get; set; }
        public FtpWebRequest Request { get; set; }
        public FtpWebResponse Response { get; set; }

        public FtpConnection(string host, string username, string password, string? path, string? file)
        {
            UserName = username;
            Password = password;
            Host = host;
            Path = path;
            File = file;

            Request = (FtpWebRequest)WebRequest.Create(
                $"ftp://{Host}/" +
                $"{(string.IsNullOrEmpty(Path) ? string.Empty : path)}" +
                $"{(string.IsNullOrEmpty(file) ? string.Empty : "/" + file)}"
               );

            Request.KeepAlive = false;
            Request.UseBinary = true;
            Request.UsePassive = true;
            Request.Credentials = new NetworkCredential(UserName, Password);
        }

        public List<string> ListDirectory()
        {
            Request.Method = WebRequestMethods.Ftp.ListDirectory;

            List<string> directoryList = new List<string>();

            try
            {
                using (Response = (FtpWebResponse)Request.GetResponse())
                using (Stream responseStream = Response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    while (!reader.EndOfStream)
                    {
                        directoryList.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ocured: {ex.Message}");
            }

            return directoryList;
        }

        public MemoryStream DownloadFile()
        {
            Request.Method = WebRequestMethods.Ftp.DownloadFile;

            MemoryStream memoryStream = new MemoryStream();

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)Request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                    while (bytesRead > 0)
                    {
                        memoryStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                    }
                }

                Console.WriteLine("File downloaded to memory stream.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ocured: {ex.Message}");
            }

            return memoryStream;
        }

        public void UploadFile(MemoryStream memoryStream)
        {
            Request.Method = WebRequestMethods.Ftp.UploadFile;

            try
            {
                byte[] fileContents = memoryStream.ToArray();

                using (Stream requestStream = Request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)Request.GetResponse())
                {
                    Console.WriteLine($"Upload completed. Response: {response.StatusDescription}");
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
