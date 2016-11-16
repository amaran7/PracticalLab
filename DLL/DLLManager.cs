using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalLab.DLL
{
    public class DLLManager
    {
        public ISaveBehaviour isb;
        public ILoadBehaviour ilb;
        public Program program;

        public DLLManager(Program program)
        {
            this.program = program;
        }

        public void saveToFile(Bitmap image, String filename, ImageFormat format)
        {
            isb = new SaveToFile();
            isb.save(image, filename, format);
        }

        public void loadFromDisk(string fileName)
        {
            ilb = new LoadFromDisk();
            ilb.loadImage(fileName);
        }
    }
}
