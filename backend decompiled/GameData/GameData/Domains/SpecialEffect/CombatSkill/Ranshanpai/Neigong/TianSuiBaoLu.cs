using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class TianSuiBaoLu : CombatSkillEffectBase
{
	private static readonly short[] DirectWords = new short[5] { 254, 255, 256, 257, 258 };

	private static readonly short[] ReverseWords = new short[5] { 259, 260, 261, 262, 263 };

	private const int RemoveTrickCount = 6;

	private const int WordCount = 3;

	private List<ItemKeyAndCount> _wordItemKeys = new List<ItemKeyAndCount>();

	public TianSuiBaoLu()
	{
	}

	public TianSuiBaoLu(CombatSkillKey skillKey)
		: base(skillKey, 7008, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_UsedCustomItem(OnUsedCustomItem);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_UsedCustomItem(OnUsedCustomItem);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (_wordItemKeys == null)
		{
			_wordItemKeys = new List<ItemKeyAndCount>();
		}
		_wordItemKeys.Clear();
		short[] wordTemplateIds = (base.IsDirect ? DirectWords : ReverseWords);
		short[] array = wordTemplateIds;
		foreach (short templateId in array)
		{
			_wordItemKeys.Add((itemKey: DomainManager.Item.CreateMisc(context, templateId), count: 3));
		}
		AppendAffectedData(context, 323, EDataModifyType.Custom, -1);
		ShowSpecialEffectTips(0);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowTianSuiBaoLu, base.IsDirect, base.CharacterId);
	}

	private void OnUsedCustomItem(DataContext context, int charId, ItemKey itemKey)
	{
		if (charId != base.CharacterId || itemKey.ItemType != 12)
		{
			return;
		}
		int index = _wordItemKeys.FindIndex((ItemKeyAndCount x) => x.ItemKey == itemKey);
		if (index >= 0)
		{
			_wordItemKeys[index] = (itemKey: _wordItemKeys[index].ItemKey, count: _wordItemKeys[index].Count - 1);
			if (_wordItemKeys[index].Count <= 0)
			{
				DomainManager.Item.RemoveItem(context, itemKey);
				_wordItemKeys.RemoveAt(index);
			}
			InvalidateCache(context, 323);
			short templateId = itemKey.TemplateId;
			if ((templateId == 254 || templateId == 259) ? true : false)
			{
				DoAffectShenJian(context);
				return;
			}
			if ((templateId == 255 || templateId == 260) ? true : false)
			{
				DoAffectHuanShe(context);
				return;
			}
			if ((templateId == 256 || templateId == 261) ? true : false)
			{
				DoAffectFuCang(context);
				return;
			}
			if ((templateId == 257 || templateId == 262) ? true : false)
			{
				DoAffectYinShen(context);
				return;
			}
			if ((templateId == 258 || templateId == 263) ? true : false)
			{
				DoAffectQuLiuWu(context);
				return;
			}
			AdaptableLog.Warning($"Unexpected template id {templateId}");
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		foreach (var (itemKey2, _) in _wordItemKeys)
		{
			DomainManager.Item.RemoveItem(context, itemKey2);
		}
		_wordItemKeys.Clear();
	}

	private void DoAffectShenJian(DataContext context)
	{
		ShowSpecialEffectTips(1);
		if (base.IsDirect)
		{
			DomainManager.Combat.AddTrick(context, base.CombatChar, base.CombatChar.GetWeaponTricks());
			return;
		}
		CombatCharacter enemyChar = base.EnemyChar;
		List<sbyte> usableTricks = ObjectPool<List<sbyte>>.Instance.Get();
		usableTricks.AddRange(enemyChar.GetTricks().Tricks.Values.Where(enemyChar.IsTrickUsable));
		foreach (sbyte trickType in RandomUtils.GetRandomUnrepeated(context.Random, 6, usableTricks))
		{
			DomainManager.Combat.RemoveTrick(context, enemyChar, trickType, 1, removedByAlly: false);
		}
		ObjectPool<List<sbyte>>.Instance.Return(usableTricks);
	}

	private void DoAffectHuanShe(DataContext context)
	{
		ShowSpecialEffectTips(2);
		if (base.IsDirect)
		{
			ChangeBreathValue(context, base.CombatChar, base.CombatChar.GetMaxBreathValue());
			ChangeStanceValue(context, base.CombatChar, base.CombatChar.GetMaxStanceValue());
		}
		else
		{
			CombatCharacter enemyChar = base.EnemyChar;
			ChangeBreathValue(context, enemyChar, -enemyChar.GetMaxBreathValue());
			ChangeStanceValue(context, enemyChar, -enemyChar.GetMaxStanceValue());
		}
	}

	private void DoAffectFuCang(DataContext context)
	{
		ShowSpecialEffectTips(3);
		if (base.IsDirect)
		{
			ChangeMobilityValue(context, base.CombatChar, base.CombatChar.GetMaxMobility());
		}
		else
		{
			ChangeMobilityValue(context, base.EnemyChar, -base.EnemyChar.GetMaxMobility());
		}
	}

	private void DoAffectYinShen(DataContext context)
	{
		ShowSpecialEffectTips(4);
		CombatCharacter target = (base.IsDirect ? base.CombatChar : base.EnemyChar);
		NeiliAllocation neiliAllocation = target.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = target.GetOriginNeiliAllocation();
		for (byte i = 0; i < 4; i++)
		{
			short value = neiliAllocation[i];
			short originValue = originNeiliAllocation[i];
			if (!(base.IsDirect ? (value >= originValue) : (value <= originValue)))
			{
				int delta = (base.IsDirect ? value : (-(value * CValueHalf.RoundDown)));
				target.ChangeNeiliAllocation(context, i, delta, applySpecialEffect: false);
			}
		}
	}

	private void DoAffectQuLiuWu(DataContext context)
	{
		ShowSpecialEffectTips(5);
		CombatCharacter target = (base.IsDirect ? base.CombatChar : base.EnemyChar);
		foreach (short bannedSkillId in target.GetBannedSkillIds(requireNotInfinity: true))
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.ClearSkillCd(context, target, bannedSkillId);
			}
			else
			{
				DomainManager.Combat.DoubleSkillCd(context, target, bannedSkillId);
			}
		}
	}

	public override List<ItemKeyAndCount> GetModifiedValue(AffectedDataKey dataKey, List<ItemKeyAndCount> dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 323)
		{
			foreach (ItemKeyAndCount itemKey in _wordItemKeys)
			{
				dataValue.Add(itemKey);
			}
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
