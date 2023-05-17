namespace drink_info
{
    public class Validator
    {
        internal static bool IsIdValid(string? drink)
        {
            if(drink==null)
                return false;
            foreach(char c in drink)
            {
                if(!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        internal static bool IsInpuValid(string? category)
        {
            if(category==null)
                return false;
            foreach(char c in category)
            {
                if(!Char.IsLetter(c) && c!='/' && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}