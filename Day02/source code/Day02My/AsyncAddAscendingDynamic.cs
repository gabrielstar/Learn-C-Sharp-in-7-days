using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using static System.Threading.Thread;
using System.Threading.Tasks;

namespace Day02My
{
    class AsyncAddAscendingDynamic
    {
        public async Task runAsync()
        {
            await M1();
            await M2();
        }

        //Event accessors - advanced topic
        //class Events : IDrawingObject
        //{
        //    event EventHandler PreDrawEvent;

        //    event EventHandler IDrawingObject.OnDraw
        //    {
        //        add => PreDrawEvent += value;
        //        remove => PreDrawEvent -= value;
        //    }
        //}
        public async Task M1()
        {
           
            Task.Delay(1000).Wait();
            Console.WriteLine("m1 done ");
        }
        public async Task M2()
        {
            Task.Delay(100).Wait();
            Console.WriteLine("m2 done");
        }
    }
}
