namespace CopaFilmes.Utils
{
    public class NumberToLetterUtil
    {
        public static string GetName(int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return "Group" + value;
        }
    }
}