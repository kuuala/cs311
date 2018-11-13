using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class MaxNestCyclesVisitor : AutoVisitor
    {
        public int MaxNest = 0;
        public int CurrentNest = 0;
        public override void VisitCycleNode(CycleNode c)
        {
            CurrentNest += 1;
            if (CurrentNest > MaxNest)
            {
                MaxNest = CurrentNest;
            }
            c.Stat.Visit(this);
            CurrentNest -= 1;
        }
    }
}
