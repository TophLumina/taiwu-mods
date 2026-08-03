using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class EnhancedRichTextTags : IEnumerable<EnhancedRichTextTagsItem>, IEnumerable, IConfigData
{
	public static class DefKey
	{
		public const short ENHANCED = 0;

		public const short OL = 1;

		public const short UL = 2;

		public const short LI = 3;

		public const short TABLE = 4;

		public const short TR = 5;

		public const short TD = 6;

		public const short BR = 7;

		public const short SP = 8;

		public const short H1 = 9;

		public const short H2 = 10;

		public const short H3 = 11;

		public const short H4 = 12;

		public const short P = 13;

		public const short CONFIG = 14;

		public const short T = 15;

		public const short S = 16;
	}

	public static EnhancedRichTextTags Instance = new EnhancedRichTextTags();

	private readonly Dictionary<string, int> _refNameMap = new Dictionary<string, int>();

	private List<EnhancedRichTextTagsItem> _dataArray;

	private readonly Dictionary<int, EnhancedRichTextTagsItem> _extraDataMap = new Dictionary<int, EnhancedRichTextTagsItem>();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Name", "OpenTagReplacement", "CloseTagReplacement" };

	public IReadOnlyDictionary<string, int> RefNameMap => _refNameMap;

	public EnhancedRichTextTagsItem this[short id] => GetItem(id);

	public EnhancedRichTextTagsItem this[int id] => GetItem((short)id);

	public EnhancedRichTextTagsItem this[string refName] => this[_refNameMap[refName]];

	public int Count => _dataArray.Count;

	public int CountWithExtra => Count + _extraDataMap.Count;

	private void CreateItems0()
	{
		_dataArray.Add(new EnhancedRichTextTagsItem(0, "enhanced", arg2: true, arg3: true, null, null, 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(1, "ol", arg2: true, arg3: true, "<margin=1em>", "</margin>", 1, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(2, "ul", arg2: true, arg3: true, "<margin=1em>", "</margin>", 1, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(3, "li", arg2: true, arg3: true, "{0}<indent=2em><line-height=100%>", "</indent><line-height=140%>", 0, 1));
		_dataArray.Add(new EnhancedRichTextTagsItem(4, "table", arg2: true, arg3: true, null, null, 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(5, "tr", arg2: true, arg3: true, null, null, 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(6, "td", arg2: true, arg3: true, null, null, 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(7, "br", arg2: false, arg3: false, "\\n", null, 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(8, "sp", arg2: false, arg3: false, null, null, 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(9, "h1", arg2: true, arg3: false, "<color=#red><size=170%><b>", "</b></size></color>", 0, 3));
		_dataArray.Add(new EnhancedRichTextTagsItem(10, "h2", arg2: true, arg3: false, "<margin=0.5em><color=#goldyellow><size=145%><b>", "</b></size></color></margin><line-height=160%>", 2, 1));
		_dataArray.Add(new EnhancedRichTextTagsItem(11, "h3", arg2: true, arg3: false, "<margin=1em><color=#orange><size=130%><b>", "</b></size></color></margin><line-height=160%>", 2, 1));
		_dataArray.Add(new EnhancedRichTextTagsItem(12, "h4", arg2: true, arg3: false, "<margin=1.7em><color=#lightgrey><size=116%><b>", "</b></size></color></margin><line-height=140%>", 2, 1));
		_dataArray.Add(new EnhancedRichTextTagsItem(13, "p", arg2: true, arg3: false, "<margin=2.2em><line-height=104%>", "</margin><line-height=144%>", 0, 1));
		_dataArray.Add(new EnhancedRichTextTagsItem(14, "config", arg2: false, arg3: true, null, null, 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(15, "t", arg2: true, arg3: false, "<color=#lightwhite><b>", "</b></color>", 0, 0));
		_dataArray.Add(new EnhancedRichTextTagsItem(16, "s", arg2: true, arg3: false, "<size=80%><color=#lightgrey><s>", "</s></color></size>", 0, 0));
	}

	public void Init()
	{
		_refNameMap.Clear();
		_refNameMap.Load("EnhancedRichTextTags");
		_extraDataMap.Clear();
		_dataArray = new List<EnhancedRichTextTagsItem>(17);
		CreateItems0();
	}

	public int GetItemId(string refName)
	{
		if (_refNameMap.TryGetValue(refName, out var id))
		{
			return id;
		}
		throw new Exception(refName + " not found.");
	}

	public int AddExtraItem(string identifier, string refName, object configItem)
	{
		EnhancedRichTextTagsItem item = (EnhancedRichTextTagsItem)configItem;
		int id = item.TemplateId;
		if (id < _dataArray.Count)
		{
			throw new Exception($"EnhancedRichTextTags template id {item.TemplateId} created by {identifier} already exist.");
		}
		if (_extraDataMap.ContainsKey(id))
		{
			throw new Exception($"EnhancedRichTextTags extra template id {item.TemplateId} created by {identifier} already exist.");
		}
		if (_refNameMap.TryGetValue(refName, out var refId))
		{
			throw new Exception($"EnhancedRichTextTags template reference name {refName}(id = {item.TemplateId}) created by {identifier} already exist with templateId {refId}).");
		}
		_refNameMap.Add(refName, id);
		_extraDataMap.Add(id, item);
		return id;
	}

	public EnhancedRichTextTagsItem GetItem(short id)
	{
		if (id < 0)
		{
			return null;
		}
		if (id < _dataArray.Count)
		{
			return _dataArray[id];
		}
		if (_extraDataMap.TryGetValue(id, out var item))
		{
			return item;
		}
		AdaptableLog.TagWarning(GetType().FullName, $"index {id} is not in range [0, {_dataArray.Count}) and is not defined in _extraDataMap (count: {_extraDataMap.Count})");
		return null;
	}

	public List<short> GetAllKeys()
	{
		List<short> list = new List<short>();
		list.AddRange(from item in _dataArray
			where item != null
			select item.TemplateId);
		list.AddRange(from item in _extraDataMap.Values
			where item != null
			select item.TemplateId);
		return list;
	}

	public void Iterate(Func<EnhancedRichTextTagsItem, bool> iterateFunc)
	{
		if (iterateFunc == null)
		{
			return;
		}
		foreach (EnhancedRichTextTagsItem item in _dataArray)
		{
			if (item != null && !iterateFunc(item))
			{
				break;
			}
		}
		foreach (EnhancedRichTextTagsItem item2 in _extraDataMap.Values)
		{
			if (item2 != null && !iterateFunc(item2))
			{
				break;
			}
		}
	}

	IEnumerator<EnhancedRichTextTagsItem> IEnumerable<EnhancedRichTextTagsItem>.GetEnumerator()
	{
		foreach (EnhancedRichTextTagsItem item in _dataArray)
		{
			yield return item;
		}
		foreach (EnhancedRichTextTagsItem value in _extraDataMap.Values)
		{
			yield return value;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		foreach (EnhancedRichTextTagsItem item in _dataArray)
		{
			yield return item;
		}
		foreach (EnhancedRichTextTagsItem value in _extraDataMap.Values)
		{
			yield return value;
		}
	}
}
