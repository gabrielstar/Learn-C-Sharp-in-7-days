using System;
using System.Collections.Generic;
using System.Text;

namespace Day02My
{
    interface IRunnable
    {
        public virtual void run() { }
    }
    interface IRunnableAsync
    {
        public virtual void runAsync() { }
    }
    abstract class Section: IRunnable
    {
        //must be overriden
        public abstract void runAsync();
    }
    abstract class AsyncSection : IRunnableAsync
    {
        //must be overriden
        public abstract void runAsync();
    }
}
