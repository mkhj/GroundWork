using System;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace GroundWork.Core;

public static class StringExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string text)
    {
        return string.IsNullOrEmpty(text);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsNotNullOrEmpty(this string text)
    {
        return !string.IsNullOrEmpty(text);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string CapitalizeFirstWord(this string text)
    {
        return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string CapitalizeAllWords(this string text)
    {
        if (text == null)
        {
            throw new ArgumentNullException("value");
        }

        if (text.Length == 0)
        {
            return text;
        }

        var result = new StringBuilder(text);
        result[0] = char.ToUpper(result[0]);
        for (int i = 1; i < result.Length; ++i)
        {
            if (char.IsWhiteSpace(result[i - 1]))
            {
                result[i] = char.ToUpper(result[i]);
            }
            else
            {
                result[i] = char.ToLower(result[i]);
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool IsEmailAddress(this string email)
    {
        var pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
        return Regex.Match(email, pattern).Success;
    }

    /// <summary>
    /// Truncates the string to a specified length and replace the truncated to a ...
    /// </summary>
    /// <param name="text">string that will be truncated</param>
    /// <param name="maxLength">total length of characters to maintain before the truncate happens</param>
    /// <returns>truncated string</returns>
    public static string Truncate(this string text, int maxLength)
    {
        // replaces the truncated string to a ...
        const string suffix = "...";
        string truncatedString = text;

        if (maxLength <= 0) return truncatedString;
        int strLength = maxLength - suffix.Length;

        if (strLength <= 0) return truncatedString;

        if (text == null || text.Length <= maxLength) return truncatedString;

        truncatedString = text.Substring(0, strLength);
        truncatedString = truncatedString.TrimEnd();
        truncatedString += suffix;

        return truncatedString;
    }

    public static string ToUrlSlug(this string phrase, int maxLength = 50)
    {
        var str = phrase.ToLower();

        str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars           
        str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space   
        str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim(); // cut and trim it   
        str = Regex.Replace(str, @"\s", "-"); // hyphens   

        return str;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="txt"></param>
    /// <returns></returns>
    public static string RemoveAccent(this string txt)
    {
        byte[] bytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(txt);
        return System.Text.Encoding.ASCII.GetString(bytes);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsInt(this string value)
    {
        var number = 0;
        var result = int.TryParse(value, out number); // TryParse returns True if successful 
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToInt(this string value)
    {
        var result = 0;
        int.TryParse(value, out result);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsDecimal(this string value)
    {
        var number = 0.0;
        var result = Double.TryParse(value, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal ToDecimal(this string value)
    {
        var result = 0m;
        decimal.TryParse(value, out result);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Guid ToGuid(this string value)
    {
        var result = Guid.Empty;
        Guid.TryParse(value, out result);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="values"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    public static string Join(this string[] values, string separator)
    {
        return string.Join(separator, values);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string Reverse(this string text)
    {
        var charArray = text.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int Frequency(this string text, string value)
    {
        return Regex.Matches(text, value, RegexOptions.IgnoreCase).Count;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T FromJSON<T>(this string obj)
    {
        return JsonSerializer.Deserialize<T>(obj);
    }
}

