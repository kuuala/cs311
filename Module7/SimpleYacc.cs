// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  LAPTOP-1ISHOG01
// DateTime: 11.11.2018 18:26:41
// UserName: qalanp
// Input file <SimpleYacc.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using System.IO;
using ProgramTree;

namespace SimpleParser
{
public enum Tokens {
    error=1,EOF=2,BEGIN=3,END=4,CYCLE=5,ASSIGN=6,
    ASSIGNPLUS=7,ASSIGNMINUS=8,ASSIGNMULT=9,SEMICOLON=10,WRITE=11,VAR=12,
    PLUS=13,MINUS=14,MULT=15,DIV=16,LPAREN=17,RPAREN=18,
    COLUMN=19,IF=20,THEN=21,ELSE=22,INUM=23,RNUM=24,
    ID=25};

public struct ValueType
{ 
			public double dVal; 
			public int iVal; 
			public string sVal; 
			public Node nVal;
			public ExprNode eVal;
			public StatementNode stVal;
			public BlockNode blVal;
       }
// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from SimpleYacc.y
// ��� ���������� ����������� � ����� GPPGParser, �������������� ����� ������, ������������ �������� gppg
    public BlockNode root; // �������� ���� ��������������� ������ 
    public Parser(AbstractScanner<ValueType, LexLocation> scanner) : base(scanner) { }
	private bool InDefSect = false;
  // End verbatim content from SimpleYacc.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[33];
  private static State[] states = new State[55];
  private static string[] nonTerms = new string[] {
      "progr", "expr", "ident", "T", "F", "statement", "assign", "block", "cycle", 
      "write", "empty", "var", "varlist", "if", "stlist", "$accept", "Anon@1", 
      };

  static Parser() {
    states[0] = new State(new int[]{3,4},new int[]{-1,1,-8,3});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{25,18,3,4,5,31,11,35,12,40,20,48,4,-12,10,-12},new int[]{-15,5,-6,54,-7,9,-3,10,-8,29,-9,30,-10,34,-12,39,-11,46,-14,47});
    states[5] = new State(new int[]{4,6,10,7});
    states[6] = new State(-24);
    states[7] = new State(new int[]{25,18,3,4,5,31,11,35,12,40,20,48,4,-12,10,-12},new int[]{-6,8,-7,9,-3,10,-8,29,-9,30,-10,34,-12,39,-11,46,-14,47});
    states[8] = new State(-4);
    states[9] = new State(-5);
    states[10] = new State(new int[]{6,11});
    states[11] = new State(new int[]{25,18,23,19,17,20},new int[]{-2,12,-4,28,-5,27,-3,17});
    states[12] = new State(new int[]{13,13,14,23,4,-14,10,-14,22,-14});
    states[13] = new State(new int[]{25,18,23,19,17,20},new int[]{-4,14,-5,27,-3,17});
    states[14] = new State(new int[]{15,15,16,25,13,-15,14,-15,4,-15,10,-15,22,-15,18,-15,25,-15,3,-15,5,-15,11,-15,12,-15,20,-15,21,-15});
    states[15] = new State(new int[]{25,18,23,19,17,20},new int[]{-5,16,-3,17});
    states[16] = new State(-18);
    states[17] = new State(-21);
    states[18] = new State(-13);
    states[19] = new State(-22);
    states[20] = new State(new int[]{25,18,23,19,17,20},new int[]{-2,21,-4,28,-5,27,-3,17});
    states[21] = new State(new int[]{18,22,13,13,14,23});
    states[22] = new State(-23);
    states[23] = new State(new int[]{25,18,23,19,17,20},new int[]{-4,24,-5,27,-3,17});
    states[24] = new State(new int[]{15,15,16,25,13,-16,14,-16,4,-16,10,-16,22,-16,18,-16,25,-16,3,-16,5,-16,11,-16,12,-16,20,-16,21,-16});
    states[25] = new State(new int[]{25,18,23,19,17,20},new int[]{-5,26,-3,17});
    states[26] = new State(-19);
    states[27] = new State(-20);
    states[28] = new State(new int[]{15,15,16,25,13,-17,14,-17,4,-17,10,-17,22,-17,18,-17,25,-17,3,-17,5,-17,11,-17,12,-17,20,-17,21,-17});
    states[29] = new State(-6);
    states[30] = new State(-7);
    states[31] = new State(new int[]{25,18,23,19,17,20},new int[]{-2,32,-4,28,-5,27,-3,17});
    states[32] = new State(new int[]{13,13,14,23,25,18,3,4,5,31,11,35,12,40,20,48,4,-12,10,-12,22,-12},new int[]{-6,33,-7,9,-3,10,-8,29,-9,30,-10,34,-12,39,-11,46,-14,47});
    states[33] = new State(-25);
    states[34] = new State(-8);
    states[35] = new State(new int[]{17,36});
    states[36] = new State(new int[]{25,18,23,19,17,20},new int[]{-2,37,-4,28,-5,27,-3,17});
    states[37] = new State(new int[]{18,38,13,13,14,23});
    states[38] = new State(-26);
    states[39] = new State(-9);
    states[40] = new State(-27,new int[]{-17,41});
    states[41] = new State(new int[]{25,18},new int[]{-13,42,-3,45});
    states[42] = new State(new int[]{19,43,4,-28,10,-28,22,-28});
    states[43] = new State(new int[]{25,18},new int[]{-3,44});
    states[44] = new State(-30);
    states[45] = new State(-29);
    states[46] = new State(-10);
    states[47] = new State(-11);
    states[48] = new State(new int[]{25,18,23,19,17,20},new int[]{-2,49,-4,28,-5,27,-3,17});
    states[49] = new State(new int[]{21,50,13,13,14,23});
    states[50] = new State(new int[]{25,18,3,4,5,31,11,35,12,40,20,48,4,-12,10,-12,22,-12},new int[]{-6,51,-7,9,-3,10,-8,29,-9,30,-10,34,-12,39,-11,46,-14,47});
    states[51] = new State(new int[]{22,52,4,-32,10,-32});
    states[52] = new State(new int[]{25,18,3,4,5,31,11,35,12,40,20,48,4,-12,10,-12,22,-12},new int[]{-6,53,-7,9,-3,10,-8,29,-9,30,-10,34,-12,39,-11,46,-14,47});
    states[53] = new State(-31);
    states[54] = new State(-3);

    rules[1] = new Rule(-16, new int[]{-1,2});
    rules[2] = new Rule(-1, new int[]{-8});
    rules[3] = new Rule(-15, new int[]{-6});
    rules[4] = new Rule(-15, new int[]{-15,10,-6});
    rules[5] = new Rule(-6, new int[]{-7});
    rules[6] = new Rule(-6, new int[]{-8});
    rules[7] = new Rule(-6, new int[]{-9});
    rules[8] = new Rule(-6, new int[]{-10});
    rules[9] = new Rule(-6, new int[]{-12});
    rules[10] = new Rule(-6, new int[]{-11});
    rules[11] = new Rule(-6, new int[]{-14});
    rules[12] = new Rule(-11, new int[]{});
    rules[13] = new Rule(-3, new int[]{25});
    rules[14] = new Rule(-7, new int[]{-3,6,-2});
    rules[15] = new Rule(-2, new int[]{-2,13,-4});
    rules[16] = new Rule(-2, new int[]{-2,14,-4});
    rules[17] = new Rule(-2, new int[]{-4});
    rules[18] = new Rule(-4, new int[]{-4,15,-5});
    rules[19] = new Rule(-4, new int[]{-4,16,-5});
    rules[20] = new Rule(-4, new int[]{-5});
    rules[21] = new Rule(-5, new int[]{-3});
    rules[22] = new Rule(-5, new int[]{23});
    rules[23] = new Rule(-5, new int[]{17,-2,18});
    rules[24] = new Rule(-8, new int[]{3,-15,4});
    rules[25] = new Rule(-9, new int[]{5,-2,-6});
    rules[26] = new Rule(-10, new int[]{11,17,-2,18});
    rules[27] = new Rule(-17, new int[]{});
    rules[28] = new Rule(-12, new int[]{12,-17,-13});
    rules[29] = new Rule(-13, new int[]{-3});
    rules[30] = new Rule(-13, new int[]{-13,19,-3});
    rules[31] = new Rule(-14, new int[]{20,-2,21,-6,22,-6});
    rules[32] = new Rule(-14, new int[]{20,-2,21,-6});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
    switch (action)
    {
      case 2: // progr -> block
{ root = ValueStack[ValueStack.Depth-1].blVal; }
        break;
      case 3: // stlist -> statement
{ 
				CurrentSemanticValue.blVal = new BlockNode(ValueStack[ValueStack.Depth-1].stVal); 
			}
        break;
      case 4: // stlist -> stlist, SEMICOLON, statement
{ 
				ValueStack[ValueStack.Depth-3].blVal.Add(ValueStack[ValueStack.Depth-1].stVal); 
				CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-3].blVal; 
			}
        break;
      case 5: // statement -> assign
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 6: // statement -> block
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].blVal; }
        break;
      case 7: // statement -> cycle
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 8: // statement -> write
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 9: // statement -> var
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 10: // statement -> empty
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 11: // statement -> if
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 12: // empty -> /* empty */
{ CurrentSemanticValue.stVal = new EmptyNode(); }
        break;
      case 13: // ident -> ID
{
			if (!InDefSect)
				if (!SymbolTable.vars.ContainsKey(ValueStack[ValueStack.Depth-1].sVal))
					throw new Exception("("+LocationStack[LocationStack.Depth-1].StartLine+","+LocationStack[LocationStack.Depth-1].StartColumn+"): ���������� "+ValueStack[ValueStack.Depth-1].sVal+" �� �������");
			CurrentSemanticValue.eVal = new IdNode(ValueStack[ValueStack.Depth-1].sVal); 
		}
        break;
      case 14: // assign -> ident, ASSIGN, expr
{ CurrentSemanticValue.stVal = new AssignNode(ValueStack[ValueStack.Depth-3].eVal as IdNode, ValueStack[ValueStack.Depth-1].eVal); }
        break;
      case 15: // expr -> expr, PLUS, T
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'+'); }
        break;
      case 16: // expr -> expr, MINUS, T
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'-'); }
        break;
      case 17: // expr -> T
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 18: // T -> T, MULT, F
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'*'); }
        break;
      case 19: // T -> T, DIV, F
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal,ValueStack[ValueStack.Depth-1].eVal,'/'); }
        break;
      case 20: // T -> F
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 21: // F -> ident
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal as IdNode; }
        break;
      case 22: // F -> INUM
{ CurrentSemanticValue.eVal = new IntNumNode(ValueStack[ValueStack.Depth-1].iVal); }
        break;
      case 23: // F -> LPAREN, expr, RPAREN
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-2].eVal; }
        break;
      case 24: // block -> BEGIN, stlist, END
{ CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-2].blVal; }
        break;
      case 25: // cycle -> CYCLE, expr, statement
{ CurrentSemanticValue.stVal = new CycleNode(ValueStack[ValueStack.Depth-2].eVal,ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 26: // write -> WRITE, LPAREN, expr, RPAREN
{ CurrentSemanticValue.stVal = new WriteNode(ValueStack[ValueStack.Depth-2].eVal); }
        break;
      case 27: // Anon@1 -> /* empty */
{ InDefSect = true; }
        break;
      case 28: // var -> VAR, Anon@1, varlist
{ 
			foreach (var v in (ValueStack[ValueStack.Depth-1].stVal as VarDefNode).vars)
				SymbolTable.NewVarDef(v.Name, type.tint);
			InDefSect = false;	
		}
        break;
      case 29: // varlist -> ident
{ 
			CurrentSemanticValue.stVal = new VarDefNode(ValueStack[ValueStack.Depth-1].eVal as IdNode); 
		}
        break;
      case 30: // varlist -> varlist, COLUMN, ident
{ 
			(ValueStack[ValueStack.Depth-3].stVal as VarDefNode).Add(ValueStack[ValueStack.Depth-1].eVal as IdNode);
			CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-3].stVal;
		}
        break;
      case 31: // if -> IF, expr, THEN, statement, ELSE, statement
{ CurrentSemanticValue.stVal = new IfNode(ValueStack[ValueStack.Depth-5].eVal, ValueStack[ValueStack.Depth-3].stVal, ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 32: // if -> IF, expr, THEN, statement
{ CurrentSemanticValue.stVal = new IfNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].stVal); }
        break;
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }


}
}
