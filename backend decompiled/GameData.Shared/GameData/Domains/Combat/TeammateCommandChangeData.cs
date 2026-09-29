using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData]
public class TeammateCommandChangeData : ISerializableGameData
{
	[SerializableGameDataField]
	public TeammateCommandChangeDataPart LeftTeam;

	[SerializableGameDataField]
	public TeammateCommandChangeDataPart RightTeam;

	public IReadOnlyList<sbyte> GetCharTeammateCommands(int charId)
	{
		return GetCharTeammateCommandsInternal(charId);
	}

	private List<sbyte> GetCharTeammateCommandsInternal(int charId)
	{
		for (int i = 0; i < LeftTeam.TeammateCharIds.Count; i++)
		{
			if (LeftTeam.TeammateCharIds[i] == charId)
			{
				return LeftTeam.ReplaceTeammateCommands[i].Items;
			}
		}
		for (int j = 0; j < RightTeam.TeammateCharIds.Count; j++)
		{
			if (RightTeam.TeammateCharIds[j] == charId)
			{
				return RightTeam.ReplaceTeammateCommands[j].Items;
			}
		}
		return null;
	}

	public bool SetCharTeammateCommands(int charId, IEnumerable<sbyte> cmdTypes)
	{
		List<sbyte> finalCmdTypes = GetCharTeammateCommandsInternal(charId);
		if (finalCmdTypes == null)
		{
			return false;
		}
		finalCmdTypes.Clear();
		if (cmdTypes != null)
		{
			finalCmdTypes.AddRange(cmdTypes);
		}
		return true;
	}

	public TeammateCommandChangeData()
	{
	}

	public TeammateCommandChangeData(TeammateCommandChangeData other)
	{
		LeftTeam = new TeammateCommandChangeDataPart(other.LeftTeam);
		RightTeam = new TeammateCommandChangeDataPart(other.RightTeam);
	}

	public void Assign(TeammateCommandChangeData other)
	{
		LeftTeam = new TeammateCommandChangeDataPart(other.LeftTeam);
		RightTeam = new TeammateCommandChangeDataPart(other.RightTeam);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((LeftTeam == null) ? (totalSize + 2) : (totalSize + (2 + LeftTeam.GetSerializedSize())));
		totalSize = ((RightTeam == null) ? (totalSize + 2) : (totalSize + (2 + RightTeam.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (LeftTeam != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = LeftTeam.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RightTeam != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = RightTeam.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (LeftTeam == null)
			{
				LeftTeam = new TeammateCommandChangeDataPart();
			}
			pCurrData += LeftTeam.Deserialize(pCurrData);
		}
		else
		{
			LeftTeam = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (RightTeam == null)
			{
				RightTeam = new TeammateCommandChangeDataPart();
			}
			pCurrData += RightTeam.Deserialize(pCurrData);
		}
		else
		{
			RightTeam = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
