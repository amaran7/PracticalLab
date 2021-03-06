﻿using PracticalLab.BLL;
using PracticalLab.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PracticalLab.DLL;

namespace PracticalLab
{
    public class Program : IProgramBehaviour, IEdgeDetection
    {
        private IEdgeDetection edgeDetection;
        private DLLManager dllManager;
        private Bitmap originalImage, resultImage;
        private MainForm mainForm;
        
        public Program(MainForm mf)
        {
            mainForm = mf;
            edgeDetection = new EdgeDetectionLaplacian5x5(this);
            dllManager = new DLLManager(this);
        }

        public void load(string fileName)
        {
            originalImage = dllManager.loadFromDisk(fileName);
            applyResult(originalImage);
        }

        public void save(Bitmap image, String filename, ImageFormat imgf)
        {
            if (resultImage != null) {
                
                string fileExtension = Path.GetExtension(filename).ToUpper();
                if (fileExtension == ".BMP")
                {
                    imgf = ImageFormat.Bmp;
                }
                else if (fileExtension == ".JPG")
                {
                    imgf = ImageFormat.Jpeg;
                }
                dllManager.saveToFile(resultImage, filename, imgf);
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
