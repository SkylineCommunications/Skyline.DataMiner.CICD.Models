namespace Models.ProtocolTests.Read.Linking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    [TestClass]
    public class RelationManagerTests
    {
        [TestMethod]
        public void Ctor_MappingsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RelationManager(null));
        }

        [TestMethod]
        public void Dispose_Execute_DoesNotThrowException()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();

            Func<RelationManager> action = () => new RelationManager(mappings);

            // act
            action.Should().NotThrow();

            action.Invoke().Dispose();
        }

        #region References

        [TestMethod]
        public void Reference_Add_CorrectForwardReference()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "10");

            // act
            NotifyAdded(mappings, relationManager, dummyGroup);

            // assert
            var refs = relationManager.GetForwardReferences(dummyGroup).ToList();
            CollectionAssert.AreEquivalent(new Reference[] { r }, refs);
        }

        [TestMethod]
        public void Reference_Add_CorrectReverseReference()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "10");

            var dummyParam = new DummyParameter("10");

            // act
            NotifyAdded(mappings, relationManager, dummyGroup);

            // assert
            var refs = relationManager.GetReverseReferences(dummyParam).ToList();
            CollectionAssert.AreEquivalent(new Reference[] { r }, refs);

            refs = relationManager.GetReverseReferences(Mappings.ParamsById, "10").ToList();
            CollectionAssert.AreEquivalent(new Reference[] { r }, refs);
        }

        [TestMethod]
        public void Reference_Update_ReferenceUpdated()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            var r1 = dummyGroup.AddReference(Mappings.ParamsById, "10");

            NotifyAdded(mappings, relationManager, dummyGroup);
            CollectionAssert.AreEquivalent(new Reference[] { r1 }, relationManager.GetForwardReferences(dummyGroup).ToList());
            CollectionAssert.AreEquivalent(new Reference[] { r1 }, relationManager.GetReverseReferences(Mappings.ParamsById, "10").ToList());
            CollectionAssert.AreEquivalent(new Reference[] { }, relationManager.GetReverseReferences(Mappings.ParamsById, "20").ToList());

            // act
            dummyGroup.ClearReferences();
            var r2 = dummyGroup.AddReference(Mappings.ParamsById, "20");

            NotifyUpdated(mappings, relationManager, dummyGroup);

            // assert
            CollectionAssert.AreEquivalent(new Reference[] { r2 }, relationManager.GetForwardReferences(dummyGroup).ToList());
            CollectionAssert.AreEquivalent(new Reference[] { }, relationManager.GetReverseReferences(Mappings.ParamsById, "10").ToList());
            CollectionAssert.AreEquivalent(new Reference[] { r2 }, relationManager.GetReverseReferences(Mappings.ParamsById, "20").ToList());
        }

        [TestMethod]
        public void Reference_Remove_ReferenceRemoved()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "10");

            NotifyAdded(mappings, relationManager, dummyGroup);
            CollectionAssert.AreEquivalent(new Reference[] { r }, relationManager.GetForwardReferences(dummyGroup).ToList());
            CollectionAssert.AreEquivalent(new Reference[] { r }, relationManager.GetReverseReferences(Mappings.ParamsById, "10").ToList());

            // act
            NotifyRemoved(mappings, relationManager, dummyGroup);

            // assert
            CollectionAssert.AreEquivalent(new Reference[] { }, relationManager.GetForwardReferences(dummyGroup).ToList());
            CollectionAssert.AreEquivalent(new Reference[] { }, relationManager.GetReverseReferences(Mappings.ParamsById, "10").ToList());
        }

        [TestMethod]
        public void Reference_Add_RaisesEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "10");

            ReferenceAddedEventArgs args = null;
            relationManager.ReferenceAdded += (s, e) => args = e;

            // act
            NotifyAdded(mappings, relationManager, dummyGroup);

            // assert
            Assert.IsNotNull(args);
            Assert.AreEqual(r, args.Reference);
        }

        [TestMethod]
        public void Reference_AddWithDeferEvents_DoesNotRaiseEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            dummyGroup.AddReference(Mappings.ParamsById, "10");

            bool eventReceived = false;
            relationManager.ReferenceAdded += (s, e) => eventReceived = true;

            // act
            using (relationManager.DeferEvents())
            {
                NotifyAdded(mappings, relationManager, dummyGroup);
            }

            // assert
            Assert.IsFalse(eventReceived);
        }

        [TestMethod]
        public void Reference_Remove_RaisesEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "10");

            NotifyAdded(mappings, relationManager, dummyGroup);

            ReferenceRemovedEventArgs args = null;
            relationManager.ReferenceRemoved += (s, e) => args = e;

            // act
            NotifyRemoved(mappings, relationManager, dummyGroup);

            // assert
            Assert.IsNotNull(args);
            Assert.AreEqual(r, args.Reference);
        }

        [TestMethod]
        public void Reference_RemoveWithDeferEvents_DoesNotRaiseEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyGroup = new DummyGroup("2");
            dummyGroup.AddReference(Mappings.ParamsById, "10");

            NotifyAdded(mappings, relationManager, dummyGroup);

            bool eventReceived = false;
            relationManager.ReferenceRemoved += (s, e) => eventReceived = true;

            // act
            using (relationManager.DeferEvents())
            {
                NotifyRemoved(mappings, relationManager, dummyGroup);
            }

            // assert
            Assert.IsFalse(eventReceived);
        }

        #endregion

        #region Links

        [TestMethod]
        public void Link_AddForward_LinkCreated()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "1");

            // act
            NotifyAdded(mappings, relationManager, dummyParam);
            NotifyAdded(mappings, relationManager, dummyGroup);

            // assert
            var linksParam = relationManager.GetLinks(dummyParam).ToList();
            var linksGroup = relationManager.GetLinks(dummyGroup).ToList();
            Assert.AreEqual(1, linksParam.Count);
            Assert.AreEqual(1, linksGroup.Count);

            var link = linksParam.First();
            Assert.AreEqual(link, linksGroup.First());

            Assert.AreEqual(r, link.Reference);
            Assert.AreEqual(dummyGroup, link.Source);
            Assert.AreEqual(dummyParam, link.Target);
        }

        [TestMethod]
        public void Link_AddReverse_LinkCreated()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "1");

            // act
            NotifyAdded(mappings, relationManager, dummyGroup);
            NotifyAdded(mappings, relationManager, dummyParam);

            // assert
            var linksParam = relationManager.GetLinks(dummyParam).ToList();
            var linksGroup = relationManager.GetLinks(dummyGroup).ToList();
            Assert.AreEqual(1, linksParam.Count);
            Assert.AreEqual(1, linksGroup.Count);

            var link = linksParam.First();
            Assert.AreEqual(link, linksGroup.First());

            Assert.AreEqual(r, link.Reference);
            Assert.AreEqual(dummyGroup, link.Source);
            Assert.AreEqual(dummyParam, link.Target);
        }

        [TestMethod]
        public void Link_UpdateForward_LinkUpdated()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam1 = new DummyParameter("1");
            var dummyParam2 = new DummyParameter("2");

            var dummyGroup = new DummyGroup("3");
            dummyGroup.AddReference(Mappings.ParamsById, "1");

            NotifyAdded(mappings, relationManager, dummyParam1);
            NotifyAdded(mappings, relationManager, dummyParam2);
            NotifyAdded(mappings, relationManager, dummyGroup);

            Assert.AreEqual(1, relationManager.GetLinks(dummyParam1).Count());
            Assert.AreEqual(0, relationManager.GetLinks(dummyParam2).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyGroup).Count());

            // act
            dummyGroup.ClearReferences();
            var r = dummyGroup.AddReference(Mappings.ParamsById, "2");
            NotifyUpdated(mappings, relationManager, dummyGroup);

            // assert
            var linksParam1 = relationManager.GetLinks(dummyParam1).ToList();
            var linksParam2 = relationManager.GetLinks(dummyParam2).ToList();
            var linksGroup = relationManager.GetLinks(dummyGroup).ToList();
            Assert.AreEqual(0, linksParam1.Count);
            Assert.AreEqual(1, linksParam2.Count);
            Assert.AreEqual(1, linksGroup.Count);

            var link = linksParam2.First();
            Assert.AreEqual(link, linksGroup.First());

            Assert.AreEqual(r, link.Reference);
            Assert.AreEqual(dummyGroup, link.Source);
            Assert.AreEqual(dummyParam2, link.Target);
        }

        [TestMethod]
        public void Link_UpdateReverse_LinkUpdated()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("3");
            var r1 = dummyGroup.AddReference(Mappings.ParamsById, "1");
            var r2 = dummyGroup.AddReference(Mappings.ParamsById, "2");

            NotifyAdded(mappings, relationManager, dummyParam);
            NotifyAdded(mappings, relationManager, dummyGroup);

            var links = relationManager.GetLinks(dummyParam).ToList();
            Assert.AreEqual(1, links.Count);
            Assert.AreEqual(r1, links.First().Reference);

            // act
            var attrId = new AttributeTag<uint?>(null, null, "id");
            attrId.SetValue("2", nameof(dummyParam.Id));
            dummyParam.Id = attrId;
            NotifyUpdated(mappings, relationManager, dummyParam);

            // assert
            var linksParam = relationManager.GetLinks(dummyParam).ToList();
            var linksGroup = relationManager.GetLinks(dummyGroup).ToList();
            Assert.AreEqual(1, linksParam.Count);
            Assert.AreEqual(1, linksGroup.Count);

            var link = linksParam.First();
            Assert.AreEqual(link, linksGroup.First());

            Assert.AreEqual(r2, link.Reference);
            Assert.AreEqual(dummyGroup, link.Source);
            Assert.AreEqual(dummyParam, link.Target);
        }

        [TestMethod]
        public void Link_RemoveForward_LinkRemoved()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            dummyGroup.AddReference(Mappings.ParamsById, "1");

            NotifyAdded(mappings, relationManager, dummyParam);
            NotifyAdded(mappings, relationManager, dummyGroup);

            Assert.AreEqual(1, relationManager.GetLinks(dummyParam).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyGroup).Count());

            // act
            NotifyRemoved(mappings, relationManager, dummyGroup);

            // assert
            var linksParam = relationManager.GetLinks(dummyParam).ToList();
            var linksGroup = relationManager.GetLinks(dummyGroup).ToList();
            Assert.AreEqual(0, linksParam.Count);
            Assert.AreEqual(0, linksGroup.Count);
        }

        [TestMethod]
        public void Link_RemoveReverse_LinkRemoved()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            dummyGroup.AddReference(Mappings.ParamsById, "1");

            NotifyAdded(mappings, relationManager, dummyParam);
            NotifyAdded(mappings, relationManager, dummyGroup);

            Assert.AreEqual(1, relationManager.GetLinks(dummyParam).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyGroup).Count());

            // act
            NotifyRemoved(mappings, relationManager, dummyParam);

            // assert
            var linksParam = relationManager.GetLinks(dummyParam).ToList();
            var linksGroup = relationManager.GetLinks(dummyGroup).ToList();
            Assert.AreEqual(0, linksParam.Count);
            Assert.AreEqual(0, linksGroup.Count);
        }

        [TestMethod]
        public void Link_Duplicates_Forward()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam1a = new DummyParameter("1");
            var dummyParam1b = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            dummyGroup.AddReference(Mappings.ParamsById, "1");

            NotifyAdded(mappings, relationManager, dummyParam1a);
            NotifyAdded(mappings, relationManager, dummyParam1b);
            NotifyAdded(mappings, relationManager, dummyGroup);

            Assert.AreEqual(1, relationManager.GetLinks(dummyParam1a).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyParam1b).Count());
            Assert.AreEqual(2, relationManager.GetLinks(dummyGroup).Count());

            // act
            NotifyRemoved(mappings, relationManager, dummyParam1a);

            // assert
            Assert.AreEqual(0, relationManager.GetLinks(dummyParam1a).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyParam1b).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyGroup).Count());
        }

        [TestMethod]
        public void Link_Duplicates_Reverse()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam1a = new DummyParameter("1");
            var dummyParam1b = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            dummyGroup.AddReference(Mappings.ParamsById, "1");

            NotifyAdded(mappings, relationManager, dummyGroup);
            NotifyAdded(mappings, relationManager, dummyParam1a);
            NotifyAdded(mappings, relationManager, dummyParam1b);

            Assert.AreEqual(1, relationManager.GetLinks(dummyParam1a).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyParam1b).Count());
            Assert.AreEqual(2, relationManager.GetLinks(dummyGroup).Count());

            // act
            NotifyRemoved(mappings, relationManager, dummyParam1a);

            // assert
            Assert.AreEqual(0, relationManager.GetLinks(dummyParam1a).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyParam1b).Count());
            Assert.AreEqual(1, relationManager.GetLinks(dummyGroup).Count());
        }


        [TestMethod]
        public void Link_Add_RaisesEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "1");

            LinkAddedEventArgs args = null;
            relationManager.LinkAdded += (s, e) => args = e;

            // act
            NotifyAdded(mappings, relationManager, dummyParam);
            NotifyAdded(mappings, relationManager, dummyGroup);

            // assert
            Assert.IsNotNull(args);
            Assert.IsNotNull(args.Link);
        }

        [TestMethod]
        public void Link_AddWithDeferEvents_DoesNotRaiseEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "1");

            bool eventReceived = false;
            relationManager.LinkAdded += (s, e) => eventReceived = true;

            // act
            using (relationManager.DeferEvents())
            {
                NotifyAdded(mappings, relationManager, dummyParam);
                NotifyAdded(mappings, relationManager, dummyGroup);
            }

            // assert
            Assert.IsFalse(eventReceived);
        }

        [TestMethod]
        public void Link_Remove_RaisesEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            var r = dummyGroup.AddReference(Mappings.ParamsById, "1");

            NotifyAdded(mappings, relationManager, dummyParam);
            NotifyAdded(mappings, relationManager, dummyGroup);

            LinkRemovedEventArgs args = null;
            relationManager.LinkRemoved += (s, e) => args = e;

            // act
            NotifyRemoved(mappings, relationManager, dummyParam);
            NotifyRemoved(mappings, relationManager, dummyGroup);

            // assert
            Assert.IsNotNull(args);
            Assert.IsNotNull(args.Link);
        }

        [TestMethod]
        public void Link_RemoveWithDeferEvents_DoesNotRaiseEvent()
        {
            // arrange
            var mappings = ProtocolModel.CreateMappings();
            var relationManager = new RelationManager(mappings);

            var dummyParam = new DummyParameter("1");

            var dummyGroup = new DummyGroup("2");
            dummyGroup.AddReference(Mappings.ParamsById, "1");

            NotifyAdded(mappings, relationManager, dummyParam);
            NotifyAdded(mappings, relationManager, dummyGroup);

            bool eventReceived = false;
            relationManager.LinkRemoved += (s, e) => eventReceived = true;

            // act
            using (relationManager.DeferEvents())
            {
                NotifyRemoved(mappings, relationManager, dummyParam);
                NotifyRemoved(mappings, relationManager, dummyGroup);
            }

            // assert
            Assert.IsFalse(eventReceived);
        }

        #endregion

        #region Private Methods

        private void NotifyAdded(Dictionary<Mappings, Mapping> mappings, RelationManager relationManager, IReadable obj)
        {
            // update mappings
            var type = obj.GetType();

            foreach (var m in mappings.Values)
                if (m.Type.IsAssignableFrom(type))
                {
                    m.TryAddObject(obj);
                }

            // update relations
            relationManager.NotifyAdded(obj);
        }

        private void NotifyUpdated(Dictionary<Mappings, Mapping> mappings, RelationManager relationManager, IReadable obj)
        {
            // update mappings
            var type = obj.GetType();

            foreach (var m in mappings.Values)
                if (m.Type.IsAssignableFrom(type))
                {
                    m.TryUpdateObject(obj);
                }

            // update relations
            relationManager.NotifyUpdated(obj);
        }

        private void NotifyRemoved(Dictionary<Mappings, Mapping> mappings, RelationManager relationManager, IReadable obj)
        {
            var visitor = new GetDescendantProtocolObjectsVisitor();
            obj.Accept(visitor);

            ICollection<IReadable> objects = visitor.Objects;

            foreach (var o in objects)
            {
                // update mappings
                foreach (var m in mappings.Values)
                    m.TryRemoveObject(o);

                // update relations
                relationManager.NotifyRemoved(o);
            }
        }

        #endregion

    }
}
