namespace GameData.Serializer;

public interface IBinary
{
	unsafe void Insert(byte* pSrc, int offset, int size);

	unsafe void Write(byte* pSrc, int offset, int size);

	void Remove(int offset, int size);

	int GetSize();

	void Clear();

	void EnsureCapacity(int desiredSize);

	byte[] GetRawData();

	void SetRawData(byte[] rawData);

	unsafe void CopyTo(int offset, int size, byte* pDest);

	ushort GetSerializedFixedSizeOfMetadata();

	unsafe int SerializeMetadata(byte* pData);

	unsafe int DeserializeMetadata(byte* pData);
}
