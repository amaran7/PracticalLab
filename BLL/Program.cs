using PracticalLab.BLL;
using PracticalLab.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PracticalLab
{
    public class Program : IActionManipulation, IEdgeDetection
    {
        private IEdgeDetection edgeDetection;
        private ISaveBehaviour stf = new SaveToFile();
        private ILoadBehaviour lfd = new LoadFromDisk();
        private Bitmap originalImage, resultImage;
        private MainForm mainForm;
        
        public Program(MainForm mf)
        {
            mainForm = mf;
        }

        public void load(string fileName)
        {
            originalImage = lfd.loadImage(fileName);
            mainForm.display(originalImage);
        }

        public void save()
        {
            throw new NotImplementedException();
        }

   
        public void actionResult()
        {
            edgeDetection = new EdgeDetectionLaplacian5x5(this);
            resultImage = startDetection(originalImage);
            mainForm.display(resultImage);
        }

        public Bitmap startDetection(Bitmap img)
        {
            throw new NotImplementedException();
        }
    }
}
