using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace Day02My
{
    class ProgramAsync
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting tasks");
            Task<Coffee> task1 = getAsyncTask1(); //we create a task, it starts executing here in non blocking manner
            Task<Juice> task2 = getAsyncTask2(); //this task also gets executed immediately in non blocking manner 
            Task finalize1 = finalTask1();
            Task finalize2 = finalTask2();

            Task.Delay(300).Wait(); //traditional stuff
            Console.WriteLine("This executes 300ms after tasks start"); //we continue traditional stuff but async tasks run in background

            Juice juice = await task2; //here we block until task is complete, but until now it has been executing - it means we need a result here
            Console.WriteLine($"{juice.Type} juice ready. This executes after task2 completes more or less after 500ms"); //we continue traditional stuff
            Console.WriteLine($"\tTask1 status: {task1.Status}, \n\tTask2: {task2.Status}");

            Coffee coffee = await task1; //here we wait until task 2 completes
            Console.WriteLine($"{coffee.Name} coffee prepared. This executes after task1 completes, more or less after 1000ms"); //we continue traditional stuff
            Console.WriteLine("All complete");
            Console.WriteLine("If we run all these without async it would take 300+500+1000 = 1800ms");

            //example waiting for many tasks at once
            await Task.WhenAll(new List<Task> { finalize1, finalize2 }); //wait for list of task - when all complete

            //example waiting each as they go
            finalize1 = finalTask1();
            finalize2 = finalTask2();
            var finalTasks = new List<Task> { finalize1, finalize2 };
            while (finalTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(finalTasks);
                if (finishedTask == finalize1)
                {
                    Console.WriteLine("F1 ended");
                }
                else
                {
                    Console.WriteLine("F2 ended");
                }
                finalTasks.Remove(finishedTask);
            }
        }

        private static async Task<Coffee> getAsyncTask1() //async method should return Task<T> or Task if it woudl return null
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("brewing coffee ..");
                await Task.Delay(100);
            }
            return new Coffee();
        }
        private static async Task<Juice> getAsyncTask2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("pouring juice ..");
                await Task.Delay(100);
            }
            return new Juice();
        }
        private static async Task finalTask1()
        {
            await Task.Delay(1500);
            Console.WriteLine("Finalize all - 1");
        }
        private static async Task finalTask2()
        {
            await Task.Delay(1500);
            Console.WriteLine("Finalize all - 2");
        }

    }
}

