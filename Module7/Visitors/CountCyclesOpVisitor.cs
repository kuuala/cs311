using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class CountCyclesOpVisitor : AutoVisitor
    {
        public int Count = 0;
        public int CycleCount = 0;
        public int depth = 0;
        public override void VisitCycleNode(CycleNode c)
        {
            CycleCount += 1;
            depth += 1;
            c.Stat.Visit(this);
            depth -= 1;
        }
        public override void VisitAssignNode(AssignNode a)
        {
            if (depth > 0)
            {
                Count += 1;
            }
        }
        public override void VisitVarDefNode(VarDefNode w) 
        {
            if (depth > 0)
            {
                Count += 1;   
            }
        }
        public override void VisitWriteNode(WriteNode w)
        {
            if (depth > 0)
            {
                Count += 1;
            }
        }
        public override void VisitBinOpNode(BinOpNode binop)
        {
            if (depth > 0)
            {
                Count += 1;
            }
        }
        public int MidCount()
        {
            return CycleCount == 0 ? 0 : Count / CycleCount;
        }
    }
}
