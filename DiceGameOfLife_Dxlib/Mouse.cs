using DxLibDLL;
using System.Linq;
using System.Threading.Tasks;

namespace DiceGameOfLife_Dxlib
{
    class Mouse
    {
        private const int MouseCount = 11;
        
        public void Update()
        {
            flip = 1 - flip;
            mouses[flip] = DX.GetMouseInput();

            for(int i = 0; i < 11;i++)
            {
                int input = i << 1;
                if(((mouses[flip] & input) == 0) ^ ((mouses[flip] & input) == 0))
                {
                    times[i] = 1;
                }
                else
                {
                    times[i]++;
                }
            }
        }

        public bool IsPressing(int mouse)
        {
            return (mouses[flip] & mouse) != 0;
        }

        public int GetPressingTime(int mouse)
        {
            return IsPressing(mouse) ? times[mouse] : 0;
        }

        public bool IsPressed(int mouse)
        {
            return (mouses[flip] & mouse) != 0 && (mouses[1 - flip] & mouse) == 0;
        }

        public bool IsReleasing(int mouse)
        {
            return (mouses[flip] & mouse) == 0;
        }

        public int GetReleasingTime(int mouse)
        {
            return IsReleasing(mouse) ? times[mouse] : 0;
        }

        public bool IsReleased(int mouse)
        {
            return (mouses[flip] & mouse) == 0 && (mouses[1 - flip] & mouse) != 0;
        }

        private int[] mouses = { 0, 0 };
        private int flip = 0;
        private int[] times = new int[MouseCount];
    }
}
