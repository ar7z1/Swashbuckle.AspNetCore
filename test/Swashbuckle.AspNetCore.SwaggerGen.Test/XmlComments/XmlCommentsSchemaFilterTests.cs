﻿using System;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Serialization;
using Xunit;
using Swashbuckle.AspNetCore.Swagger;

namespace Swashbuckle.AspNetCore.SwaggerGen.Test
{
    public class XmlCommentsSchemaFilterTests
    {
        [Theory]
        [InlineData(typeof(XmlAnnotatedType), "summary for XmlAnnotatedType")]
        [InlineData(typeof(XmlAnnotatedType.NestedType), "summary for NestedType")]
        [InlineData(typeof(XmlAnnotatedGenericType<int, string>), "summary for XmlAnnotatedGenericType")]
        public void Apply_SetsDescription_FromSummaryTag(
            Type type,
            string expectedDescription)
        {
            var schema = new Schema
            {
                Properties = new Dictionary<string, Schema>()
            };
            var filterContext = FilterContextFor(type);

            Subject().Apply(schema, filterContext);

            Assert.Equal(expectedDescription, schema.Description);
        }

        [Theory]
        [InlineData(typeof(XmlAnnotatedType), "Property", "summary for Property")]
        [InlineData(typeof(XmlAnnotatedType), "Field", "summary for Field")]
        [InlineData(typeof(XmlAnnotatedSubType), "Property", "summary for Property")]
        [InlineData(typeof(XmlAnnotatedGenericType<string, bool>), "GenericProperty", "Summary for GenericProperty")]
        public void Apply_SetsPropertyDescriptions_FromPropertySummaryTags(
            Type type,
            string propertyName,
            string expectedDescription)
        {
            var schema = new Schema
            {
                Properties = new Dictionary<string, Schema>()
                {
                    { propertyName, new Schema() }
                }
            };
            var filterContext = FilterContextFor(type);

            Subject().Apply(schema, filterContext);

            Assert.Equal(expectedDescription, schema.Properties[propertyName].Description);
        }

        [Theory]
        [InlineData(typeof(XmlAnnotatedType), "Property", "property example")]
        [InlineData(typeof(XmlAnnotatedSubType), "Property", "property example")]
        [InlineData(typeof(XmlAnnotatedType), "Field", "field example")]
        [InlineData(typeof(XmlAnnotatedType), "IntProperty", 10)]
        [InlineData(typeof(XmlAnnotatedType), "LongProperty", 4294967295L)]
        [InlineData(typeof(XmlAnnotatedType), "DoubleProperty", 1.25)]
        [InlineData(typeof(XmlAnnotatedType), "FloatProperty", 1.2f)]
        [InlineData(typeof(XmlAnnotatedType), "ByteProperty", (byte)0x10)]
        [InlineData(typeof(XmlAnnotatedType), "BoolField", true)]
        [InlineData(typeof(XmlAnnotatedType), "BadExampleIntProperty", "property bad example")]
        public void Apply_SetsPropertyExample_FromPropertyExampleTags(
            Type type,
            string propertyName,
            object expectedExample)
        {
            var schema = new Schema
            {
                Properties = new Dictionary<string, Schema>()
                {
                    { propertyName, new Schema() }
                }
            };
            var filterContext = FilterContextFor(type);

            Subject().Apply(schema, filterContext);

            Assert.Equal(expectedExample, schema.Properties[propertyName].Example);
        }

        private SchemaFilterContext FilterContextFor(Type type)
        {
            var jsonObjectContract = new DefaultContractResolver().ResolveContract(type);
            return new SchemaFilterContext(type, (jsonObjectContract as JsonObjectContract), null);
        }

        private XmlCommentsSchemaFilter Subject()
        {
            using (var xmlComments = File.OpenText(GetType().GetTypeInfo()
                    .Assembly.GetName().Name + ".xml"))
            {
                return new XmlCommentsSchemaFilter(new XPathDocument(xmlComments));
            }
        }
    }
}