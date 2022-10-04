namespace Program
{
    class Program
    {
        public static void Main()
        {
            int[] array = new int[] { 1, 2, 3 };
            Insert(0, ref array);
            foreach (int x in array)
            {
                Console.WriteLine(x);
            }

        }

        public static int BinarySearch(in int value, in int[] array, in int left, in int right)
        {
            int middle = (left + right) / 2;
            int midElement = array[middle];

            if (midElement == value)
                return middle;
            if (left < right)
            {
                if (value < array[middle])
                    return BinarySearch(value, array, left, middle - 1);
                return BinarySearch(value, array, middle + 1, right);
            }
            return -1;
        }

        public static int Insert(in int value, ref int[] array)
        {

            int[] newArray = new int[array.Length + 1];

            if (value <= array[0])
            {
                newArray[0] = value;
                Step1(ref array, ref newArray, 0, array.Length);
                array = newArray;
                return 0;
            }

            if (value >= array[array.Length - 1])
            {
                newArray[array.Length] = value;
                Step2(ref array, ref newArray, 0, array.Length);
                array = newArray;
                return array.Length;
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] <= value && value <= array[i])
                {
                    Step2(ref array, ref newArray, 0, i);
                    newArray[i] = value;
                    Step1(ref array, ref newArray, i, array.Length);
                    array = newArray;
                    return i;
                }
            }

            return -1;
        }

        static void Step1(ref int[] array, ref int[] newArray, int start, int end)
        {
            for (int i = start; i < end; ++i)
            {
                newArray[i + 1] = array[i];
            }
        }

        static void Step2(ref int[] array, ref int[] newArray, int start, int end)
        {
            for (int j = start; j < end; ++j)
            {
                newArray[j] = array[j];
            }
        }
    }
}