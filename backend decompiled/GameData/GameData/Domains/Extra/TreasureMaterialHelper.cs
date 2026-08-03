using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Map;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Extra;

internal class TreasureMaterialHelper
{
	private readonly Dictionary<sbyte, Dictionary<short, int>> _complexConfig = new Dictionary<sbyte, Dictionary<short, int>>();

	private readonly List<short> _templateCaches = new List<short>();

	private static bool IsValid(short templateId, int brokenLevel)
	{
		MiscItem config = Misc.Instance[templateId];
		return config.AllowBrokenLevels.Contains(brokenLevel);
	}

	private static bool IsValidExclusive(short templateId, int brokenLevel)
	{
		return IsValid(templateId, brokenLevel) && brokenLevel == Misc.Instance[templateId].AllowBrokenLevels.Min();
	}

	public TreasureMaterialHelper(EMiscGenerateType type)
	{
		if (type == EMiscGenerateType.Invalid)
		{
			return;
		}
		foreach (MiscItem misc in (IEnumerable<MiscItem>)Misc.Instance)
		{
			if (misc.GenerateType < type)
			{
				continue;
			}
			foreach (TreasureStateInfo info in misc.StateBuryAmount)
			{
				if (info.Amount > 0)
				{
					Dictionary<short, int> status = _complexConfig.GetOrNew(info.MapState);
					status[misc.TemplateId] = status.GetOrDefault(misc.TemplateId) + info.Amount;
				}
			}
		}
		foreach (Dictionary<short, int> status2 in _complexConfig.Values)
		{
			_templateCaches.Clear();
			foreach (var (templateId, amount) in status2)
			{
				if (amount <= 0)
				{
					_templateCaches.Add(templateId);
				}
			}
			foreach (short templateId2 in _templateCaches)
			{
				status2.Remove(templateId2);
			}
		}
	}

	public void RegenerateInState(sbyte stateId, IReadOnlyList<short> templateIds)
	{
		if (templateIds.Count == 0)
		{
			return;
		}
		AdaptableLog.Warning($"Regenerate {templateIds.Count} broken material in state {stateId}");
		Dictionary<short, int> status = _complexConfig.GetOrNew(stateId);
		foreach (short templateId in templateIds)
		{
			MiscItem config = Misc.Instance[templateId];
			if (config != null && config.GenerateType != EMiscGenerateType.Invalid)
			{
				status[templateId] = status.GetOrDefault(templateId) + 1;
			}
		}
	}

	private int CalcPreferPickAmount(sbyte stateId, int brokenLevel)
	{
		if (!_complexConfig.TryGetValue(stateId, out var status))
		{
			return 0;
		}
		int sum = 0;
		int minLevel = brokenLevel;
		foreach (var (templateId, amount) in status)
		{
			if (!IsValid(templateId, brokenLevel))
			{
				continue;
			}
			sum += amount;
			MiscItem config = Misc.Instance[templateId];
			foreach (int allowBrokenLevel in config.AllowBrokenLevels)
			{
				minLevel = Math.Min(minLevel, allowBrokenLevel);
			}
		}
		return sum / Math.Max(brokenLevel - minLevel + 1, 1);
	}

	private short PickInState(IRandomSource random, sbyte stateId, int brokenLevel)
	{
		if (!_complexConfig.TryGetValue(stateId, out var status))
		{
			return -1;
		}
		_templateCaches.Clear();
		foreach (var (templateId, amount) in status)
		{
			if (IsValid(templateId, brokenLevel) && amount > 0)
			{
				_templateCaches.Add(templateId);
			}
		}
		if (_templateCaches.Count == 0)
		{
			return -1;
		}
		short picked = _templateCaches.GetRandom(random);
		status[picked]--;
		if (status[picked] <= 0)
		{
			status.Remove(picked);
		}
		return picked;
	}

	private void PickInStateExclusive(IList<short> picked, sbyte stateId, int brokenLevel)
	{
		if (!_complexConfig.TryGetValue(stateId, out var status))
		{
			return;
		}
		List<short> removedKeys = ObjectPool<List<short>>.Instance.Get();
		foreach (var (templateId, amount) in status)
		{
			if (IsValidExclusive(templateId, brokenLevel))
			{
				for (int i = 0; i < amount; i++)
				{
					picked.Add(templateId);
				}
				removedKeys.Add(templateId);
			}
		}
		foreach (short templateId2 in removedKeys)
		{
			status.Remove(templateId2);
		}
		ObjectPool<List<short>>.Instance.Return(removedKeys);
	}

	public void PickAreaTemplates(IRandomSource random, IList<short> picked, short areaId)
	{
		if (picked == null)
		{
			throw new ArgumentNullException("picked");
		}
		MapDomain mapDomain = DomainManager.Map;
		int brokenLevel = mapDomain.QueryAreaBrokenLevel(areaId);
		sbyte stateId = mapDomain.GetStateTemplateIdByAreaId(areaId);
		int preferAmount = CalcPreferPickAmount(stateId, brokenLevel);
		PickInStateExclusive(picked, stateId, brokenLevel);
		for (int i = picked.Count; i < preferAmount; i++)
		{
			short templateId = PickInState(random, stateId, brokenLevel);
			if (templateId >= 0)
			{
				picked.Add(templateId);
			}
		}
	}
}
