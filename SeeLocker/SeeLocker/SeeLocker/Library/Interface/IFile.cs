using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeLocker.Library.Interface
{
    public interface IFile
    {
        bool SaveImage(string strImageName, string strImageData);
        string GetFile(string strImageName);
    }
}
