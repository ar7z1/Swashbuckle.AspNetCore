﻿using System;
using System.Collections.Generic;

namespace Swashbuckle.AspNetCore.SwaggerGen.Test
{
    /// <summary>
    /// summary for XmlAnnotatedType
    /// </summary>
    public class XmlAnnotatedType
    {
        /// <summary>
        /// summary for Property
        /// </summary>
        /// <example>property example</example>
        public string Property { get; set; }

        /// <summary>
        /// summary for IntProperty
        /// </summary>
        /// <example>10</example>
        public int IntProperty { get; set; }

        /// <summary>
        /// summary for LongProperty
        /// </summary>
        /// <example>4294967295</example>
        public long LongProperty { get; set; }

        /// <summary>
        /// summary for DoubleProperty
        /// </summary>
        /// <example>1.25</example>
        public double DoubleProperty { get; set; }

        /// <summary>
        /// summary for FloatProperty
        /// </summary>
        /// <example>1.2</example>
        public float FloatProperty { get; set; }

        /// <summary>
        /// summary for ByteProperty
        /// </summary>
        /// <example>16</example>
        public byte ByteProperty { get; set; }

        /// <summary>
        /// summary for BadExampleIntProperty
        /// </summary>
        /// <example>property bad example</example>
        public int BadExampleIntProperty { get; set; }

        /// <summary>
        /// summary for Field
        /// </summary>
        /// <example>field example</example>
        public string Field;

        /// <summary>
        /// summary for BoolField
        /// </summary>
        /// <example>true</example>
        public bool BoolField;

        /// <summary>
        /// summary for AcceptsNothing
        /// </summary>
        public void AcceptsNothing()
        { }

        /// <summary>
        /// summary for AcceptsNestedType
        /// </summary>
        /// <param name="param"></param>
        public void AcceptsNestedType(NestedType param)
        { }

        /// <summary>
        /// summary for AcceptsConstructedGenericType
        /// </summary>
        /// <param name="param"></param>
        public void AcceptsConstructedGenericType(KeyValuePair<string, int> param)
        { }

        /// <summary>
        /// summary for AcceptsConstructedOfConstructedGenericType
        /// </summary>
        /// <param name="param"></param>
        public void AcceptsConstructedOfConstructedGenericType(IEnumerable<KeyValuePair<string, int>> param)
        { }

        /// <summary>
        /// summary for AcceptsArrayOfConstructedGenericType
        /// </summary>
        /// <param name="param"></param>
        public void AcceptsArrayOfConstructedGenericType(int?[] param)
        { }

        /// <summary>
        /// summary for NestedType
        /// </summary>
        public class NestedType
        {
            public string Property { get; set; }
        }
    }
}