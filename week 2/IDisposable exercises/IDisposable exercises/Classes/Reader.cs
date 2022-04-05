using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IDisposable_exercises.Classes
{
    public class Reader : IDisposable
    {
        IntPtr someUnmanagedResource;

        public Reader()
        {
            someUnmanagedResource = Marshal.AllocHGlobal(5);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                //release managed resources here
            }

            //release managed resources here
            Marshal.FreeHGlobal(someUnmanagedResource);
        }
        ~Reader()
        {
            Dispose(false);
        }
    }
}
