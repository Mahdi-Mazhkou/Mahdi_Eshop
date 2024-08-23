using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork
{
    public static class FileValidation
    {
        public static bool IsValidFileName(string filename)
        {
            filename = Path.GetFileName(filename).ToLower().Trim();
            if (filename.Contains(".asp") || filename.Contains(".py") || filename.Contains(".jsp"))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidSize(long fileSize)
        {
            if (fileSize < 40960 || fileSize > 2097152)
            {
                return false;
            }

            return true;
        }
    }
}
