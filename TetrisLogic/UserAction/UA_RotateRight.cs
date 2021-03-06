namespace TetrisLogic.UserAction
{
    public class UA_RotateRight : IUserAction
    {
        private int MoveX;
        private int MoveY;
        public void Action(ref Field field, ref Block currentBlock, ref Block holdBlock)
        {
            currentBlock.MoveLocation(MoveX, MoveY);
            currentBlock.RotateRight();
            currentBlock.TSpinType = getTSpinType(field, currentBlock);
        }

        public bool CanAction(Field field, Block block, Block holdBlock)
        {
            MoveX = 0;
            MoveY = 0;
            if (block.BlockType == BlockTypes.O)
            {
                return true;
            }
            else if (block.BlockType == BlockTypes.I)
            {
                return CanAction_SRS_I(field, block);
            }
            else
            {
                return CanAction_SRS(field, block);
            }

        }

        private TSpinTypes getTSpinType(Field field, Block block)
        {
            if(block.BlockType != BlockTypes.T)
            {
                return TSpinTypes.notTSpin;
            }

            var points = block.GetTSpinPoints();
            var count = field.CountCollisionPoint(points);
            if(count >= 3)
            {
                if(count == 3 && MoveY == 0)
                {
                    return TSpinTypes.tMini;
                }
                else
                {
                    return TSpinTypes.tSpin;
                }
            }
            else
            {
                return TSpinTypes.notTSpin;
            }
        }

        private bool CanAction_SRS_I(Field field, Block block)
        {
            var dummyblock = GetDummyActionBlock(block);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState1_I(ref dummyblock, block);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState2_I(ref dummyblock, block);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState3_I(ref dummyblock, block);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState4_I(ref dummyblock, block);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            return false;
        }

        private void GetSRSState4_I(ref Block dummyblock, Block block)
        {
            dummyblock.MoveLocation(-1 * MoveX, -1 * MoveY);

            if (block.Direction == DirectionTypes.north)
            {
                dummyblock.MoveLocation(1, -2);
                MoveX = 1;
                MoveY = -2;
            }
            else if (block.Direction == DirectionTypes.east)
            {
                dummyblock.MoveLocation(2, 1);
                MoveX = 2;
                MoveY = 1;
            }
            else if (block.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(-1, 2);
                MoveX = -1;
                MoveY = 2;
            }
            else if (block.Direction == DirectionTypes.west)
            {
                dummyblock.MoveLocation(-2, -1);
                MoveX = -2;
                MoveY = 1;
            }
        }

        private void GetSRSState3_I(ref Block dummyblock, Block block)
        {
            dummyblock.MoveLocation(-1 * MoveX, -1 * MoveY);

            if (block.Direction == DirectionTypes.north)
            {
                dummyblock.MoveLocation(-2, 1);
                MoveX = -2;
                MoveY = 1;
            }
            else if (block.Direction == DirectionTypes.east)
            {
                dummyblock.MoveLocation(-1, -2);
                MoveX = -1;
                MoveY = -2;
            }
            else if (block.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(2, -1);
                MoveX = 2;
                MoveY = -1;
            }
            else if (block.Direction == DirectionTypes.west)
            {
                dummyblock.MoveLocation(1, 2);
                MoveX = 1;
                MoveY = 2;
            }
        }

        private void GetSRSState2_I(ref Block dummyblock, Block block)
        {
            dummyblock.MoveLocation(-1 * MoveX, -1 * MoveY);

            if (block.Direction == DirectionTypes.north)
            {
                dummyblock.MoveLocation(1, 0);
                MoveX = 1;
            }
            else if (block.Direction == DirectionTypes.east)
            {
                dummyblock.MoveLocation(2, 0);
                MoveX = 2;
            }
            else if (block.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(-1, 0);
                MoveX = -1;
            }
            else if (block.Direction == DirectionTypes.west)
            {
                dummyblock.MoveLocation(1, 0);
                MoveX = 1;
            }
        }

        private void GetSRSState1_I(ref Block dummyblock, Block block)
        {
            if (block.Direction == DirectionTypes.north)
            {
                dummyblock.MoveLocation(-2, 0);
                MoveX = -2;
            }
            else if(block.Direction == DirectionTypes.east)
            {
                dummyblock.MoveLocation(-1, 0);
                MoveX = -1;
            }
            else if (block.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(2, 0);
                MoveX = 2;
            }
            else if (block.Direction == DirectionTypes.west)
            {
                dummyblock.MoveLocation(-2, 0);
                MoveX = -2;
            }
        }

        private bool CanAction_SRS(Field field, Block block)
        {
            var dummyblock = GetDummyActionBlock(block);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState1(ref dummyblock);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState2(ref dummyblock);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState3(ref dummyblock);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            GetSRSState4(ref dummyblock);

            if (!field.ExistsCollisionPoint(dummyblock))
            {
                return true;
            }

            return false;
        }

        private void GetSRSState4(ref Block dummyblock)
        {
            if (dummyblock.Direction == DirectionTypes.north || dummyblock.Direction == DirectionTypes.east )
            {
                dummyblock.MoveLocation(-1, 0);
                MoveX += -1;
            }
            else if (dummyblock.Direction == DirectionTypes.west || dummyblock.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(1, 0);
                MoveX += 1;
            }
        }

        private void GetSRSState3(ref Block dummyblock)
        {
            dummyblock.MoveLocation(-1 * MoveX, -1 * MoveY);

            if (dummyblock.Direction == DirectionTypes.east || dummyblock.Direction == DirectionTypes.west)
            {
                dummyblock.MoveLocation(0, 2);
                MoveX = 0;
                MoveY = 2;
            }
            else if (dummyblock.Direction == DirectionTypes.north || dummyblock.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(0, -2);
                MoveX = 0;
                MoveY = -2;
            }
        }

        private void GetSRSState2(ref Block dummyblock)
        {
            if ( dummyblock.Direction == DirectionTypes.east || dummyblock.Direction == DirectionTypes.west)
            {
                dummyblock.MoveLocation(0, -1);
                MoveY += -1;
            }
            else if (dummyblock.Direction == DirectionTypes.north || dummyblock.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(0, 1);
                MoveY += 1;
            }
        }

        private void GetSRSState1(ref Block dummyblock)
        {
            if (dummyblock.Direction == DirectionTypes.north || dummyblock.Direction == DirectionTypes.east )
            {
                dummyblock.MoveLocation(-1, 0);
                MoveX += -1;
            }
            else if(dummyblock.Direction == DirectionTypes.west || dummyblock.Direction == DirectionTypes.south)
            {
                dummyblock.MoveLocation(1, 0);
                MoveX += 1;
            }
        }

        private Block GetDummyActionBlock(Block block)
        {
            var tmp = new Block(block);
            tmp.RotateRight();
            return tmp;
        }
    }
}
