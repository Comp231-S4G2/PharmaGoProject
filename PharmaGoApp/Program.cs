using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;


namespace PharmaGoApp
{
    public class Program
    {
        //Path to json file with credentials
        static string keyFilepath = "path/to/file";
        //Actual project id from Google cloud
        static string projectId = "pharmaproject-777";

        public static void Main(string[] args)
        {

            //Code for GOOGLE AUTHENTICATION CREDENTIALS part 

            var jsonString = File.ReadAllText(keyFilepath);
            var builder = new FirestoreClientBuilder { JsonCredentials = jsonString };
            FirestoreDb db = FirestoreDb.Create(projectId, builder.Build());

            //standard project setup
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
