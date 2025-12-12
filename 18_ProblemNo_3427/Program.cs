using Microsoft.Extensions.DependencyInjection;

namespace _18_ProblemNo_3427
{
    /// <summary>
    /// https://leetcode.com/problems/sum-of-variable-length-subarrays/submissions/1851896392/?envType=problem-list-v2&envId=prefix-sum
    /// TIME, SPACE : O(n)
    /// </summary>
    public class Program
    {
        public static void MainOptimizedToDependencyInjection(string[] args)
        {
            //// Optimized to Follows Singleton Pattern, Dependency Inversion, Difficult for UnitTest/Mock due to static field
            ISolution solution = Solution.GetInstance;
            solution.SubarraySum(new int[] { 3, 1, 1, 2 });
        }

        public static void Main(string[] args)
        {
            //// Optimized to Follows Singleton Pattern, Dependency Inversion, Dependency Injection, Also Testable
            var services = new ServiceCollection();
            // Singleton lifetime matches original behavior
            services.AddSingleton<ISolution, Solution>(); 
            var serviceProvider = services.BuildServiceProvider();

            ISolution solution = serviceProvider.GetRequiredService<ISolution>();
            ////ISolution solution = solutionInstance;
            solution.SubarraySum(new int[] { 3, 1, 1, 2 });
        }
    }

    public sealed class Solution : ISolution
    {
        private static readonly ISolution instance;

        public static ISolution GetInstance => instance;

        static Solution()
        {
            instance = new Solution();
        }

        public int SubarraySum(int[] nums)
        {
            int totalResult = 0;
            int[] preFixArray = this.BuildPrefixSumArray(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                int start = Math.Max(0, i - nums[i]);

                if (start - 1 >= 0)
                {
                    ////totalResult += preFixArray[i] - preFixArray[i - 2];
                    totalResult += preFixArray[i] - preFixArray[start - 1];
                }
                else
                {
                    totalResult += preFixArray[i];
                }
            }

            return totalResult;
        }

        private int[] BuildPrefixSumArray(int[] nums)
        {
            int[] prefixArrayResult = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++) 
            {
                if(i - 1 >= 0)
                {
                    prefixArrayResult[i] = nums[i] + prefixArrayResult[i - 1];
                }
                else
                {
                    prefixArrayResult[i] = nums[i];
                }
                 
            }

            return prefixArrayResult;
        }
    }
}
