using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_DIS_Spring2021
{
    class Program
    {


        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums = { 2, 5, 1, 3, 4, 7 };
            int n = 3;
            ShuffleArray(nums, n);

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s1 = "bulls";
            string s2 = "sunny";
            if (Isomorphic(s1, s2))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] items = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(items);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 5;
            Stairs(n10);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>

        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                //write your code here.
                int[] shuffle = new int[n * 2];
                int x = 0;
                int z = n;
                if (n * 2 == nums.Length)
                {
                    //this essentially splits the original array in half
                    for (int y = 0; y < n; y++)
                    {
                        //prints the number from the first half of the array
                        shuffle[x] = nums[y];
                        x += 1;
                        //Prints the number from the second half of the array
                        shuffle[x] = nums[z++];
                        x += 1;
                    }

                }
                foreach (int i in shuffle)
                {
                    Console.Write(i);
                }
                Console.WriteLine();

            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>

        private static void MoveZeroes(int[] ar2)
        {
            try
            {
                //write your code here.
                int x = 0;

                for (int i = 0; i < ar2.Length; i++)
                {

                    if (ar2[i] != 0)
                    {
                        //This keeps numbers the same up unil the first zero
                        //At the first zero x does not increment and then
                        //The array at the position of x, the last zero, will be 
                        //ReWritten by the next non zero.
                        ar2[x] = ar2[i];
                        x += 1;
                    }
                }

                while (x < ar2.Length)
                {
                    //The remaining positions, the difference between x and the length
                    //Are written in as the zeroes that were copied over earlier
                    ar2[x] = 0;
                    x += 1;
                }

                foreach (int y in ar2)
                {
                    Console.Write(y + ", ");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        private static void CoolPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> cool = new Dictionary<int, int>();
                int pairs = 0;

                for (int x = 0; x < nums.Length; x++)
                {
                    //Adds to dictionary to get a baseline for how many unique numbers there are 
                    if (!cool.ContainsKey(nums[x]))
                    {
                        cool.Add(nums[x], 1);
                    }
                    else
                    {
                        //For every duplicate number its dictionary value is increased
                        //The number of pairs will equal the number of duplicate valuse 
                        pairs += cool[nums[x]];
                        cool[nums[x]] += 1;
                    }
                }
                Console.WriteLine(pairs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> numDict = new Dictionary<int, int>();

                for (int x = 0; x < nums.Length; x++)
                {

                    int difference = target - nums[x];
                    if (!numDict.ContainsKey(difference))
                    {
                        //The value of each number is the index so it is easy to display
                        numDict.Add(nums[x], x);
                    }
                    else
                    {
                        //For 2 numbers to add to a target 
                        //The array must also have the difference of 
                        //One of the numbers and the target 
                        Console.WriteLine("[" + x + "," + numDict[difference] + "]");
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                List<int> l = indices.ToList();
                //Makes sure that both are equal length so they can be shuffled correctly

                if (indices.Length == s.Length)
                {
                    char[] shuffle = new char[s.Length];
                    for (int x = 0; x < s.Length; x++)
                    {
                        //Since the array is scrambled
                        //Unlike most problems the array is not filled
                        //From 0-end, but rather the order specified
                        //by the indices array
                        shuffle[indices[x]] = s[x];

                    }
                    string restored = new string(shuffle);
                    Console.WriteLine(restored);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        private static bool Isomorphic(string s1, string s2)
        {
            try
            {
                Dictionary<char, int> s1dict = new Dictionary<char, int>();
                Dictionary<char, int> s2dict = new Dictionary<char, int>();

                if (s1.Length != s2.Length)
                {
                    return false;
                }

                //A key thing to note with this problem is that 
                //the words must have the same amount of unique letters
                //and any duplicate letters must be in the same positions
                //for each word
                //Dictionaries allow this to be checked by assigning values 
                //For each position of unique and duplicate characters
                //And allowing for easy checking if duplicates exists
                for (int x = 0; x < s1.Length; x++)
                {
                    if (!s1dict.ContainsKey(s1[x]))
                    {
                        s1dict.Add(s1[x], 0);
                    }
                    if (!s2dict.ContainsKey(s2[x]))
                    {
                        s2dict.Add(s2[x], 0);
                    }
                    //If the values are not the same that means
                    //One string has a duplicate character where the other
                    //Does not
                    if (s1dict[s1[x]] != s2dict[s2[x]])
                    {
                        return false;
                    }

                    s1dict[s1[x]] = x + 1;
                    s2dict[s2[x]] = x + 1;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>

        private static void HighFive(int[,] items)
        {

            try
            {
                //Convert the 2d array into a list that is easier to work with
                List<int[]> itemlist = new List<int[]>();

                for (int i = 0; i < items.GetLength(0); i++)
                {
                    itemlist.Add(new int[] { items[i, 0], items[i, 1] });
                }



                //Sorts the grades in descending order
                itemlist.Sort((a, b) => b[1].CompareTo(a[1]));
                //Sorts the student ids in ascending order
                itemlist.Sort((a, b) => a[0].CompareTo(b[0]));

                Dictionary<int, int> dict = new Dictionary<int, int>();
                //When the first instance of a new ID is shown, the value there will be the highest grade
                //and the next 4 will be the next 4 highest, so this will give the top 5 grades 
                for (int y = 0; y < items.GetLength(0); y++)
                {
                    if (!dict.ContainsKey(items[y, 0]))
                    {
                        dict.Add(items[y, 0], ((itemlist[y][1] + itemlist[y + 1][1] + itemlist[y + 2][1] + itemlist[y + 3][1] + itemlist[y + 4][1])) / 5);
                    }
                }

                foreach (var pair in dict)
                {
                    Console.Write(pair + ", ");
                }



            }

            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>

        private static bool HappyNumber(int n)
        {
            try
            {
                int result = n;
                HashSet<int> check = new HashSet<int>();
                Double powersum = 0;

                while (result != 1)
                {
                    while (n > 0)
                    {

                        //breaks down the number for each digit
                        //and then squares it and adds it to the sum of squares 
                        powersum += Math.Pow((n % 10), 2);
                        n = n / 10;
                    }

                    result = (int)powersum;
                    n = result;
                    if (check.Contains(n))
                    {
                        return false;
                    }
                    else
                    {
                        //This checks to see if a number has been checked already, avoiding an infinite loop
                        check.Add(n);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        private static int Stocks(int[] prices)
        {
            try
            {
                int max = 0;
                int profit = 0;
                for (int x = 0; x < prices.Length - 1; x++)
                {
                    //Loops through the remaining units to see if they are higher than 
                    //the value at x 
                    for (int y = x + 1; y < prices.Length; y++)
                    {
                        profit = prices[y] - prices[x];
                        //if the second value is higher than the first value it becomes 
                        //the max profit
                        //if numbers later in the loop create a greater profit
                        //the profit variable is changed to that value
                        if (profit > max)
                        {
                            max = profit;
                        }
                    }
                }
                return max;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>

        private static void Stairs(int steps)
        {
            try
            {
                //because of how the sequence worked it seemed easier to just 
                //put these if checks in to skip computation of the first steps 
                if (steps == 0)
                {
                    Console.WriteLine(0);
                }
                if (steps == 1)
                {
                    Console.WriteLine(1);
                }
                if (steps == 2)
                {
                    Console.WriteLine(2);
                }
                int a = 0;
                int b = 1;
                int c = 0;
                if (steps > 2)
                {
                    //This is essentially a fibonacci problem that starts 3 positions in to the sequence
                    for (int i = 0; i < steps; i++)
                    {
                        c = a + b;
                        a = b;
                        b = c;
                    }
                    Console.WriteLine(c + "possible step combinations");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
