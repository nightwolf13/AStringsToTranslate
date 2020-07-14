using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AStringsToTranslate
{
	[DebuggerDisplay("{Language}")]
	public class AXmlResource : List<AXmlResourceItem>
	{
		public string Language { get; set; }
	}

	public abstract class AXmlResourceItem
	{
		public string Name { get; set; }
		public List<string> Comments { get; } = new List<string>();

		public abstract AXmlResourceItem Clone();
	}

	[DebuggerDisplay("{Name} - {Value}")]
	public class AXmlString : AXmlResourceItem
	{
		public bool IsTranslatable { get; set; } = true;
		public string Value { get; set; }

		public override AXmlResourceItem Clone()
		{
			var cloneObj = new AXmlString()
			{
				Name = this.Name,
				IsTranslatable = this.IsTranslatable,
				Value = this.Value
			};

			cloneObj.Comments.AddRange(this.Comments);

			return cloneObj;
		}
	}

	[DebuggerDisplay("{Name}")]
	public class AXmlPlural : AXmlResourceItem//, IXmlSerializable
	{
		public Dictionary<QuantityType, AXmlPluralItem> Items { get; set; } = new Dictionary<QuantityType, AXmlPluralItem>();

		//public XmlSchema GetSchema()
		//{
		//	return null;
		//}

		//public void ReadXml(XmlReader reader)
		//{
		//	if (reader.IsStartElement())
		//	{
		//		while (reader.Read())
		//		{
		//			if (reader.Name == "item")
		//			{
		//				XmlSerializer xmlSerializer = new XmlSerializer(typeof(AXmlPluralItem));
		//				AXmlPluralItem item = (AXmlPluralItem)xmlSerializer.Deserialize(reader);
		//				this.Items.Add(item.Quantity, item);
		//			}
		//		}
		//	}
		//}

		//public void WriteXml(XmlWriter writer)
		//{
		//	throw new NotImplementedException();
		//}

		public void Add(AXmlPluralItem item)
		{
			this.Items.Add(item.Quantity, item);
		}

		public override AXmlResourceItem Clone()
		{
			var cloneObj = new AXmlPlural()
			{
				Name = this.Name,
			};

			cloneObj.Comments.AddRange(this.Comments);

			foreach (var item in this.Items)
			{
				cloneObj.Items.Add(item.Key, item.Value.Clone());
			}

			return cloneObj;
		}
	}


	[DebuggerDisplay("{Quantity} - {Value}")]
	public class AXmlPluralItem
	{
		public QuantityType Quantity { get; set; }
		public string Value { get; set; }

		public AXmlPluralItem Clone()
		{
			return new AXmlPluralItem() { Quantity = this.Quantity, Value = this.Value };
		}
	}
}
