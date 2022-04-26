/*
 * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

A subarray is a contiguous part of an array.	

Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
 */


namespace ALgorithm
{
    class Program
    {
        static void Main()
        {
            int[] nums = { -26, -12, -31, -40, -9, -6, -8, -5, -10 };
            int[] test = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Console.WriteLine(AttestationAlgorithm.MaxSubArray(nums));
        }
    }
    public class AttestationAlgorithm
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();
            if (nums.Length == 1)
                return nums[0];

            bool IsAllZero = true;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 || nums[i] < 0)
                {
                    IsAllZero = false;
                    break;
                }
            }
            if (IsAllZero)
            {
                return 0;
            }

            int sum = int.MinValue;
            int max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                max = max + nums[i];

                if (sum < max)
                {
                    sum = max;
                }
                if (max < 0)
                {
                    max = 0;
                }
            }
            return sum;
        }
    }
}