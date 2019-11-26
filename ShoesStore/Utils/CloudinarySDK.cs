using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesStore.Utils
{
    public class CloudinarySDK
    {
        public static CloudinarySDK instance = null;

        private CloudinarySDK()
        {
            account = new Account(
   "dfiw4oxro",
   "582924829145383",
   "Pq5Ghr1vbFUQkZ4PLCgiJsHnXWo");
           cloudinary = new Cloudinary(account);
        }

        public CloudinarySDK getInstance()
        {
            if (instance == null)
            {
                instance = new CloudinarySDK();
            }

            return instance;
        }

        private static Account account = null;

        public static Cloudinary cloudinary = null;
    }

}