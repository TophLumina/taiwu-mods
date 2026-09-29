using GameData.Serializer;

namespace GameData.Domains.Taiwu.ExchangeSystem;

[SerializeTo(typeof(sbyte))]
public enum EExchangeType
{
	Invalid = -1,
	Person,
	BookSect,
	BookPriv,
	Settlement,
	Shop,
	Warehouse
}
