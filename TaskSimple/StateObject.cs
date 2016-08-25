using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSimple
{
    public class StateObject
    {
        private int state = 5;

        public void ChangeState(int loop)
        {
            if (state == 5)
            {
                state++;
                Trace.Assert(state == 6, "Race condition occurred after" + loop + "loops");
            }
            state = 5;
        }
    }
}
