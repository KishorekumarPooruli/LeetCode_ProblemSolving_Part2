using _19_ProblemNo_724.Factory;
using _19_ProblemNo_724.Services;
using Microsoft.Extensions.DependencyInjection;

namespace _19_ProblemNo_724
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ISolutionFactory solutionFactory = new SolutionFactory(); //// INJECT dependency            
            //ISolution solution = solutionFactory.CreateSolutionProvider();
            //int result = solution.PivotIndex(new int[] { 2, 1, -1 });


            // Setup DI container (Microsoft.Extensions.DependencyInjection)
            var services = new ServiceCollection();

            // Register as Singleton - DI container ensures single instance
            services.AddSingleton<IFactory, Factory.Factory>();
            services.AddSingleton<IPivotSolution>(sp =>
                sp.GetRequiredService<IFactory>().CreatePivotSolutionProvider());

            var serviceProvider = services.BuildServiceProvider();

            // Resolve dependencies
            var solution = serviceProvider.GetRequiredService<IPivotSolution>();
            int result = solution.PivotIndex(new int[] { 2, 1, -1 });
            Console.WriteLine($"Pivot Index: {result}");
        }
    }
}
