using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalLab.BLL
{
    public interface IActionManipulation
    {
        void load(String fileName);
        void save();

        void actionResult();
    }
}
