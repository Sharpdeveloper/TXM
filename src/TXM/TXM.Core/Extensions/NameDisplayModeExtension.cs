using TXM.Core.Global;

namespace TXM.Core.Extensions;

using TXM.Core.Enums;

public static class NameDisplayModeExtension
{
    public static string GetText(this NameDisplayMode ndm)
    {
        return ndm switch
        {
            NameDisplayMode.Nick => State.Text.DisplayOnlyNick
            , NameDisplayMode.FirstLast => State.Text.DisplayFirstAndLast
            , NameDisplayMode.FirstNick => State.Text.DisplayFirstAndNick
            , NameDisplayMode.FirstNickLast => State.Text.DisplayFirstNickAndLast
            , NameDisplayMode.FistLastShort => State.Text.DisplayFirstAndLastShort
            , _ => ""
        };
    }

    public static List<string> GetTexts(this NameDisplayMode ndm)
    {
        return (from int i in Enum.GetValues(typeof(NameDisplayMode)) select GetText((NameDisplayMode)i)).ToList();
    }

    public static NameDisplayMode GetDisplayMode(this string ndmtext)
    {
        if (ndmtext == State.Text.DisplayFirstAndLast)
        {
            return NameDisplayMode.FirstLast;
        }
        if (ndmtext == State.Text.DisplayFirstAndNick)
        {
            return NameDisplayMode.FirstNick;
        }
        if (ndmtext == State.Text.DisplayFirstNickAndLast)
        {
            return NameDisplayMode.FirstNickLast;
        }
        if (ndmtext == State.Text.DisplayFirstAndLastShort)
        {
            return NameDisplayMode.FistLastShort;
        }
        
        //if (ndmtext == State.Text.DisplayOnlyNick)
        return NameDisplayMode.Nick;
    }
}