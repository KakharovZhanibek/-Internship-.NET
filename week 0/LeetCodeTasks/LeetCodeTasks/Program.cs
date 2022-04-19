// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
Solution solution = new Solution();
solution.Rotate(nums,3);
public class Solution
{
    public int SingleNumber(int[] nums)
    {

        int number = -777;
        bool flag = false;
        for (int i = 0; i < nums.Length; i++)
        {

            for (int y = 0; y < nums.Length - 1; y++)
            {
                if (i != y && nums[i] == nums[y])
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                number = nums[i];
                break;
            }
        }
        return number;
    }
    public void Rotate(int[] nums, int k)
    {
        nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
      

        result= result.Concat(nums.Skip(k+1).Take(nums.Length - k+1)).ToArray();
        result = result.Concat(nums.Take(k)).ToArray();

        foreach (int item in result)
        {
            Console.WriteLine(item);
        }
    }
}