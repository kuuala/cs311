using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;


namespace SimpleLang.Visitors
{
    public class MaxIfCycleNestVisitor : AutoVisitor
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
        public override void VisitIfNode(IfNode i)
        {
            CurrentNest += 1;
            if (CurrentNest > MaxNest)
            {
                MaxNest = CurrentNest;
            }
            i.StateTrue.Visit(this);
            i.StateFalse?.Visit(this);
            CurrentNest -= 1;
        }
    }
}