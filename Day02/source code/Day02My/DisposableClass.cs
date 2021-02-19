using System;
using System.Collections.Generic;
using System.Text;

namespace Day02My
{
    class DisposableClass : IDisposable
    {
        private readonly string _message = "myMessage";
        public string Message
        {
            get
            {
                return _message;
            }
        }
        //virtual method is base implementation, it can but does not have to be overwritten by derived class
        //abstract classes only can implement abstract methods 
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //disposing code
            }
        }
        public void My()
        {

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
