using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ekm.Mobile.Converters
{
  public class NodeConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return (objectType == typeof(Node));
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      Node node = (Node)value;
      JObject jo = new JObject();
      jo.Add("name", node.Name);
      if (node.Children.Count == 0)
      {
        jo.Add("leaf", true);
      }
      else
      {
        jo.Add("children", JArray.FromObject(node.Children, serializer));
      }
      jo.WriteTo(writer);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }
  }

  public class Node
  {
    public Node()
    {
      Children = new List<Node>();
    }

    public string Name { get; set; }
    public List<Node> Children { get; set; }
  }
}
