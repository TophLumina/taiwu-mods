using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class PoisonAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort PoisonItem = 0;

		public const ushort ActionPhase = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "PoisonItem", "ActionPhase" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private ItemKey _poisonItem = ItemKey.Invalid;

	[SerializableGameDataField(FieldIndex = 1)]
	private sbyte _actionPhase = -1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (_poisonItem.IsValid())
		{
			if (selfChar.GetInventory().Items.TryGetValue(_poisonItem, out var amount))
			{
				return amount > 0;
			}
			return false;
		}
		return true;
	}

	public void PostExecuteForTaiwuTarget(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		PostExecute(context, selfChar, actionData);
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		DomainManager.Character.HandlePoisonAction(context, character, targetChar, _poisonItem, _actionPhase);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize += _poisonItem.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		int fieldSize = _poisonItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = (byte)_actionPhase;
		pCurrData++;
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
			pCurrData += _poisonItem.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			_actionPhase = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
