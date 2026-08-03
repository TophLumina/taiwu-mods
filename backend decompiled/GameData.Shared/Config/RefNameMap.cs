using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using GameData;

namespace Config;

/// <summary>
/// 引用名映射表扩展功能
/// </summary>
public static class RefNameMap
{
	/// <summary>
	/// 引用名映射表加载请求
	/// </summary>
	private static readonly ConcurrentQueue<Action> RefNameMapLoadingRequests = new ConcurrentQueue<Action>();

	private const string RefNameMapFolderPath = "StreamingAssets/ConfigRefNameMapping";

	/// <summary>
	/// 加载指定的引用名映射表
	/// </summary>
	public static int Load(this Dictionary<string, int> refNameMap, string name)
	{
		RefNameMapLoadingRequests.Enqueue(delegate
		{
			string path = Path.Combine(ExternalDataBridge.Context.DataPath, "StreamingAssets/ConfigRefNameMapping", name + ".ref.txt");
			if (!File.Exists(path))
			{
				return;
			}
			using StringReader stringReader = new StringReader(File.ReadAllText(path));
			while (true)
			{
				string text = stringReader.ReadLine();
				if (string.IsNullOrEmpty(text))
				{
					break;
				}
				int value = int.Parse(stringReader.ReadLine() ?? string.Empty);
				refNameMap.TryAdd(text, value);
			}
		});
		return 0;
	}

	/// <summary>
	/// 执行加载请求
	/// </summary>
	public static void DoQueuedLoadRequests()
	{
		Action action;
		while (RefNameMapLoadingRequests.TryDequeue(out action))
		{
			action();
		}
	}
}
