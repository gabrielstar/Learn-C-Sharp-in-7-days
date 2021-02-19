using System;
using System.Collections.Generic;
using System.Text;

namespace Day02My
{
    //https://stackoverflow.com/questions/6576206/what-is-the-difference-between-the-override-and-new-keywords-in-c
    //Non abstract class templates cannot have abstract methods
    class ConcreteTemplate
    {
        //This is inherited and can be replcaed with new
        protected void MustOverrideMe() { }
        //This will be inherited - abstract class can do that, child class cannot override this only put new in place
        public void YouInheritedMe() { Console.WriteLine("Inherited from abstract"); }
        // we will put new in child class for this
        public void YouInheritedMeNew() { Console.WriteLine("Inherited from parent"); }
        //virtual can but doe not have to be overrident
        public virtual void VirtualMethod() { Console.WriteLine("Virtual from parent"); }
    }
    //template class - deriving class must implement abstract methods
    abstract class AbstractTemplate
    {
        //This must be overriden down
        protected abstract void MustOverrideMe();
        //This will be inherited - abstract class can do that, child class cannot override this only put new in place
        public void YouInheritedMe() { Console.WriteLine("Inherited from abstract"); }
        // we will put new in child class for this
        public void YouInheritedMeNew() { Console.WriteLine("Inherited from abstract to be new"); }
        //virtual can but doe not have to be overrident
        public virtual void VirtualMethod() { Console.WriteLine("Virtual from parent"); }
    }
    interface INewMethod
    {
        public void NewMethod();
    }
    class VirtualNew : ConcreteTemplate, INewMethod
    {
        protected new void MustOverrideMe()
        {
            Console.WriteLine("I had to override MustOverrideMe from abstract");
        }
        // We cannot override inherited member only supply new version
        public new void  YouInheritedMeNew()
        {
            Console.WriteLine("Inherited hidden - New from child");
        }
        //we can override virtual method
        public override void VirtualMethod()
        {
            Console.WriteLine("Virtual from child");
        }

        public void run()
        {
            this.MustOverrideMe();
            //base.MustOverrideMe(); - you cannot call abstract method from parent
            this.YouInheritedMe(); //both will call parent timplementation since we cannot override this and did not put new in place
            base.YouInheritedMe();
            //base.MustOverrideMe(); - you cannot call abstract method from parent
            
            //The differnce between override and new is when we cast object to wider type

            this.YouInheritedMeNew(); // this calls new version of method from our class 
            base.YouInheritedMeNew(); // this calls old version of method - because it is explicit call
            (this as ConcreteTemplate).YouInheritedMeNew(); //new keyword will cause this to use parent implementation because new exists only in child, hides parents
            (this).YouInheritedMeNew();
            
            
            this.VirtualMethod(); //this calls overriden version
            base.VirtualMethod(); //this calls parent version because it is an explicit call
            (this as ConcreteTemplate).VirtualMethod();  //override keyword will cause this to use child implementation - hence override
            (this).VirtualMethod();

        
        }

        public void NewMethod()
        {
            Console.WriteLine("method from interface");
        }
    }
}