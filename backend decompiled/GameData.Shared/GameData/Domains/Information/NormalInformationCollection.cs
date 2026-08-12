using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information;

/// <summary>
/// 一般见闻集合
/// 通常用于角色所持见闻信息
/// </summary>
public class NormalInformationCollection : ISerializableGameData
{
	/// <summary>
	/// 被传播见闻次数记录
	/// 一般用于技艺见闻
	/// <para>
	/// 负数索引储存的是：
	/// 1. UsedCountWithMax 为 true 的情况，储存的是已使用的次数
	/// 2. UsedCountWithMax 为 false 的情况，储存的是剩余数量的相反数(为了兼容旧存档而如此)
	/// </para>
	/// </summary>
	public readonly IDictionary<short, sbyte> ReceivedCounts = new Dictionary<short, sbyte>();

	/// <summary>
	/// 见闻列表
	/// </summary>
	private IList<NormalInformation> _elements;

	/// <summary>
	/// 获取列表
	/// 不存在的时候将会创建一个
	/// </summary>
	public IList<NormalInformation> GetList()
	{
		if (_elements == null)
		{
			return _elements = new List<NormalInformation>();
		}
		return _elements;
	}

	/// <summary>
	/// 使用次数的索引
	/// 为负值
	/// </summary>
	private short _GetUsedCountIndex(NormalInformation normalInformation)
	{
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		if (config != null)
		{
			return (short)(-(config.InfoIds[normalInformation.Level] + 1));
		}
		return short.MinValue;
	}

	/// <summary>
	/// 获得使用次数上限
	/// </summary>
	public sbyte GetUsedCountMax(NormalInformation normalInformation)
	{
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		if (config != null && !config.UsedCountWithMax)
		{
			return GetRemainUsableCount(normalInformation);
		}
		return (sbyte)GlobalConfig.Instance.NormalInformationDefaultCostableMaxUseCount;
	}

	/// <summary>
	/// 获得使用次数
	/// </summary>
	public sbyte GetUsedCount(NormalInformation normalInformation)
	{
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		if (config != null && config.UsedCountWithMax)
		{
			short key = _GetUsedCountIndex(normalInformation);
			if (ReceivedCounts.TryGetValue(key, out var count) && count > 0)
			{
				return count;
			}
			return 0;
		}
		return 0;
	}

	/// <summary>
	/// 设置使用次数
	/// </summary>
	public sbyte SetUsedCount(NormalInformation normalInformation, sbyte count)
	{
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		short key = _GetUsedCountIndex(normalInformation);
		if (config != null && config.UsedCountWithMax)
		{
			ReceivedCounts[key] = count;
			return count;
		}
		sbyte remainCount = GetUsedCountMax(normalInformation);
		remainCount -= count;
		SetRemainUsableCount(normalInformation, remainCount);
		return 0;
	}

	/// <summary>
	/// 获取剩余使用次数
	/// <para>仅适用于 UsedCountWithMax 为 false 的见闻</para>
	/// </summary>
	public sbyte GetRemainUsableCount(NormalInformation normalInformation)
	{
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		Tester.Assert(config != null && !config.UsedCountWithMax);
		short key = _GetUsedCountIndex(normalInformation);
		if (ReceivedCounts.TryGetValue(key, out var count))
		{
			if (count <= 0)
			{
				return (sbyte)(-count);
			}
			return (sbyte)(3 - count);
		}
		return (sbyte)GlobalConfig.Instance.NormalInformationDefaultCostableMaxUseCount;
	}

	/// <summary>
	/// 设置剩余使用次数
	/// <para>仅适用于 UsedCountWithMax 为 false 的见闻</para>
	/// </summary>
	public sbyte SetRemainUsableCount(NormalInformation normalInformation, sbyte remainCount)
	{
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		Tester.Assert(config != null && !config.UsedCountWithMax);
		short key = _GetUsedCountIndex(normalInformation);
		remainCount = Math.Clamp(remainCount, 0, (sbyte)GlobalConfig.Instance.NormalInformationMaxRemainCount);
		ReceivedCounts[key] = (sbyte)(-remainCount);
		return remainCount;
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		return 4 + ReceivedCounts.Count * 3 + ((_elements == null) ? 4 : (4 + _elements.Sum((NormalInformation element) => element.GetSerializedSize())));
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = ReceivedCounts.Count;
		pCurrData += 4;
		foreach (KeyValuePair<short, sbyte> pair in ReceivedCounts)
		{
			*(short*)pCurrData = pair.Key;
			pCurrData += 2;
			*pCurrData = (byte)pair.Value;
			pCurrData++;
		}
		if (_elements != null)
		{
			*(int*)pCurrData = _elements.Count;
			pCurrData += 4;
			foreach (NormalInformation element2 in _elements)
			{
				pCurrData += element2.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int count = *(int*)pCurrData;
		pCurrData += 4;
		ReceivedCounts.Clear();
		for (int i = 0; i < count; i++)
		{
			short key = *(short*)pCurrData;
			pCurrData += 2;
			sbyte value = (sbyte)(*pCurrData);
			pCurrData++;
			ReceivedCounts.Add(key, value);
		}
		int count2 = *(int*)pCurrData;
		pCurrData += 4;
		if (count2 > 0)
		{
			if (_elements == null)
			{
				_elements = new List<NormalInformation>();
			}
			else
			{
				_elements.Clear();
			}
			for (int j = 0; j < count2; j++)
			{
				NormalInformation element = default(NormalInformation);
				pCurrData += element.Deserialize(pCurrData);
				_elements.Add(element);
			}
		}
		else
		{
			_elements?.Clear();
		}
		return (int)(pCurrData - pData);
	}

	/// <summary>
	/// 清除使用次数信息
	/// </summary>
	public void ClearUsedCountData(NormalInformation normalInformation)
	{
		short key = _GetUsedCountIndex(normalInformation);
		ReceivedCounts.Remove(key);
	}
}
