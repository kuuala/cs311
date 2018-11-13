using System.Collections.Generic;
using System.Net.Sockets;
using System.Xml.Serialization;

namespace ProgramTree
{
    public enum AssignType { Assign, AssignPlus, AssignMinus, AssignMult, AssignDivide };

    public class Node // базовый класс для всех узлов    
    {
    }

    public class ExprNode : Node // базовый класс для всех выражений
    {
    }

    public class IdNode : ExprNode
    {
        public string Name { get; set; }
        public IdNode(string name) { Name = name; }
    }

    public class IntNumNode : ExprNode
    {
        public int Num { get; set; }
        public IntNumNode(int num) { Num = num; }
    }

    public class StatementNode : Node // базовый класс для всех операторов
    {
    }

    public class AssignNode : StatementNode
    {
        public IdNode Id { get; set; }
        public ExprNode Expr { get; set; }
        public AssignType AssOp { get; set; }
        public AssignNode(IdNode id, ExprNode expr, AssignType assop = AssignType.Assign)
        {
            Id = id;
            Expr = expr;
            AssOp = assop;
        }
    }

    public class CycleNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Stat { get; set; }
        public CycleNode(ExprNode expr, StatementNode stat)
        {
            Expr = expr;
            Stat = stat;
        }
    }

    public class WhileNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Stat { get; set; }
        public WhileNode(ExprNode expr, StatementNode stat)
        {
            Expr = expr;
            Stat = stat;
        }
    }

    public class RepeatNode : StatementNode
    {
        public BlockNode StList { get; set; }
        public ExprNode Expr { get; set; }
        public RepeatNode(BlockNode stat, ExprNode exp)
        {
            StList = stat;
            Expr = exp;
        }
    }

    public class ForNode : StatementNode
    {
        public IdNode Id { get; set; }
        public ExprNode IdExpr { get; set; }
        public ExprNode ToExpr { get; set; }
        public StatementNode Stat { get; set; }
        public ForNode(IdNode id, ExprNode idExpr, ExprNode toExpr, StatementNode stat)
        {
            Id = id;
            IdExpr = idExpr;
            ToExpr = toExpr;
            Stat = stat;
        }
    }

    public class WriteNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public WriteNode(ExprNode expr)
        {
            Expr = expr;
        }
    }

    public class IfNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode StateTrue { get; set; }
        public StatementNode StateFalse { get; set; }
        public IfNode(ExprNode expr, StatementNode stateTrue, StatementNode stateFalse)
        {
            Expr = expr;
            StateTrue = stateTrue;
            StateFalse = stateFalse;
        }
        public IfNode(ExprNode expr, StatementNode state)
        {
            Expr = expr;
            StateTrue = state;
        }
    }
    
    public class VarDefNode : StatementNode
    {
        public List<IdNode> Ids = new List<IdNode>();
        public VarDefNode(IdNode ids)
        {
            Add(ids);
        }
        public void Add(IdNode ids)
        {
            Ids.Add(ids);   
        }
    }

    public class BinaryNode : ExprNode
    {
        public ExprNode Left { get; set; }
        public ExprNode Right { get; set; }
        public char Operation { get; set; }
        public BinaryNode(ExprNode left, ExprNode right, char operation)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }
    }
    
    public class BlockNode : StatementNode
    {
        public List<StatementNode> StList = new List<StatementNode>();
        public BlockNode(StatementNode stat)
        {
            Add(stat);
        }
        public void Add(StatementNode stat)
        {
            StList.Add(stat);
        }
    }

}