namespace Models.ProtocolTests.Read.Linking
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    [TestClass]
    public class MappingsTests
    {

        [TestMethod]
        public void Mappings_Duplicate_Add()
        {
            // arrange
            var mapping = Mapping.Create<IParamsParam>(Mappings.ParamsById, x => Convert.ToString(x.Id?.Value));
            var dummyParam1a = new DummyParameter("1");
            var dummyParam1b = new DummyParameter("1");

            // act
            mapping.TryAddObject(dummyParam1a);
            mapping.TryAddObject(dummyParam1b);

            // assert
            Assert.AreEqual(dummyParam1a, mapping["1"]);
        }

        [TestMethod]
        public void Mappings_Duplicate_Remove()
        {
            // arrange
            var mapping = Mapping.Create<IParamsParam>(Mappings.ParamsById, x => Convert.ToString(x.Id?.Value));
            var dummyParam1a = new DummyParameter("1");
            var dummyParam1b = new DummyParameter("1");

            mapping.TryAddObject(dummyParam1a);
            mapping.TryAddObject(dummyParam1b);

            Assert.AreEqual(dummyParam1a, mapping["1"]);

            // act
            mapping.TryRemoveObject(dummyParam1a);

            // assert
            Assert.AreEqual(dummyParam1b, mapping["1"]);
        }

        [TestMethod]
        public void Mappings_Duplicate_Update()
        {
            // arrange
            var mapping = Mapping.Create<IParamsParam>(Mappings.ParamsById, x => Convert.ToString(x.Id?.Value));
            var dummyParam1a = new DummyParameter("1");
            var dummyParam1b = new DummyParameter("1");

            mapping.TryAddObject(dummyParam1a);
            mapping.TryAddObject(dummyParam1b);

            Assert.AreEqual(dummyParam1a, mapping["1"]);

            // act
            var newId = new AttributeTag<uint?>(null, null, "id");
            newId.SetValue("2", nameof(dummyParam1a.Id));

            dummyParam1a.Id = newId;
            mapping.TryUpdateObject(dummyParam1a);

            // assert
            Assert.AreEqual(dummyParam1a, mapping["2"]);
            Assert.AreEqual(dummyParam1b, mapping["1"]);
        }

        [TestMethod]
        public void Mappings_Add_RaisesEvent()
        {
            // arrange
            var mapping = Mapping.Create<IParamsParam>(Mappings.ParamsById, x => Convert.ToString(x.Id?.Value));
            var dummyParam = new DummyParameter("1");

            ObjectAddedEventArgs args = null;
            mapping.ObjectAdded += (s, e) => args = e;

            // act
            mapping.TryAddObject(dummyParam);

            // assert
            Assert.IsNotNull(args);
            Assert.AreEqual(dummyParam, args.Object);
            Assert.AreEqual("1", args.Key);
        }

        [TestMethod]
        public void Mappings_Remove_RaisesEvent()
        {
            // arrange
            var mapping = Mapping.Create<IParamsParam>(Mappings.ParamsById, x => Convert.ToString(x.Id?.Value));
            var dummyParam = new DummyParameter("1");
            mapping.TryAddObject(dummyParam);

            ObjectRemovedEventArgs args = null;
            mapping.ObjectRemoved += (s, e) => args = e;

            // act
            mapping.TryRemoveObject(dummyParam);

            // assert
            Assert.IsNotNull(args);
            Assert.AreEqual(dummyParam, args.Object);
            Assert.AreEqual("1", args.Key);
        }

        [TestMethod]
        public void Mappings_DuplicateAs_Add()
        {
            // arrange
            IEnumerable<string> extractIDs(IParamsParam x)
            {
                yield return Convert.ToString(x.Id?.Value);

                foreach (var id in x.GetDuplicateAsIds())
                    yield return id;
            }

            var mapping = Mapping.Create<IParamsParam>(Mappings.ParamsById, (Func<IParamsParam, IEnumerable<string>>)extractIDs);
            var dummyParam1 = new DummyParameter("1", "2,3");

            // act
            mapping.TryAddObject(dummyParam1);

            // assert
            Assert.AreEqual(dummyParam1, mapping["1"]);
            Assert.AreEqual(dummyParam1, mapping["2"]);
            Assert.AreEqual(dummyParam1, mapping["3"]);
        }
    }
}
