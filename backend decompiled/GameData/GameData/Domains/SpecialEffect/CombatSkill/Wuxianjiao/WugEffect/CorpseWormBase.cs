using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class CorpseWormBase : WugEffectBase
{
	private const int ChangeDamagePercent = 40;

	private const int GrowRequireHealthPercent = 50;

	private const sbyte GrownInfectCount = 5;

	private const int HealthDeltaValue = -60;

	private bool _affected;

	private bool _affectedOnMonthChange;

	private int HealthPercent => CValuePercent.ParseInt(CharObj.GetHealth(), CharObj.GetLeftMaxHealth());

	private CValuePercentBonus FatalDamageBonus => (HealthPercent >= 50) ? (base.IsGood ? (-25) : 25) : 0;

	protected CorpseWormBase()
	{
	}

	protected CorpseWormBase(int charId, int type, short wugTemplateId, short effectId)
		: base(charId, type, wugTemplateId, effectId)
	{
		CostWugCount = 12;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (AffectDatas == null)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		}
		if (base.IsGrown)
		{
			CreateAffectedData(262, EDataModifyType.Add, -1);
			CreateAffectedData(294, EDataModifyType.Custom, -1);
			Events.RegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
		else
		{
			CreateAffectedData(293, EDataModifyType.Custom, -1);
		}
		if (base.CanChangeToGrown)
		{
			Events.RegisterHandler_PostAdvanceMonthBegin(OnAdvanceMonthBegin);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.IsGrown)
		{
			Events.UnRegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
		if (base.CanChangeToGrown)
		{
			Events.UnRegisterHandler_PostAdvanceMonthBegin(OnAdvanceMonthBegin);
		}
	}

	protected override void AddAffectDataAndEvent(DataContext context)
	{
		_affected = false;
		AppendAffectedData(context, base.CharacterId, 102, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	protected override void ClearAffectDataAndEvent(DataContext context)
	{
		RemoveAffectedData(context, base.CharacterId, 102);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnAdvanceMonthBegin(DataContext context)
	{
		if (base.CanAffect)
		{
			short health = CharObj.GetHealth();
			short maxHealth = CharObj.GetLeftMaxHealth();
			if (health <= maxHealth * 50 / 100)
			{
				ChangeToGrown(context);
			}
		}
	}

	private void OnAdvanceMonthFinish(DataContext context)
	{
		if (_affectedOnMonthChange)
		{
			_affectedOnMonthChange = false;
			LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
			AddLifeRecord(lifeRecord.AddWugCorpseWormChangeHealth);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.DefenderId == base.CharacterId && index >= 3 && _affected)
		{
			_affected = false;
			ShowEffectTips(context, 1);
			CostWugInCombat(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 262)
		{
			_affectedOnMonthChange = true;
			return -60;
		}
		if (dataKey.FieldId == 102 && !dataKey.IsNormalAttack)
		{
			_affected = true;
			return base.IsGood ? (-40) : 40;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 294 || !base.IsElite || !base.CanAffect)
		{
			return dataValue;
		}
		return false;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 293 || !base.CanAffect || !base.IsElite)
		{
			return dataValue;
		}
		if (base.CombatChar.CheckHealthImmunity(base.CombatChar.GetDataContext()))
		{
			return dataValue;
		}
		int modifiedValue = dataValue * FatalDamageBonus;
		int fatalDamageStep = base.CombatChar.GetDamageStepCollection().FatalDamageStep;
		int changeValue = Math.Abs(dataValue - modifiedValue);
		int changeHealth = GlobalConfig.Instance.ReduceHealthPerFatalDamageMark[2] * changeValue / Math.Max(fatalDamageStep, 1);
		if (changeValue > 0)
		{
			ShowEffectTips(DomainManager.Combat.Context, 2);
		}
		if (changeHealth > 0)
		{
			CharObj.ChangeHealth(DomainManager.Combat.Context, -changeHealth);
			ShowEffectTips(base.CombatChar.GetDataContext(), 3);
		}
		return modifiedValue;
	}

	protected override void ChangeToGrown(DataContext context)
	{
		List<int> charRandomPool = ObjectPool<List<int>>.Instance.Get();
		Location location = CharObj.GetLocation();
		if (!location.IsValid())
		{
			location = CharObj.GetValidLocation();
		}
		HashSet<int> blockCharSet = DomainManager.Map.GetBlock(location).CharacterSet;
		charRandomPool.Clear();
		if (blockCharSet != null)
		{
			charRandomPool.AddRange(blockCharSet);
		}
		charRandomPool.Remove(base.CharacterId);
		if (DomainManager.Taiwu.GetTaiwuCharId() == base.CharacterId)
		{
			charRandomPool.AddRange(DomainManager.Taiwu.GetGroupCharIds().GetCollection());
			charRandomPool.Remove(base.CharacterId);
		}
		int infectCharCount = Math.Min(5, charRandomPool.Count);
		CharObj.SetHealth(0, context);
		CharObj.RemoveWug(context, WugConfig.TemplateId);
		LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
		for (int i = 0; i < infectCharCount; i++)
		{
			int index = context.Random.Next(0, charRandomPool.Count);
			short grownTemplateId = ItemDomain.GetWugTemplateId(WugConfig.WugType, 4);
			DomainManager.Character.GetElement_Objects(charRandomPool[index]).AddWug(context, grownTemplateId, -1);
			AddLifeRecord(lifeRecord.AddWugCorpseWormChangeToGrown, charRandomPool[index], grownTemplateId);
			charRandomPool.RemoveAt(index);
		}
		ObjectPool<List<int>>.Instance.Return(charRandomPool);
	}
}
