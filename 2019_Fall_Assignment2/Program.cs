using System;
using System.Collections.Generic;
using System.Linq;


namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static int toSearch = 0;

        public static void Main(string[] args)
        {

            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int n = nums.Length;
                int result = searchAlgo(nums, 0, n - 1, target);

                return result; // Write your code here 
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int searchAlgo(int[] nums, int l, int r, int x)
        {

            if (r >= l)
            {
                int mid = l + (r - l) / 2; //dividing into mid point for right and left half for o(logn)


                if (nums[mid] == x)
                    return mid;


                else if (nums[mid] > x)
                {
                    toSearch = mid - 1;
                    return searchAlgo(nums, l, mid - 1, x); // searching left half if number, notice recursion
                }


                // Else the element can only be present 
                // in right half 
                else
                {
                    toSearch = mid + 1;
                    return searchAlgo(nums, mid + 1, r, x);
                }


            }
            return toSearch;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {

                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                IDictionary<char, int> d = new Dictionary<char, int>(); //create dict
                char[] charArr = keyboard.ToCharArray(); //convert to char array
                char[] wordArr = word.ToCharArray(); //convert to char array
                int i = 0;
                int temp = 0; int next = 0; int result = 0;
                foreach (char ch in charArr)
                {

                    d.Add(ch, i); //add keyboard to dictionary
                    i++;
                }

                //var d = charArr.ToDictionary(x => Array.IndexOf(charArr, x));

                foreach (char ch in wordArr)
                {
                    next = d[ch];

                    result = result + (Math.Abs(next - temp)); //calculate timings

                    temp = next;
                }
                return result;
                //Console.WriteLine("this is the keyboard time" + result);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                /*int xlen = (A.Length / 2)-1; int temp;
                for(int i =0; i<=xlen; i++)
                {
                    for(int j=0; j<=1; j++)
                    {
                        temp = A[i, 0];
                        A[i, 0] = A[i, xlen];
                        A[i, xlen] = temp;

                    } 
                }
                Display2DArray(A);
                // Write your code here */
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                string copy = s;

                if (!s.SequenceEqual(s.Reverse())) //initial palindrome check
                {

                    foreach (char ch in copy)
                    {
                        copy = s.Replace(ch.ToString(), string.Empty); //remove each and every character and check
                        if (copy.SequenceEqual(copy.Reverse()))
                        {
                            return true;

                        }// Write your code here
                    }
                }
                else
                    return true;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
