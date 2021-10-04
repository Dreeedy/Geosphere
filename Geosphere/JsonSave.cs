using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    class JsonSave : SaveHandler
    {
        private static string _baseDirectory;
        private static string _pathToJsonFolder;

        public JsonSave(string folderName)
        {
            _baseDirectory = GetBaseDirectory();

            CreateFolder(folderName);
        }        

        public override void Save(string data, string fileName)
        {
            string path = _pathToJsonFolder + "/" + fileName + ".json";

            FileStream fileStream = new FileStream(path, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.Write(data);

            streamWriter.Close();
            fileStream.Close();
        }

        private void CreateFolder(string folderName)
        {
            string path = _baseDirectory + folderName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            _pathToJsonFolder = path;
        }

        private string GetBaseDirectory()
        {
            string path;
            path = AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }
    }
}
