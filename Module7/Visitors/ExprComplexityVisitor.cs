using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class ExprComplexityVisitor : AutoVisitor
    {
        // список должен содержать сложность каждого выражения, встреченного при обычном порядке обхода AST
        public bool InExpr = false;
        public List<int> Complexity = new List<int>();
        public override void VisitAssignNode(AssignNode a)
        {
            Complexity.Add(0);
            a.Expr.Visit(this);
        }
        public override void VisitCycleNode(CycleNode c)
        {
            Complexity.Add(0);
            c.Expr.Visit(this);
            c.Stat.Visit(this);
        }
        public override void VisitWriteNode(WriteNode w)
        {
            Complexity.Add(0);
            w.Expr.Visit(this);
        }
        public override void VisitBinOpNode(BinOpNode binop)
        {
            if (binop.Op.Equals('+') || binop.Op.Equals('-'))
            {
                Complexity[Complexity.Count - 1] += 1;
            }
            if (binop.Op.Equals('/') || binop.Op.Equals('*'))
            {
                Complexity[Complexity.Count - 1] += 3;
            }
            binop.Left.Visit(this);
            binop.Right.Visit(this);
        }
        public List<int> getComplexityList()
        {
            return Complexity;
        }

     }
}
