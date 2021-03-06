using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisLogic.UserAction.Tests
{
    [TestClass()]
    public class UA_HardDropTests
    {
        [TestMethod()]
        public void ActionTest_Normal()
        {
            // data
            var block = new Block(BlockTypes.O);
            var holdBlock = new Block(BlockTypes.nothing);
            var field = new Field();

            // target
            var act = new UA_HardDrop();

            // before
            var before = block.Location;

            // do
            act.Action(ref field, ref block, ref holdBlock);

            // after
            var after = block.Location;

            Assert.AreEqual(before.X, after.X);
            Assert.AreEqual(before.Y + 18, after.Y);
        }

        [TestMethod()]
        public void CanActionTest_BlockCanDropInInitState()
        {
            // data
            var block = new Block(BlockTypes.O);
            var field = new Field();

            // target
            var act = new UA_HardDrop();
            var ret = act.CanAction(field, block, new Block(BlockTypes.nothing));

            Assert.AreEqual(ret, true);
        }

        [TestMethod()]
        public void CanActionTest_BlockCanNotDropAfterDrop()
        {
            // data
            var block = new Block(BlockTypes.O);
            var holdBlock = new Block(BlockTypes.nothing);
            var field = new Field();

            // target
            var act = new UA_HardDrop();

            act.Action(ref field, ref block, ref holdBlock);

            var ret = act.CanAction(field, block, new Block(BlockTypes.nothing));
            Assert.AreEqual(ret, false);
        }
    }
}