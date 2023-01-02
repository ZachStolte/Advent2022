    //Created by Justin Kennedy, used with permission by Zachary Stolte  
    //This program is used to simplify the setup process for each day
    class Program
    {
        static string FILE_NAME = "Inputs/input{0}.txt";
        static string TEST_FILE_NAME = "Inputs/input{0}sample.txt";

        public static void Main(string[] args)
        {

            string day = args[0];
            string part = args[1];
        
            Type type = Type.GetType(string.Concat("Day", day));
            var method = type.GetMethod(string.Concat("Part", part));
            string fileName = string.Format(args.Length >= 3 && args[2] == "test"
                ? TEST_FILE_NAME
                : FILE_NAME, day
                );

            try
            {
                StreamReader sr = new StreamReader(fileName);
                object[] arguments = { sr };

                method.Invoke(null, arguments);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("$Woopsie-Doopsie! File {fileName} does not exist yet");
                return;
            }
        }
        public static int[] StringArrayToInt(string[] input)
        {
            int[] array = new int[input.Count()];
            for (int i = 0; i < input.Count(); i++)
            {
                array[i] = int.Parse(input[i]);
            }
            return array;
        }
    }
