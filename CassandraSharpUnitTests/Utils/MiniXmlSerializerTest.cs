﻿// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace CassandraSharpUnitTests.Utils
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using CassandraSharp.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class MiniXmlSerializerTest
    {
        [XmlRoot("RootClass")]
        public class TestRootClass
        {
            [XmlAttribute("nullableIntAttribute")]
            private int? NullableIntAttribute;

            [XmlElement("NullableIntElement")]
            private int? NullableIntElement;

            [XmlAttribute("stringAttribute")]
            private string StringAttribute;
        }

        [Test]
        public void TestDeserialize()
        {
            string xml =
                @"<RootClass nullableIntAttribute='42'>
                   <NullableIntElement>666</NullableIntElement>
                 </RootClass>";

            MiniXmlSerializer xmlSer = new MiniXmlSerializer(typeof(TestRootClass));

            TestRootClass rootClass;
            using (TextReader txtReader = new StringReader(xml))
            using(XmlReader xmlReader = XmlReader.Create(txtReader))
                rootClass = (TestRootClass)xmlSer.Deserialize(xmlReader);
        }
    }
}