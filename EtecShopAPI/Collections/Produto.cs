using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EtecShopAPI.Collections;

[Table("produtos")]
[BsonIgnoreExtraElements]
public class Produto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]    
    public string Id { get; set; }

    [BsonElement("nome")]
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }

    [BsonElement("descricao")]
    [JsonPropertyName("Descrição")]
    public string Descricao { get; set; }

    [BsonElement("preco")]
    [JsonPropertyName("Preço")]
    public decimal Preco { get; set; }
    
    [BsonElement("precoDesconto")]
    public decimal PrecoDesconto { get; set; }

    [BsonElement("categorias")]
    public List<string> Categorias { get; set; }

    [BsonElement("tags")]
    public List<string> Tags { get; set; }

    [BsonElement("marca")]
    public string Marca { get; set; }

    [BsonElement("estoque")]
    public int Estoque { get; set; }

    [BsonElement("ativo")]
    public bool Ativo { get; set; }

}
