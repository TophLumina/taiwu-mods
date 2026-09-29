using System;
using System.Text.RegularExpressions;

namespace GameData.Utilities;

public static class StringFormatExtensions
{
	private static readonly Regex PascalSnakeCheckerRegex = new Regex("[^A-Za-z0-9_]", RegexOptions.Compiled);

	private static readonly Regex PascalSnakeRegex = new Regex("(?<!^)(?<!_)(?=[A-Z][a-z])|(?<=[a-z])(?=[A-Z])|(?<=[a-z])(?=[0-9]+[A-Za-z])|(?<=[A-Z])(?=[0-9]+(?=[a-z]|[A-Z]$))", RegexOptions.Compiled);

	public static string GetFormat(this string str, object arg0)
	{
		try
		{
			return string.Format(str, arg0);
		}
		catch (Exception arg1)
		{
			AdaptableLog.Warning($"Failed to format string \"{str}\" with args [{arg0}]\n{arg1}", appendWarningMessage: true);
			return str;
		}
	}

	public static string GetFormat(this string str, object arg0, object arg1)
	{
		try
		{
			return string.Format(str, arg0, arg1);
		}
		catch (Exception ex)
		{
			AdaptableLog.Warning($"Failed to format string \"{str}\" with args [{arg0},{arg1}]\n{ex}", appendWarningMessage: true);
			return str;
		}
	}

	public static string GetFormat(this string str, object arg0, object arg1, object arg2)
	{
		try
		{
			return string.Format(str, arg0, arg1, arg2);
		}
		catch (Exception ex)
		{
			AdaptableLog.Warning($"Failed to format string \"{str}\" with args [{arg0},{arg1},{arg2}]\n{ex}", appendWarningMessage: true);
			return str;
		}
	}

	public static string GetFormat(this string str, params object[] args)
	{
		try
		{
			return string.Format(str, args);
		}
		catch (Exception arg)
		{
			AdaptableLog.Warning($"Failed to format string \"{str}\" with args [{((args == null) ? string.Empty : string.Join(',', args))}].\n{arg}", appendWarningMessage: true);
			return str;
		}
	}

	public static string PascalToSnakeCase(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return str;
		}
		if (PascalSnakeCheckerRegex.IsMatch(str))
		{
			throw new NotSupportedException("not supported " + str);
		}
		return PascalSnakeRegex.Replace(str, "_").ToLower();
	}

	public static string ReplaceLast(this string input, string oldValue, string newValue)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		int index = input.LastIndexOf(oldValue, StringComparison.Ordinal);
		if (index < 0)
		{
			return input;
		}
		string prefix = ((index > 0) ? input.Substring(0, index) : string.Empty);
		string text;
		if (index + oldValue.Length >= input.Length)
		{
			text = string.Empty;
		}
		else
		{
			int num = index + oldValue.Length;
			text = input.Substring(num, input.Length - num);
		}
		string suffix = text;
		string result = newValue;
		if (!string.IsNullOrEmpty(prefix))
		{
			result = prefix + result;
		}
		if (!string.IsNullOrEmpty(suffix))
		{
			result += suffix;
		}
		return result;
	}

	public static string FirstCharToLower(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		if (input.Length == 1)
		{
			return input.ToLower();
		}
		return char.ToLower(input[0]) + input.Substring(1, input.Length - 1);
	}

	public static string FirstCharToUpper(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		if (input.Length == 1)
		{
			return input.ToUpper();
		}
		return char.ToUpper(input[0]) + input.Substring(1, input.Length - 1);
	}

	public static string ToQuotientRemainderString(this int dividend, int divisor)
	{
		int integer = dividend / divisor;
		int remainder = dividend % divisor;
		if (remainder == 0)
		{
			return integer.ToString();
		}
		int digits = GetDigits(divisor);
		return $"{integer}.{remainder.ToString().PadLeft(digits, '0')}";
	}

	private static int GetDigits(int n)
	{
		int digits = 1;
		while (n > 10)
		{
			n /= 10;
			digits++;
		}
		return digits;
	}
}
