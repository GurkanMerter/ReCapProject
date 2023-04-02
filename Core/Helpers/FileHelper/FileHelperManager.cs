using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers.GuidHelperr;

namespace Core.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if(file.Length> 0)              //file kontrol
            {
                if(!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);                //dosyaların yükleneceği kısmın kontrolü
                }

                string extension = Path.GetExtension(file.Name);            //dosya uzantısı
                string guid = GuidHelper.CreateGuid();                          //dosyanın yeni ismi
                string filePath = guid + extension;                             //dosyanın yeni ismi + uzantısı

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    fileStream.CopyTo(fileStream);
                    fileStream.Flush();                                    //arabellekten silme işlemi
                    return filePath;
                }

            }

            return null;
        }
    }
}
