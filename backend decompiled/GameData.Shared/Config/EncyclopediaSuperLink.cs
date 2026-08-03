using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class EncyclopediaSuperLink : IEnumerable<EncyclopediaSuperLinkItem>, IEnumerable, IConfigData
{
	public static class DefKey
	{
	}

	public static EncyclopediaSuperLink Instance = new EncyclopediaSuperLink();

	private readonly Dictionary<string, int> _refNameMap = new Dictionary<string, int>();

	private List<EncyclopediaSuperLinkItem> _dataArray;

	private readonly Dictionary<int, EncyclopediaSuperLinkItem> _extraDataMap = new Dictionary<int, EncyclopediaSuperLinkItem>();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "LinkId", "VolName", "PagePath", "TipType", "TipStringArgArray" };

	public IReadOnlyDictionary<string, int> RefNameMap => _refNameMap;

	public EncyclopediaSuperLinkItem this[short id] => GetItem(id);

	public EncyclopediaSuperLinkItem this[int id] => GetItem((short)id);

	public EncyclopediaSuperLinkItem this[string refName] => this[_refNameMap[refName]];

	public int Count => _dataArray.Count;

	public int CountWithExtra => Count + _extraDataMap.Count;

	private void CreateItems0()
	{
		_dataArray.Add(new EncyclopediaSuperLinkItem(0, "CharCharmLink", "MainSummaryInfo", "MainSummaryInfo/Charm", "Simple", new string[2] { "LK_Main_SummaryInfo_Charm", "LK_Main_SummaryInfo_Charm_Content_DX" }));
		_dataArray.Add(new EncyclopediaSuperLinkItem(1, "MainAttributeLink", "MainSummaryInfo", "MainSummaryInfo/MainAttributes", null, null));
		_dataArray.Add(new EncyclopediaSuperLinkItem(2, "CharNameLink", "MainSummaryInfo", "MainSummaryInfo/Name", "Simple", new string[2] { "LK_Char_Name", "LK_Main_SummaryInfo_Char_Name_TipContent" }));
		_dataArray.Add(new EncyclopediaSuperLinkItem(3, "CharTitleLink", "MainSummaryInfo", "MainSummaryInfo/Title", "Simple", new string[2] { "LK_Main_SummaryInfo_Title", "LK_Main_SummaryInfo_Title_TipContent" }));
		_dataArray.Add(new EncyclopediaSuperLinkItem(4, "CharGenderLink", "MainSummaryInfo", "MainSummaryInfo/Gender", "Simple", new string[2] { "LK_Main_SummaryInfo_Gender", "LK_Main_SummaryInfo_Gender_Content_DX" }));
		_dataArray.Add(new EncyclopediaSuperLinkItem(5, "CharAppearanceLink", "MainSummaryInfo", "MainSummaryInfo/Appearance", "Simple", new string[2] { "LK_Main_SummaryInfo_Appearance", "LK_Main_SummaryInfo_Appearance_Content_DX" }));
	}

	public void Init()
	{
		_refNameMap.Clear();
		_refNameMap.Load("EncyclopediaSuperLink");
		_extraDataMap.Clear();
		_dataArray = new List<EncyclopediaSuperLinkItem>(6);
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
		EncyclopediaSuperLinkItem item = (EncyclopediaSuperLinkItem)configItem;
		int id = item.TemplateId;
		if (id < _dataArray.Count)
		{
			throw new Exception($"EncyclopediaSuperLink template id {item.TemplateId} created by {identifier} already exist.");
		}
		if (_extraDataMap.ContainsKey(id))
		{
			throw new Exception($"EncyclopediaSuperLink extra template id {item.TemplateId} created by {identifier} already exist.");
		}
		if (_refNameMap.TryGetValue(refName, out var refId))
		{
			throw new Exception($"EncyclopediaSuperLink template reference name {refName}(id = {item.TemplateId}) created by {identifier} already exist with templateId {refId}).");
		}
		_refNameMap.Add(refName, id);
		_extraDataMap.Add(id, item);
		return id;
	}

	public EncyclopediaSuperLinkItem GetItem(short id)
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

	public void Iterate(Func<EncyclopediaSuperLinkItem, bool> iterateFunc)
	{
		if (iterateFunc == null)
		{
			return;
		}
		foreach (EncyclopediaSuperLinkItem item in _dataArray)
		{
			if (item != null && !iterateFunc(item))
			{
				break;
			}
		}
		foreach (EncyclopediaSuperLinkItem item2 in _extraDataMap.Values)
		{
			if (item2 != null && !iterateFunc(item2))
			{
				break;
			}
		}
	}

	IEnumerator<EncyclopediaSuperLinkItem> IEnumerable<EncyclopediaSuperLinkItem>.GetEnumerator()
	{
		foreach (EncyclopediaSuperLinkItem item in _dataArray)
		{
			yield return item;
		}
		foreach (EncyclopediaSuperLinkItem value in _extraDataMap.Values)
		{
			yield return value;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		foreach (EncyclopediaSuperLinkItem item in _dataArray)
		{
			yield return item;
		}
		foreach (EncyclopediaSuperLinkItem value in _extraDataMap.Values)
		{
			yield return value;
		}
	}
}
