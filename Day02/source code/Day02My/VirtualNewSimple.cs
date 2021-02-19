using System;
using System.Collections.Generic;
using System.Text;

namespace Day02My
{
    class A
    {
        public virtual int Hello()
        {
            return 1;
        }
    }

    class B : A
    {
        new public int Hello(object newParam)
        {
            return 2;
        }
    }

    class C : A
    {
        public override int Hello()
        {
            return 3;
        }
    }
    class VirtualNewSimple : ConcreteTemplate
    {


        public void run()
        {
            A objectA;
            B objectB = new B();
            C objectC = new C();

            //Normall when used in child eveyrthing is as expected
            Console.WriteLine(objectB.Hello(null)); // 2
            Console.WriteLine(objectC.Hello()); // 3

            //Now new will not force new method to be used only A implemtation that is because new hides the parent but does not make it perm/default
            objectA = objectB;

            Console.WriteLine(objectA.Hello()); // 1

            //Override will actuall override the A method here
            objectA  = objectC;

            Console.WriteLine(objectA.Hello()); // 3
        }
    }
}