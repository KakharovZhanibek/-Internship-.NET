using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposable_exercises.Classes
{
    public class Customer : IDisposable
    {

        private Reader _reader;
        private bool disposed = false;

        public Customer()
        {
            _reader = new Reader();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                //release managed resources here
                _reader.Dispose();
            }

            //release unmanaged resources here

            disposed = true;
        }
        ~Customer()
        {
            Dispose(false);
        }
    }
}
