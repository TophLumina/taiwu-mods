using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class TianCanShiGu : AssistSkillBase
{
	private const short EffectRequireFrame = 300;

	private const short ChangeNeiliAllocationValue = 3;

	private bool _isCurrCombatChar;

	private DataUid _eatingItemsUid;

	private readonly Dictionary<short, int> _wugFrameDict = new Dictionary<short, int>();

	public TianCanShiGu()
	{
	}

	public TianCanShiGu(CombatSkillKey skillKey)
		: base(skillKey, 12806)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_eatingItemsUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		if (_isCurrCombatChar)
		{
			Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnCombatBegin(DataContext context)
	{
		_isCurrCombatChar = DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar);
		if (_isCurrCombatChar)
		{
			Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
		_eatingItemsUid = new DataUid(4, 0, (ulong)(base.IsDirect ? base.CurrEnemyChar.GetId() : base.CharacterId), 58u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_eatingItemsUid, base.DataHandlerKey, OnUpdateEatingItems);
		OnUpdateEatingItems(context, default(DataUid));
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly == base.CombatChar.IsAlly)
		{
			bool isCurrChar = DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar);
			if (_isCurrCombatChar != isCurrChar)
			{
				_isCurrCombatChar = isCurrChar;
				if (isCurrChar)
				{
					Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
				}
				else
				{
					Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
				}
			}
		}
		else if (base.IsDirect)
		{
			UpdateEnemyUid(context);
		}
	}

	private unsafe void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		bool affected = false;
		foreach (short key in _wugFrameDict.Keys)
		{
			int frame = _wugFrameDict[key] + 1;
			if (frame >= 300)
			{
				frame = 0;
				if (base.CanAffect)
				{
					CombatCharacter affectChar = (base.IsDirect ? DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly) : base.CombatChar);
					if (base.IsDirect)
					{
						NeiliAllocation neiliAllocation = affectChar.GetNeiliAllocation();
						List<byte> typeRandomPool = ObjectPool<List<byte>>.Instance.Get();
						typeRandomPool.Clear();
						for (byte type = 0; type < 4; type++)
						{
							if (neiliAllocation.Items[(int)type] > 0)
							{
								typeRandomPool.Add(type);
							}
						}
						if (typeRandomPool.Count > 0)
						{
							affectChar.ChangeNeiliAllocation(context, typeRandomPool[context.Random.Next(0, typeRandomPool.Count)], -3);
							affected = true;
						}
						ObjectPool<List<byte>>.Instance.Return(typeRandomPool);
					}
					else
					{
						affectChar.ChangeNeiliAllocation(context, (byte)context.Random.Next(0, 4), 3);
						affected = true;
					}
				}
			}
			_wugFrameDict[key] = frame;
		}
		if (affected)
		{
			ShowEffectTips(context);
			ShowSpecialEffectTips(0);
		}
	}

	private unsafe void OnUpdateEatingItems(DataContext context, DataUid dataUid)
	{
		GameData.Domains.Character.Character affectChar = (base.IsDirect ? DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetCharacter() : CharObj);
		EatingItems eatingItems = affectChar.GetEatingItems();
		List<short> wugList = ObjectPool<List<short>>.Instance.Get();
		List<short> removeList = ObjectPool<List<short>>.Instance.Get();
		wugList.Clear();
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (EatingItems.IsWug(itemKey))
			{
				wugList.Add(itemKey.TemplateId);
			}
		}
		removeList.Clear();
		removeList.AddRange(_wugFrameDict.Keys);
		removeList.RemoveAll((short id) => wugList.Contains(id));
		for (int i2 = 0; i2 < removeList.Count; i2++)
		{
			_wugFrameDict.Remove(removeList[i2]);
		}
		for (int i3 = 0; i3 < wugList.Count; i3++)
		{
			short wugId = wugList[i3];
			if (!_wugFrameDict.ContainsKey(wugId))
			{
				_wugFrameDict.Add(wugId, 0);
			}
		}
		ObjectPool<List<short>>.Instance.Return(wugList);
		ObjectPool<List<short>>.Instance.Return(removeList);
	}

	private void UpdateEnemyUid(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_eatingItemsUid, base.DataHandlerKey);
		_eatingItemsUid = new DataUid(4, 0, (ulong)DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetId(), 58u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_eatingItemsUid, base.DataHandlerKey, OnUpdateEatingItems);
		_wugFrameDict.Clear();
		OnUpdateEatingItems(context, default(DataUid));
	}
}
