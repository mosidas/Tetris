namespace TetrisLogic.UserAction
{
    public class UA_MoveLeft : IUserAction
    {
        public void Action(ref Field field, ref Block currentBlock, ref Block holdBlock)
        {
            currentBlock.MoveLocation(-1, 0);
            currentBlock.TSpinType = TSpinTypes.notTSpin;
        }

        public bool CanAction(Field field, Block block, Block holdBlock)
        {
            foreach (var p in block.GetBlockLeftPoints())
            {
                if (field.GetFieldType(p.X - 1, p.Y) != FieldTypes.empty)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
