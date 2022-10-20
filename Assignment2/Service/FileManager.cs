using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment21.Service
{
    public class Filemanager
    {
        
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\CSAssignment1-master\Assignment2.json";
        public void Save(string text)
        {
            try
            {
                var sw = new StreamWriter(filePath);
                sw.WriteLine(text);
            }
            catch
            {

            }

        }
        public string Read()
        {
            try
            {

                var sr = new StreamReader(filePath);
                var content = sr.ReadToEnd();

                if(string.IsNullOrEmpty(content))
                    content = "[]";

                return content;

            }
            catch
            {
                return "[]";
            }
        }

    }
}

/*
 
 
contacts = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(filemanager.Read());


filemanager.Save(JsonConvert.SerializeObject(contacts));


private Filemanager filemanager = new Filemanager();
*/