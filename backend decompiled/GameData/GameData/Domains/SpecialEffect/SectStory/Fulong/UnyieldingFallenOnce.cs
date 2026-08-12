using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.SectStory.Fulong;

public class UnyieldingFallenOnce : AutoCollectEffectBase
{
	public UnyieldingFallenOnce(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(281, EDataModifyType.Custom, -1);
		Events.RegisterHandler_SectStoryUnyieldingFallenOnceInterrupt(OnSectStoryUnyieldingFallenOnceInterrupt);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_SectStoryUnyieldingFallenOnceInterrupt(OnSectStoryUnyieldingFallenOnceInterrupt);
		base.OnDisable(context);
	}

	private void OnSectStoryUnyieldingFallenOnceInterrupt(DataContext context, int charId)
	{
		if (charId == base.CharacterId)
		{
			DomainManager.SpecialEffect.Remove(context, Id);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 281)
		{
			return true;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
