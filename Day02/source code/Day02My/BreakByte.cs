using System;
using static System.Console;



namespace Day02My
{
    /*
     * Shows usage of 'break' and 'byte','checked'
     * compile time errors and avoiding them with checked/unchecked
     * sizeof
     */
    class BreakByte : Section
    {
        public override void runAsync()
        {
            //_sizeof();
            //_checked();
            //_nameof();
            //new VirtualNew().run(); - abstract, new, override, virtual
            //new VirtualNewSimple().run(); - abstract, new, override, virtual
            _using();
            Console.ReadLine();

        }
        private void _using()
        {
            /*
             *  The using keyword has three major uses:
                The using statement defines a scope at the end of which an object will be disposed.
                The using directive creates an alias for a namespace or imports types defined in other namespaces.
                The using static directive imports the members of a single class.
             */
            using (var disposableClass = new DisposableClass()) //object is scoped to the block, something we need temporarily
            {
                WriteLine($"{disposableClass.Message}");
            }
            //object does not  exist here anymore, has been disposed

        }
        private void _nameof()
        {
            Console.WriteLine($"Program {nameof(Program)} is of type {typeof(Program)}");
            var obj = new Program();
            Console.WriteLine($"Program {nameof(obj)} is of type {obj.GetType()}");
            Console.ReadLine();
        }

        private void _sizeof()
        {
            WriteLine("Various inbuilt types have size as mentioned below:\n");
            WriteLine($"The size of data type int is: {sizeof(int)}");
            WriteLine($"The size of data type long is: {sizeof(long)}");
            WriteLine($"The size of data type double is: {sizeof(double)}");
            WriteLine($"The size of data type bool is: {sizeof(bool)}");
            WriteLine($"The size of data type short is: {sizeof(short)}");
            WriteLine($"The size of data type byte is: {sizeof(byte)}");
        }

        private void _checked()
        {
            int a = unchecked(int.MaxValue + 222222222); //will skip overflwo check otherwise will  get oveflow
            var maxValue = int.MaxValue;
            var addSugar = 19;
            var sumWillThrowError = checked(maxValue + addSugar); //compile time error because we explicitely check the var, allows for var and save calculation
            var sumWillNotThrowError = maxValue + addSugar; //no compile time error - no overflow exception because of var
                                                            // int32                  int      + int  - the resolved type will depend on arguments
                                                            //var allows any type to be
            WriteLine($"Sum value {sumWillNotThrowError} is not the correct one for {sumWillNotThrowError.GetType()}");
            ReadLine();

        }

    }
}
