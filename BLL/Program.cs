using PracticalLab.BLL;
using PracticalLab.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PracticalLab
{
    public class Program : IProgramBehaviour, IEdgeDetection
    {
        private IEdgeDetection edgeDetection;
        private ISaveBehaviour stf = new SaveToFile();
        private ILoadBehaviour lfd = new LoadFromDisk();
        private Bitmap originalImage, resultImage;
        private MainForm mainForm;
        
        public Program(MainForm mf)
        {
            mainForm = mf;
            edgeDetection = new EdgeDetectionLaplacian5x5(this);
        }

        public void load(string fileName)
        {
            originalImage = lfd.loadImage(fileName);
            applyResult(originalImage);
        }

        public void save(Bitmap image, String filename, ImageFormat imgf)
        {
            if (resultImage != null) {
                Console.WriteLine("result image != null");
                string fileExtension = Path.GetExtension(filename).ToUpper();
                if (fileExtension == ".BMP")
                {
                    imgf = ImageFormat.Bmp;
                }
                else if (fileExtension == ".JPG")
                {
                    imgf = ImageFormat.Jpeg;
                }
                stf.save(resultImage, filename, imgf);
            }
        }

        public void startDetection(Bitmap img)
        {
            edgeDetection.startDetection(originalImage);
            resultImage = edgeDetection.getImage();
            applyResult(resultImage);
        }

        public Bitmap getImage()
        {
            return resultImage ;
        }

        public void applyResult(Bitmap image)
        {
            
            mainForm.display(image);
        }
    }
}
