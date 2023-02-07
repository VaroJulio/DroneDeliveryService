namespace Domain.Utils
{
    public static class StringHelper
    {
        public static string Remove(this string theString, string[] stringListToRemove)
        {
            foreach (var character in stringListToRemove)
                theString = theString.Replace(character, null);

            return theString;
        }
    }
}
