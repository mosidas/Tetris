namespace TetrisLogic.UserAction
{
    public class UA_HardDrop : IUserAction
    {
        private readonly UA_MoveDown MoveDown;
        public UA_HardDrop()
        {
            MoveDown = new UA_MoveDown();
        }
        public void Action(ref Field field, ref Block currentBlock, ref Block holdBlock)
        {
            while(CanAction(field, currentBlock, holdBlock))
            {
                MoveDown.Action(ref field, ref currentBlock, ref holdBlock);
            }
        }

        public bool CanAction(Field field, Block block, Block holdBlock)
        {
            return MoveDown.CanAction(field, block, holdBlock);
        }
    }
}
