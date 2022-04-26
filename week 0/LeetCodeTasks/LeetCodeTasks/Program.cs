// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int[] rotate = new int[] { 1, 2, 3, 4, 5, 6, 7 };
int[] singleNum = new int[] { 7, 9, 7, 6, 7, 9, 6, 8 };

int[] nums1 = { 4, 9, 5 };
int[] nums2 = { 9, 4, 9, 8, 4 };


Solution solution = new Solution();

foreach (int item in nums2)
{
    Console.Write(item + " ");
}
Console.WriteLine();
foreach (int item in nums2)
{
    Console.Write(item + " ");
}
//var intersection = solution.Intersect(nums1, nums2);

//for (int i = 0; i < intersection.Length; i++)
//{
//    Console.Write(intersection[i] + " ");
//}

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        if (nums.Length % 2 == 0)
            throw new ArgumentException("Every element appears twice except for one.");

        bool flag = false;
        for (int i = 0; i < nums.Length; i++)
        {

            for (int y = 0; y < nums.Length; y++)
            {
                if (i != y && nums[i] == nums[y])
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                return nums[i];
            }
            flag = false;
        }
        return -1;
    }
    public void Rotate(int[] nums, int k)
    {
        if ((nums.Length == 0 || nums.Length == 1) && k <= 0)
            return;

        int helper;
        for (int i = 0; i < k; i++)
        {
            helper = nums.Last();
            for (int y = nums.Length - 1; y != 0; y--)
            {
                nums[y] = nums[y - 1];
            }
            nums[0] = helper;
        }
    }
    public void RotateInConstantTime(int[] nums, int k)
    {

        Queue<int> numbersQueue = new Queue<int>(nums);
        for (int i = 0; i < k; i++)
        {
            numbersQueue.Enqueue(numbersQueue.Dequeue());
        }
        numbersQueue.CopyTo(nums, 0);
    }
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        bool flag = false;
        if (nums1.Length < nums2.Length)
        {
            for (int i = 0; i < nums2.Length; i++)
            {
                for (int y = 0; y < nums1.Length; y++)
                {
                    if (nums2[i] == nums1[y])
                    {
                        flag = true;
                    }
                }
            }
        }
        return nums1;
    }
}