using System;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

[SerializableGameData(IsExtensible = true)]
public class Jiao : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Key = 0;

		public const ushort Gender = 1;

		public const ushort TamePoint = 2;

		public const ushort NurturanceTemplateId = 3;

		public const ushort CanBreed = 4;

		public const ushort GrowthStage = 5;

		public const ushort EvolveRemainingMonth = 6;

		public const ushort Height = 7;

		public const ushort Weight = 8;

		public const ushort LifeSpan = 9;

		public const ushort NameId = 10;

		public const ushort Behavior = 11;

		public const ushort Properties = 12;

		public const ushort Id = 13;

		public const ushort MotherId = 14;

		public const ushort AggressiveTimes = 15;

		public const ushort NegativeTimes = 16;

		public const ushort TemplateId = 17;

		public const ushort FatherId = 18;

		public const ushort LastChoiceIsAggressive = 19;

		public const ushort LastEvolutionResult = 20;

		public const ushort RandomSeed = 21;

		public const ushort PettingCoolDown = 22;

		public const ushort Generation = 23;

		public const ushort NextPeriod = 24;

		public const ushort Count = 25;

		public static readonly string[] FieldId2FieldName = new string[25]
		{
			"Key", "Gender", "TamePoint", "NurturanceTemplateId", "CanBreed", "GrowthStage", "EvolveRemainingMonth", "Height", "Weight", "LifeSpan",
			"NameId", "Behavior", "Properties", "Id", "MotherId", "AggressiveTimes", "NegativeTimes", "TemplateId", "FatherId", "LastChoiceIsAggressive",
			"LastEvolutionResult", "RandomSeed", "PettingCoolDown", "Generation", "NextPeriod"
		};
	}

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public ItemKey Key;

	[SerializableGameDataField]
	public bool Gender;

	[SerializableGameDataField]
	public int TamePoint;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public short NurturanceTemplateId;

	[SerializableGameDataField]
	public bool CanBreed;

	[SerializableGameDataField]
	public sbyte GrowthStage;

	[SerializableGameDataField]
	public int EvolveRemainingMonth;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) Height;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) Weight;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) LifeSpan;

	[SerializableGameDataField]
	public int FatherId;

	[SerializableGameDataField]
	public int MotherId;

	[SerializableGameDataField]
	public int AggressiveTimes;

	[SerializableGameDataField]
	public int NegativeTimes;

	[SerializableGameDataField]
	public bool LastChoiceIsAggressive;

	[SerializableGameDataField]
	public short LastEvolutionResult;

	[SerializableGameDataField]
	public int RandomSeed;

	[SerializableGameDataField]
	public int PettingCoolDown;

	[SerializableGameDataField]
	public int Generation;

	[SerializableGameDataField]
	public int NextPeriod;

	[SerializableGameDataField]
	public int NameId;

	[SerializableGameDataField]
	public sbyte Behavior;

	[SerializableGameDataField]
	public JiaoProperty Properties;

	public Jiao()
	{
		Id = -1;
		Key = ItemKey.Invalid;
		Gender = false;
		TamePoint = -1;
		NurturanceTemplateId = -1;
		TemplateId = -1;
		CanBreed = false;
		GrowthStage = 0;
		EvolveRemainingMonth = 0;
		Height = (Inherited: 0, Fostered: 0);
		Weight = (Inherited: 0, Fostered: 0);
		LifeSpan = (Inherited: 0, Fostered: 0);
		NameId = -1;
		Behavior = -1;
		Properties = new JiaoProperty();
		FatherId = -1;
		MotherId = -1;
		AggressiveTimes = 0;
		NegativeTimes = 0;
		LastEvolutionResult = -1;
		RandomSeed = -1;
		PettingCoolDown = -1;
		Generation = 0;
		NextPeriod = -1;
	}

	public Jiao(ItemKey key, bool isMale, int tamePoint, short templateId, sbyte behavior)
	{
		Id = key.Id;
		Key = key;
		Gender = isMale;
		TamePoint = tamePoint;
		NurturanceTemplateId = -1;
		TemplateId = templateId;
		CanBreed = true;
		GrowthStage = 0;
		EvolveRemainingMonth = 0;
		Height = (Inherited: 0, Fostered: 0);
		Weight = (Inherited: 0, Fostered: 0);
		LifeSpan = (Inherited: 0, Fostered: 0);
		NameId = -1;
		Behavior = behavior;
		Properties = new JiaoProperty();
		FatherId = -1;
		MotherId = -1;
		AggressiveTimes = 0;
		NegativeTimes = 0;
		LastEvolutionResult = -1;
		RandomSeed = -1;
		PettingCoolDown = -1;
		Generation = 0;
		NextPeriod = -1;
	}

	public Jiao(ItemKey key, bool isMale, int tamePoint, short templateId, sbyte behavior, int fatherId, int motherId)
	{
		Id = key.Id;
		Key = key;
		Gender = isMale;
		TamePoint = tamePoint;
		NurturanceTemplateId = -1;
		TemplateId = templateId;
		CanBreed = true;
		GrowthStage = 0;
		EvolveRemainingMonth = 0;
		Height = (Inherited: 0, Fostered: 0);
		Weight = (Inherited: 0, Fostered: 0);
		LifeSpan = (Inherited: 0, Fostered: 0);
		NameId = -1;
		Behavior = behavior;
		Properties = new JiaoProperty();
		FatherId = fatherId;
		MotherId = motherId;
		AggressiveTimes = 0;
		NegativeTimes = 0;
		LastEvolutionResult = -1;
		RandomSeed = -1;
		PettingCoolDown = -1;
		Generation = 0;
		NextPeriod = -1;
	}

	public Jiao(Jiao jiao, ItemKey key)
	{
		Id = key.Id;
		Key = key;
		Gender = jiao.Gender;
		TamePoint = jiao.TamePoint;
		NurturanceTemplateId = jiao.NurturanceTemplateId;
		TemplateId = jiao.TemplateId;
		CanBreed = jiao.CanBreed;
		GrowthStage = jiao.GrowthStage;
		EvolveRemainingMonth = jiao.EvolveRemainingMonth;
		Height = jiao.Height;
		Weight = jiao.Weight;
		LifeSpan = jiao.LifeSpan;
		NameId = jiao.NameId;
		Behavior = jiao.Behavior;
		Properties = new JiaoProperty();
		Properties.DeepCopy(jiao.Properties);
		FatherId = jiao.FatherId;
		MotherId = jiao.MotherId;
		AggressiveTimes = jiao.AggressiveTimes;
		NegativeTimes = jiao.NegativeTimes;
		LastEvolutionResult = jiao.LastEvolutionResult;
		RandomSeed = jiao.RandomSeed;
		PettingCoolDown = jiao.PettingCoolDown;
		Generation = jiao.Generation;
		NextPeriod = jiao.NextPeriod;
	}

	public void ResetGrowth()
	{
		EvolveRemainingMonth = JiaoNurturance.Instance[NurturanceTemplateId].NurturanceCostMonth;
		NextPeriod = JiaoNurturance.Instance[NurturanceTemplateId].StageCostMonth;
		Properties.ResetGrowth();
		Height = (Inherited: Height.Inherited, Fostered: 0);
		Weight = (Inherited: Weight.Inherited, Fostered: 0);
		LifeSpan = (Inherited: LifeSpan.Inherited, Fostered: 0);
	}

	public string GetNameText()
	{
		return GetNameRelatedData().GetName();
	}

	public JiaoLoongNameRelatedData GetNameRelatedData()
	{
		return new JiaoLoongNameRelatedData
		{
			ItemType = Key.ItemType,
			ItemTemplateId = Key.TemplateId,
			NameId = NameId,
			CharTemplateId = (short)((GrowthStage == 0) ? (-1) : Config.Jiao.Instance[TemplateId].IndexOfCharacterTemplate)
		};
	}

	public int GetPresentProperty(short propertyTemplateId)
	{
		JiaoItem config = Config.Jiao.Instance[TemplateId];
		return propertyTemplateId switch
		{
			9 => config.Length + Height.Inherited + Height.Fostered / 100, 
			10 => config.Weight + Weight.Inherited + Weight.Fostered / 100, 
			11 => config.Life + LifeSpan.Inherited + LifeSpan.Fostered / 100, 
			_ => throw new Exception($"wrong property id: {propertyTemplateId}"), 
		};
	}

	public Jiao(Jiao other)
	{
		Key = other.Key;
		Gender = other.Gender;
		TamePoint = other.TamePoint;
		NurturanceTemplateId = other.NurturanceTemplateId;
		CanBreed = other.CanBreed;
		GrowthStage = other.GrowthStage;
		EvolveRemainingMonth = other.EvolveRemainingMonth;
		Height = other.Height;
		Weight = other.Weight;
		LifeSpan = other.LifeSpan;
		NameId = other.NameId;
		Behavior = other.Behavior;
		Properties = new JiaoProperty(other.Properties);
		Id = other.Id;
		MotherId = other.MotherId;
		AggressiveTimes = other.AggressiveTimes;
		NegativeTimes = other.NegativeTimes;
		TemplateId = other.TemplateId;
		FatherId = other.FatherId;
		LastChoiceIsAggressive = other.LastChoiceIsAggressive;
		LastEvolutionResult = other.LastEvolutionResult;
		RandomSeed = other.RandomSeed;
		PettingCoolDown = other.PettingCoolDown;
		Generation = other.Generation;
		NextPeriod = other.NextPeriod;
	}

	public void Assign(Jiao other)
	{
		Key = other.Key;
		Gender = other.Gender;
		TamePoint = other.TamePoint;
		NurturanceTemplateId = other.NurturanceTemplateId;
		CanBreed = other.CanBreed;
		GrowthStage = other.GrowthStage;
		EvolveRemainingMonth = other.EvolveRemainingMonth;
		Height = other.Height;
		Weight = other.Weight;
		LifeSpan = other.LifeSpan;
		NameId = other.NameId;
		Behavior = other.Behavior;
		Properties = new JiaoProperty(other.Properties);
		Id = other.Id;
		MotherId = other.MotherId;
		AggressiveTimes = other.AggressiveTimes;
		NegativeTimes = other.NegativeTimes;
		TemplateId = other.TemplateId;
		FatherId = other.FatherId;
		LastChoiceIsAggressive = other.LastChoiceIsAggressive;
		LastEvolutionResult = other.LastEvolutionResult;
		RandomSeed = other.RandomSeed;
		PettingCoolDown = other.PettingCoolDown;
		Generation = other.Generation;
		NextPeriod = other.NextPeriod;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 165;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 25;
		pCurrData += 2;
		pCurrData += Key.Serialize(pCurrData);
		*pCurrData = (Gender ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = TamePoint;
		pCurrData += 4;
		*(short*)pCurrData = NurturanceTemplateId;
		pCurrData += 2;
		*pCurrData = (CanBreed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)GrowthStage;
		pCurrData++;
		*(int*)pCurrData = EvolveRemainingMonth;
		pCurrData += 4;
		pCurrData += SerializationHelper.Serialize(pCurrData, Height);
		pCurrData += SerializationHelper.Serialize(pCurrData, Weight);
		pCurrData += SerializationHelper.Serialize(pCurrData, LifeSpan);
		*(int*)pCurrData = NameId;
		pCurrData += 4;
		*pCurrData = (byte)Behavior;
		pCurrData++;
		pCurrData += Properties.Serialize(pCurrData);
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(int*)pCurrData = MotherId;
		pCurrData += 4;
		*(int*)pCurrData = AggressiveTimes;
		pCurrData += 4;
		*(int*)pCurrData = NegativeTimes;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(int*)pCurrData = FatherId;
		pCurrData += 4;
		*pCurrData = (LastChoiceIsAggressive ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = LastEvolutionResult;
		pCurrData += 2;
		*(int*)pCurrData = RandomSeed;
		pCurrData += 4;
		*(int*)pCurrData = PettingCoolDown;
		pCurrData += 4;
		*(int*)pCurrData = Generation;
		pCurrData += 4;
		*(int*)pCurrData = NextPeriod;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += Key.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			Gender = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			TamePoint = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			NurturanceTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 4)
		{
			CanBreed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 5)
		{
			GrowthStage = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 6)
		{
			EvolveRemainingMonth = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 7)
		{
			pCurrData += SerializationHelper.Deserialize(pCurrData, out Height);
		}
		if (num > 8)
		{
			pCurrData += SerializationHelper.Deserialize(pCurrData, out Weight);
		}
		if (num > 9)
		{
			pCurrData += SerializationHelper.Deserialize(pCurrData, out LifeSpan);
		}
		if (num > 10)
		{
			NameId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 11)
		{
			Behavior = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 12)
		{
			if (Properties == null)
			{
				Properties = new JiaoProperty();
			}
			pCurrData += Properties.Deserialize(pCurrData);
		}
		if (num > 13)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 14)
		{
			MotherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 15)
		{
			AggressiveTimes = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 16)
		{
			NegativeTimes = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 17)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 18)
		{
			FatherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 19)
		{
			LastChoiceIsAggressive = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 20)
		{
			LastEvolutionResult = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 21)
		{
			RandomSeed = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 22)
		{
			PettingCoolDown = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 23)
		{
			Generation = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 24)
		{
			NextPeriod = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
