using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class GuiGuXueHaiTang : CombatSkillEffectBase
{
	private const sbyte DirectAddPowerUnit = 20;

	private const sbyte ReverseAddPowerUnit = 40;

	private const int DirectPoisonResistAddPercent = -50;

	private List<DataUid> _allCharMarkUid;

	public GuiGuXueHaiTang()
	{
	}

	public GuiGuXueHaiTang(CombatSkillKey skillKey)
		: base(skillKey, 10408, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		if (_allCharMarkUid == null)
		{
			return;
		}
		foreach (DataUid dataUid in _allCharMarkUid)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(dataUid, base.DataHandlerKey);
		}
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedAllCombatCharData(context, 199, EDataModifyType.AddPercent, -1);
		if (base.IsDirect)
		{
			AppendAffectedAllCombatCharData(context, 245, EDataModifyType.AddPercent, -1);
		}
		else
		{
			AppendAffectedData(context, base.CharacterId, 162, EDataModifyType.Custom, -1);
		}
		_allCharMarkUid = new List<DataUid>();
		List<int> allCharList = ObjectPool<List<int>>.Instance.Get();
		allCharList.Clear();
		DomainManager.Combat.GetAllCharInCombat(allCharList);
		for (int i = 0; i < allCharList.Count; i++)
		{
			DataUid markUid = new DataUid(8, 10, (ulong)allCharList[i], 50u);
			_allCharMarkUid.Add(markUid);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(markUid, base.DataHandlerKey, OnMarkChanged);
		}
		ObjectPool<List<int>>.Instance.Return(allCharList);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (interrupted)
		{
			return;
		}
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			if (base.EffectCount != base.MaxEffectCount)
			{
				if (base.EffectCount > 0)
				{
					DomainManager.Combat.ChangeSkillEffectToMaxCount(context, base.CombatChar, base.EffectKey);
				}
				else
				{
					AddMaxEffectCount();
				}
			}
			if (base.IsDirect)
			{
				InvalidateAllEnemyCache(context, 245);
			}
		}
		if (Config.CombatSkill.Instance[skillId].EquipType != 1)
		{
			return;
		}
		CombatCharacter affectChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
		if (!(base.IsDirect ? (affectChar.IsAlly == base.CombatChar.IsAlly) : (affectChar.GetId() != base.CharacterId)) && affectChar.GetDefeatMarkCollection().PoisonMarkList.Exist((byte count) => count > 0) && base.EffectCount > 0)
		{
			affectChar.AddDieMark(context, SkillKey, 1);
			ShowSpecialEffectTips(0);
			ReduceEffectCount();
			if (affectChar.GetDefeatMarkCollection().DieMarkList.Count == GameData.Domains.Combat.SharedConstValue.DefeatNeedDieMarkCount && !affectChar.CheckHealthImmunity(context))
			{
				GameData.Domains.Character.Character character = affectChar.GetCharacter();
				DomainManager.SpecialEffect.AddAddMaxHealthEffect(context, character.GetId(), -character.GetLeftMaxHealth());
				character.ChangeHealth(context, 0);
			}
		}
	}

	private void OnMarkChanged(DataContext context, DataUid dataUid)
	{
		InvalidateCache(context, (int)dataUid.SubId0, 199);
		InvalidateCache(context, (int)dataUid.SubId0, 232);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId && dataKey.FieldId == 245 && base.EffectCount > 0)
		{
			return -50;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int num = ((fieldId == 199) ? (base.IsDirect ? 20 : 40) : 0);
		if (1 == 0)
		{
		}
		int unit = num;
		if (unit == 0)
		{
			return 0;
		}
		DefeatMarkCollection markCollection = DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CharId).GetDefeatMarkCollection();
		return unit * markCollection.DieMarkList.Count((CombatSkillKey t) => t.Equals(SkillKey));
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 162 && base.EffectCount > 0)
		{
			ShowSpecialEffectTipsOnceInFrame(1);
			return false;
		}
		return dataValue;
	}
}
