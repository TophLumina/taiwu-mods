using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameData;
using GameData.Utilities;

/// <summary>
/// 多语言文本管理器
/// </summary>
public static class LocalStringManager
{
	public enum LanguageType
	{
		CN,
		EN,
		KO,
		CNH,
		JP
	}

	/// <summary>
	/// 语言包信息
	/// </summary>
	public class LanguagePackInfo
	{
		/// <summary>
		/// 语言包名
		/// </summary>
		public string PackName;

		/// <summary>
		/// 打包文本
		/// </summary>
		public Dictionary<string, string> PackedTexts;

		/// <summary>
		/// 语言包字典
		/// </summary>
		public Dictionary<string, string> MapLanguageData;
	}

	/// <summary>
	/// 常驻的随时都可以查询任何语言文本的特殊 <see cref="T:LanguageKey" /> 集合
	/// </summary>
	public static readonly IReadOnlyCollection<LanguageKey> CrossLanguageKeys = new LanguageKey[6]
	{
		LanguageKey.LK_Yes,
		LanguageKey.LK_No,
		LanguageKey.LK_Confirm,
		LanguageKey.LK_Cancel,
		LanguageKey.LK_SystemSetting_LocalizationSetting_Language_Self,
		LanguageKey.LK_SystemSetting_LocalizationSetting_Language_Reset_Text
	};

	private const string LanguageFolderPath = "StreamingAssets";

	private const string UiLanguageFileName = "ui_language";

	private static readonly string ConfigArrayDicSeparator = new string('>', 50);

	private static Dictionary<string, LanguagePackInfo> _configLanguageMap;

	private static string[] _cachedUiTexts;

	private static Func<string, string> _customLanguageHandlerOfKey;

	private static Func<ushort, string> _customLanguageHandlerOfId;

	private static readonly Dictionary<string, Dictionary<LanguageKey, string>> CrossLanguageTexts = new Dictionary<string, Dictionary<LanguageKey, string>>();

	private static string[] _number2String;

	private static string[] _quantifier;

	private static string _zero;

	private static string _ten;

	private static string _negative;

	private static readonly StringBuilder StringBuilder = new StringBuilder();

	/// <summary>
	/// UI界面语言是否已经完成初始化
	/// </summary>
	public static bool UiLanguageInitReady => _cachedUiTexts != null;

	/// <summary>
	/// 配置表语言包是否完成初始化
	/// </summary>
	public static bool ConfigLanguageInitReady => _configLanguageMap != null;

	/// <summary>
	/// 当前语言索引
	/// </summary>
	public static string CurLanguageKey => ExternalDataBridge.Context.Language;

	/// <summary>
	/// 当前语言的枚举
	/// </summary>
	public static LanguageType CurLanguageType
	{
		get
		{
			if (!Enum.TryParse<LanguageType>(CurLanguageKey, out var languageType))
			{
				return LanguageType.EN;
			}
			return languageType;
		}
	}

	/// <summary>
	/// 初始化数字转换器常量
	/// </summary>
	private static void CnNumberConverterInit()
	{
		_number2String = new string[10]
		{
			Get(LanguageKey.LK_Number0),
			Get(LanguageKey.LK_Number1),
			Get(LanguageKey.LK_Number2),
			Get(LanguageKey.LK_Number3),
			Get(LanguageKey.LK_Number4),
			Get(LanguageKey.LK_Number5),
			Get(LanguageKey.LK_Number6),
			Get(LanguageKey.LK_Number7),
			Get(LanguageKey.LK_Number8),
			Get(LanguageKey.LK_Number9)
		};
		_quantifier = new string[19]
		{
			Get(LanguageKey.LK_NumberQuantifier0),
			Get(LanguageKey.LK_NumberQuantifier1),
			Get(LanguageKey.LK_NumberQuantifier2),
			Get(LanguageKey.LK_NumberQuantifier3),
			Get(LanguageKey.LK_NumberQuantifier0),
			Get(LanguageKey.LK_NumberQuantifier1),
			Get(LanguageKey.LK_NumberQuantifier2),
			Get(LanguageKey.LK_NumberQuantifier4),
			Get(LanguageKey.LK_NumberQuantifier0),
			Get(LanguageKey.LK_NumberQuantifier1),
			Get(LanguageKey.LK_NumberQuantifier2),
			Get(LanguageKey.LK_NumberQuantifier3),
			Get(LanguageKey.LK_NumberQuantifier0),
			Get(LanguageKey.LK_NumberQuantifier1),
			Get(LanguageKey.LK_NumberQuantifier2),
			Get(LanguageKey.LK_NumberQuantifier3),
			Get(LanguageKey.LK_NumberQuantifier0),
			Get(LanguageKey.LK_NumberQuantifier1),
			Get(LanguageKey.LK_NumberQuantifier2)
		};
		_zero = Get(LanguageKey.LK_Number0);
		_ten = Get(LanguageKey.LK_NumberQuantifier0);
		_negative = Get(LanguageKey.LK_NumberNegative);
	}

	/// <summary>
	/// 将数字转换为本地化字符串
	/// </summary>
	private static string CnNumberConverter(long number)
	{
		StringBuilder builder = StringBuilder;
		builder.Clear();
		if (number < 0)
		{
			builder.Append(_negative);
		}
		string numberStr = NumberStr(number);
		for (int i = 0; i < numberStr.Length; i++)
		{
			char numberChar = numberStr[i];
			int quantifierCount = numberStr.Length - i - 1;
			string quantifierString = ((quantifierCount == 0) ? string.Empty : _quantifier[quantifierCount - 1]);
			if (numberChar == '1' && i == 0 && quantifierString == _ten)
			{
				builder.Append(quantifierString);
				continue;
			}
			int num;
			if (numberChar == '0' && builder.Length > 0)
			{
				num = ((builder[builder.Length - 1].ToString() == _number2String[0]) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool isContinuousZero = (byte)num != 0;
			if (numberChar == '0' && quantifierCount > 0 && quantifierCount % 4 == 0 && (quantifierCount / 4 == (numberStr.Length - 1) / 4 || quantifierCount > 4))
			{
				if (isContinuousZero)
				{
					builder[builder.Length - 1] = quantifierString[0];
				}
				else
				{
					builder.Append(quantifierString);
				}
			}
			else if (!isContinuousZero)
			{
				builder.Append(NumberCharToString(i));
				if (numberChar != '0' && !string.IsNullOrEmpty(quantifierString))
				{
					builder.Append(quantifierString);
				}
			}
		}
		if (numberStr.Length > 1)
		{
			if (builder[builder.Length - 1].ToString() == _zero)
			{
				builder.Remove(builder.Length - 1, 1);
			}
		}
		return builder.ToString();
		string NumberCharToString(int index)
		{
			return _number2String[int.Parse(numberStr[index].ToString())];
		}
	}

	private static string NumberStr(long number)
	{
		if (number >= 0)
		{
			return number.ToString();
		}
		if (number == long.MinValue)
		{
			return 9223372036854775808uL.ToString();
		}
		return (-number).ToString();
	}

	private static void CollectLanguages()
	{
		CrossLanguageTexts.Clear();
		string[] directories = Directory.GetDirectories(Path.Combine(ExternalDataBridge.Context.DataPath, "StreamingAssets"), "Language_*");
		foreach (string key in directories)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(key);
			int length = "Language_".Length;
			string basis = fileNameWithoutExtension.Substring(length, fileNameWithoutExtension.Length - length);
			LanguagePackInfo pack = HandleLanguagePack(basis + "_ui_language", File.ReadAllLines(Path.Combine(key, "ui_language.txt")));
			Dictionary<LanguageKey, string> dict = new Dictionary<LanguageKey, string>();
			foreach (LanguageKey crossKey in CrossLanguageKeys)
			{
				if (pack.PackedTexts.TryGetValue(crossKey.ToString(), out var text))
				{
					dict[crossKey] = text;
				}
			}
			CrossLanguageTexts[basis] = dict;
		}
	}

	private static void InitByLanguageFileKey(string languageFileKey)
	{
		_cachedUiTexts = null;
		List<LanguagePackInfo> cacheDataList = new List<LanguagePackInfo>();
		string dirRoot = Path.Combine(ExternalDataBridge.Context.DataPath, "StreamingAssets", "Language_" + languageFileKey);
		if (Directory.Exists(dirRoot))
		{
			string[] files = Directory.GetFiles(dirRoot, "*.txt", SearchOption.AllDirectories);
			string[][] languageAssets = files.ChangeArrType(File.ReadAllLines);
			string[] fileNames = files.ChangeArrType(Path.GetFileNameWithoutExtension);
			for (int i = 0; i < languageAssets.Length; i++)
			{
				string fileName = fileNames[i];
				string[] lines = languageAssets[i];
				LanguagePackInfo data = HandleLanguagePack(fileName, lines);
				cacheDataList.Add(data);
				if (fileName == "ui_language")
				{
					_cachedUiTexts = (from name in Enum.GetNames(typeof(LanguageKey))
						select data.PackedTexts.GetValueOrDefault(name, name)).ToArray();
				}
			}
		}
		_configLanguageMap = cacheDataList.ToDictionary((LanguagePackInfo e) => e.PackName);
		CnNumberConverterInit();
		CollectLanguages();
	}

	/// <summary>
	/// 用 LString 配置表的语言初始化
	/// </summary>
	public static void Init(LanguageType languageType)
	{
		InitByLanguageFileKey(languageType.ToString());
	}

	/// <summary>
	/// 用 LString 配置表的语言初始化
	/// </summary>
	public static void Init(string languageKey)
	{
		InitByLanguageFileKey(languageKey);
	}

	/// <summary>
	/// 处理一个语言包，后续支持多线程调用
	/// </summary>
	/// <param name="packName"></param>
	/// <param name="lines"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
	private static LanguagePackInfo HandleLanguagePack(string packName, string[] lines)
	{
		if (lines == null || lines.Length <= 0)
		{
			throw new Exception("can not handle null data for language pack " + packName);
		}
		LanguagePackInfo data = new LanguagePackInfo
		{
			PackName = packName,
			PackedTexts = new Dictionary<string, string>()
		};
		bool modeMap = false;
		for (int i = 0; i < lines.Length; i++)
		{
			string key = lines[i].Trim();
			if (modeMap)
			{
				int splitIndex = key.IndexOf('=');
				if (splitIndex >= 0)
				{
					string text = key;
					int num = splitIndex + 1;
					string value = text.Substring(num, text.Length - num);
					key = key.Substring(0, splitIndex);
					if (!data.MapLanguageData.TryAdd(key, value))
					{
						GiveWarningDuplicatedKey(key);
					}
				}
			}
			else if (ConfigArrayDicSeparator == key)
			{
				modeMap = true;
				data.MapLanguageData = new Dictionary<string, string>();
			}
			else
			{
				i++;
				if (i >= lines.Length)
				{
					break;
				}
				if (data.PackedTexts.ContainsKey(key))
				{
					GiveWarningDuplicatedKey(key);
				}
				data.PackedTexts[key] = lines[i].Replace("\\n", "\n").Trim();
			}
		}
		return data;
		void GiveWarningDuplicatedKey(string text2)
		{
			AdaptableLog.TagWarning("HandleLanguagePack", packName + " has duplicate language key: [" + text2 + "] this is not allowed!");
		}
	}

	/// <summary>
	/// 释放
	/// </summary>
	public static void Release()
	{
		_configLanguageMap.Clear();
		_configLanguageMap = null;
	}

	/// <summary>
	/// 获取语言配置，目前外部仅可在奇遇中调用
	/// </summary>
	public static string GetConfig(string packName, string key)
	{
		if (_configLanguageMap != null && _configLanguageMap.TryGetValue(packName, out var data) && data.PackedTexts.TryGetValue(key, out var text))
		{
			return text;
		}
		return key;
	}

	/// <summary>
	/// 获取语言配置
	/// </summary>
	[Obsolete("Config generator currently use GetConfig(string packName, string key) directly.")]
	public static string GetConfig(string packName, string segment, int index)
	{
		string key = $"{segment}_{index}";
		return GetConfig(packName, key);
	}

	/// <summary>
	/// 转换语言列表
	/// </summary>
	[Obsolete("Config generator currently use GetConfig(string packName, string key) directly.")]
	public static string[] GetConfigList(string packName, string segment, int index)
	{
		if (_configLanguageMap != null && _configLanguageMap.TryGetValue(packName, out var data))
		{
			List<string> ret = new List<string>();
			int i = 0;
			while (true)
			{
				string key = $"{segment}_{index}_{i}";
				if (!data.PackedTexts.TryGetValue(key, out var text))
				{
					break;
				}
				ret.Add(text);
				i++;
			}
			return ret.ToArray();
		}
		return Array.Empty<string>();
	}

	/// <summary>
	/// 转换语言列表
	/// </summary>
	[Obsolete("Config generator currently use GetConfig(string packName, string key) directly.")]
	public static string[] GetConfigList(string packName, string segment, int index, int forcedAmount)
	{
		string[] ret = new string[forcedAmount];
		if (_configLanguageMap != null && _configLanguageMap.TryGetValue(packName, out var data))
		{
			for (int i = 0; i < forcedAmount; i++)
			{
				string key = $"{segment}_{index}_{i}";
				ret[i] = (data.PackedTexts.TryGetValue(key, out var text) ? text : string.Empty);
			}
		}
		return ret;
	}

	/// <summary>
	/// 自校验
	/// </summary>
	public static bool SelfCheck()
	{
		return _cachedUiTexts.Length == Enum.GetValues(typeof(LanguageKey)).Length;
	}

	/// <summary>
	/// 获取可用语言集合
	/// </summary>
	public static IReadOnlyCollection<string> GetAvailableLanguages()
	{
		return CrossLanguageTexts.Keys;
	}

	/// <summary>
	/// 获得语言名
	/// </summary>
	public static string GetLanguageName(string language)
	{
		return GetCrossLanguage(LanguageKey.LK_SystemSetting_LocalizationSetting_Language_Self, language);
	}

	/// <summary>
	/// 获得跨语言文本
	/// </summary>
	public static string GetCrossLanguage(LanguageKey key, string language)
	{
		if (CrossLanguageTexts.TryGetValue(language, out var texts) && texts.TryGetValue(key, out var languageName))
		{
			return languageName;
		}
		return language;
	}

	/// <summary>
	/// 获取文本
	/// </summary>
	public static string Get(string key)
	{
		if (_customLanguageHandlerOfKey != null)
		{
			string result = _customLanguageHandlerOfKey(key);
			if (!string.IsNullOrEmpty(result))
			{
				return result;
			}
		}
		if (!Enum.TryParse<LanguageKey>(key, out var id))
		{
			return key;
		}
		return Get(id);
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(string key, object arg0)
	{
		return Get(key).GetFormat(arg0);
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(string key, object arg0, object arg1)
	{
		return Get(key).GetFormat(arg0, arg1);
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(string key, object arg0, object arg1, object arg2)
	{
		return Get(key).GetFormat(arg0, arg1, arg2);
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(string key, params object[] args)
	{
		return Get(key).GetFormat(args);
	}

	/// <summary>
	/// 获取文本
	/// </summary>
	public static string Get(LanguageKey id)
	{
		if (_customLanguageHandlerOfId == null)
		{
			if (!_cachedUiTexts.CheckIndex((int)id))
			{
				return $"{id} is not an available language id";
			}
			return _cachedUiTexts[(int)id];
		}
		string result = _customLanguageHandlerOfId((ushort)id);
		if (!string.IsNullOrEmpty(result))
		{
			return result;
		}
		if (!_cachedUiTexts.CheckIndex((int)id))
		{
			return $"{id} is not an available language id";
		}
		return _cachedUiTexts[(int)id];
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(LanguageKey id, object arg0)
	{
		return Get(id).GetFormat(arg0);
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(LanguageKey id, object arg0, object arg1)
	{
		return Get(id).GetFormat(arg0, arg1);
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(LanguageKey id, object arg0, object arg1, object arg2)
	{
		return Get(id).GetFormat(arg0, arg1, arg2);
	}

	/// <summary>
	/// 获取格式化文本
	/// </summary>
	public static string GetFormat(LanguageKey id, params object[] args)
	{
		return Get(id).GetFormat(args);
	}

	/// <summary>
	/// 获取本地化处理后的数字文本
	/// </summary>
	public static string GetLanguageNumber(long number)
	{
		if (CurLanguageType != LanguageType.CN)
		{
			return number.ToString();
		}
		return CnNumberConverter(number);
	}

	/// <summary>
	/// 对mod的语言包替换进行支持，把UI语言包进行替换
	/// </summary>
	public static void ReplaceStringPackForUI(string[] langArray)
	{
		if (langArray.Length != _cachedUiTexts.Length)
		{
			AdaptableLog.Warning("wrong replace language array for ui ...");
		}
		else
		{
			_cachedUiTexts = langArray;
		}
	}

	/// <summary>
	/// 注册一个自定义的多语言获取接口
	/// </summary>
	/// <param name="keyHandler"></param>
	/// <param name="idHandler"></param>
	public static void RegisterGetLanguageCustomHandler(Func<string, string> keyHandler, Func<ushort, string> idHandler)
	{
		if (keyHandler != null)
		{
			_customLanguageHandlerOfKey = (Func<string, string>)Delegate.Remove(_customLanguageHandlerOfKey, keyHandler);
			_customLanguageHandlerOfKey = (Func<string, string>)Delegate.Combine(_customLanguageHandlerOfKey, keyHandler);
		}
		if (idHandler != null)
		{
			_customLanguageHandlerOfId = (Func<ushort, string>)Delegate.Remove(_customLanguageHandlerOfId, idHandler);
			_customLanguageHandlerOfId = (Func<ushort, string>)Delegate.Combine(_customLanguageHandlerOfId, idHandler);
		}
	}

	/// <summary>
	/// 对mod的语言包替换进行支持，直接替换
	/// </summary>
	/// <returns></returns>
	public static string[] GetLocalUILanguageArray()
	{
		return _cachedUiTexts;
	}

	/// <summary>
	/// 对mod的配置表语言包进行支持，直接替换
	/// </summary>
	/// <returns></returns>
	public static Dictionary<string, LanguagePackInfo> GetConfigLanguageMap()
	{
		return _configLanguageMap;
	}

	/// <summary>
	/// 根据当前语言习惯拼接姓名
	/// </summary>
	/// <param name="surname"></param>
	/// <param name="givenName"></param>
	/// <returns></returns>
	public static string FormatFullName(string surname, string givenName)
	{
		if (CurLanguageType == LanguageType.EN)
		{
			if (!string.IsNullOrEmpty(surname))
			{
				return surname + " " + givenName;
			}
			return givenName;
		}
		return (surname ?? string.Empty) + givenName;
	}

	public static string FormatFullName((string surname, string givenName) name)
	{
		return FormatFullName(name.surname, name.givenName);
	}

	/// <summary>
	/// 根据当前语言习惯拼接促织名称
	/// </summary>
	/// <param name="first"></param>
	/// <param name="last"></param>
	/// <returns></returns>
	public static string FormatCricketName(string first, string last)
	{
		if (CurLanguageType == LanguageType.EN)
		{
			return first + " " + last;
		}
		return first + last;
	}
}
