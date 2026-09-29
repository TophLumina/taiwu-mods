using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

[SerializableGameData(NotForArchive = true)]
public class CharacterGoalDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int GoalTemplateId;

	[SerializableGameDataField]
	public int CreateDate;

	[SerializableGameDataField]
	public int Priority;

	[SerializableGameDataField]
	public bool Finished;

	[SerializableGameDataField]
	public int RemainMonth = int.MinValue;

	[SerializableGameDataField]
	public string ParameterContent;

	public CharacterGoalDisplayData()
	{
	}

	public CharacterGoalDisplayData(CharacterGoalDisplayData other)
	{
		GoalTemplateId = other.GoalTemplateId;
		CreateDate = other.CreateDate;
		Priority = other.Priority;
		Finished = other.Finished;
		RemainMonth = other.RemainMonth;
		ParameterContent = other.ParameterContent;
	}

	public void Assign(CharacterGoalDisplayData other)
	{
		GoalTemplateId = other.GoalTemplateId;
		CreateDate = other.CreateDate;
		Priority = other.Priority;
		Finished = other.Finished;
		RemainMonth = other.RemainMonth;
		ParameterContent = other.ParameterContent;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		totalSize = ((ParameterContent == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ParameterContent.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = GoalTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = CreateDate;
		pCurrData += 4;
		*(int*)pCurrData = Priority;
		pCurrData += 4;
		*pCurrData = (Finished ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = RemainMonth;
		pCurrData += 4;
		if (ParameterContent != null)
		{
			int elementsCount = ParameterContent.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = ParameterContent)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		GoalTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		CreateDate = *(int*)pCurrData;
		pCurrData += 4;
		Priority = *(int*)pCurrData;
		pCurrData += 4;
		Finished = *pCurrData != 0;
		pCurrData++;
		RemainMonth = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			ParameterContent = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			ParameterContent = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
