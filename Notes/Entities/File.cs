using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notes
{
    class File
    {
        private string name;
        private StreamWriter sw;
        private StreamReader sr;
        private bool open;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Open
        {
            get => open;

            private set => open = value;
        }

        public File(string name)
        {
            this.name = name;
        }

        public void CreateOrOpenFile()
        {
            sw = new StreamWriter(name + ".txt", true, System.Text.Encoding.UTF8);
            open = true;
        }

        public void CloseFile()
        {
            sw.Close();
            open = false;
        }

        public void RecordMessage(string msg)
        {
            sw.WriteLine(msg);
        }

        public void ReadFile()
        {
            Console.WriteLine();

            try {

                sr = new StreamReader(name+".txt");
                string line = sr.ReadLine();

                while (!String.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }

                sr.Close(); // It opens and closes StreamReader inside the method.

            } catch (System.IO.IOException e)
            {
                Console.WriteLine("Written file is stil open and needs closing!\n" + e.Message);
                this.CloseFile();
            }

        }

    }
}
