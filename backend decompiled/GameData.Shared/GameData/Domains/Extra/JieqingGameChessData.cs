using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Extra;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class JieqingGameChessData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CoordinateX = 0;

		public const ushort CoordinateY = 1;

		public const ushort ChessIsFlipped = 2;

		public const ushort ChessRotationState = 3;

		public const ushort ChessTemplateId = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "CoordinateX", "CoordinateY", "ChessIsFlipped", "ChessRotationState", "ChessTemplateId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public byte CoordinateX { get; set; }

	[SerializableGameDataField(FieldIndex = 1)]
	public byte CoordinateY { get; set; }

	[SerializableGameDataField(FieldIndex = 2)]
	public bool ChessIsFlipped { get; set; }

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte ChessRotationState { get; set; }

	[SerializableGameDataField(FieldIndex = 4)]
	public short ChessTemplateId { get; set; } = -1;

	public JieqingGameChessData()
	{
	}

	public JieqingGameChessData(JieqingGameChessData other)
	{
		CoordinateX = other.CoordinateX;
		CoordinateY = other.CoordinateY;
		ChessIsFlipped = other.ChessIsFlipped;
		ChessRotationState = other.ChessRotationState;
		ChessTemplateId = other.ChessTemplateId;
	}

	public void Assign(JieqingGameChessData other)
	{
		CoordinateX = other.CoordinateX;
		CoordinateY = other.CoordinateY;
		ChessIsFlipped = other.ChessIsFlipped;
		ChessRotationState = other.ChessRotationState;
		ChessTemplateId = other.ChessTemplateId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 5;
		byte* num = pData + 2;
		*num = CoordinateX;
		byte* num2 = num + 1;
		*num2 = CoordinateY;
		byte* num3 = num2 + 1;
		*num3 = (ChessIsFlipped ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (byte)ChessRotationState;
		byte* num5 = num4 + 1;
		*(short*)num5 = ChessTemplateId;
		int totalSize = (int)(num5 + 2 - pData);
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
			CoordinateX = *pCurrData;
			pCurrData++;
		}
		if (num > 1)
		{
			CoordinateY = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
		{
			ChessIsFlipped = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			ChessRotationState = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 4)
		{
			ChessTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
