﻿using System;
using System.Collections.Generic;
using System.Text;
using SimpleLexer;
namespace SimpleLangParser
{
    public class ParserException : System.Exception
    {
        public ParserException(string msg)
            : base(msg)
        {
        }

    }

    public class Parser
    {
        private SimpleLexer.Lexer l;

        public Parser(SimpleLexer.Lexer lexer)
        {
            l = lexer;
        }

        public void Progr()
        {
            Block();
        }

        public void A()
        {
            if (l.LexKind == Tok.PLUS || l.LexKind == Tok.MINUS)
            {
                l.NextLexem();
                T();
                A();
            }
        }

        public void T()
        {
            M();
            B();
        }

        public void B()
        {
            if (l.LexKind == Tok.DIVISION || l.LexKind == Tok.MULT)
            {
                l.NextLexem();
                M();
                B();
            }
        }

        public void M()
        {
            switch (l.LexKind)
            {
                case Tok.ID:
                    l.NextLexem();
                    break;
                case Tok.INUM:
                    l.NextLexem();
                    break;
                case Tok.LEFT_BRACKET:
                {
                    l.NextLexem();
                    Expr();
                    if (l.LexKind != Tok.RIGHT_BRACKET)
                    {
                        SyntaxError(") excepted");
                    }
                    else
                    {
                        l.NextLexem();
                    }
                    break;
                }
                default:
                    SyntaxError("ID or INUM or ( excepted");
                    break;
            }
        }
        
        public void Expr()
        {
            T();
            A();
        }

        public void Assign() 
        {
            l.NextLexem();  // пропуск id
            if (l.LexKind == Tok.ASSIGN)
            {
                l.NextLexem();
            }
            else {
                SyntaxError(":= expected");
            }
            Expr();
        }

        public void StatementList() 
        {
            Statement();
            while (l.LexKind == Tok.SEMICOLON)
            {
                l.NextLexem();
                Statement();
            }
        }

        public void Statement() 
        {
            switch (l.LexKind)
            {
                case Tok.BEGIN:
                    {
                        Block(); 
                        break;
                    }
                case Tok.CYCLE:
                    {
                        Cycle(); 
                        break;
                    }
                case Tok.ID:
                    {
                        Assign();
                        break;
                    }
                case Tok.WHILE:
                    {
                        WhileDo();
                        break;
                    }
                case Tok.FOR:
                    {
                        ForToDo();
                        break;
                    }
                case Tok.IF:
                    {
                        IfThenElse();
                        break;
                    }
                default:
                    {
                        SyntaxError("Operator expected");
                        break;
                    }
            }
        }

        public void Block() 
        {
            l.NextLexem();    // пропуск begin
            StatementList();
            if (l.LexKind == Tok.END)
            {
                l.NextLexem();
            }
            else
            {
                SyntaxError("end expected");
            }

        }

        public void Cycle() 
        {
            l.NextLexem();  // пропуск cycle
            Expr();
            Statement();
        }

        public void WhileDo()
        {
            l.NextLexem();
            Expr();
            l.NextLexem();
            Statement();
        }

        public void ForToDo()
        {
            l.NextLexem();
            Assign();
            if (l.LexKind == Tok.TO)
            {
                l.NextLexem();
                Expr();
                if (l.LexKind == Tok.DO)
                {
                    l.NextLexem();
                    Statement();
                }
                else
                {
                    SyntaxError("do excepted");
                }
            }
            else
            {
                SyntaxError("to excepted");
            }
        }

        public void IfThenElse()
        {
            l.NextLexem();
            Expr();
            if (l.LexKind == Tok.THEN)
            {
                l.NextLexem();
                Statement();
                if (l.LexKind == Tok.ELSE)
                {
                    l.NextLexem();
                    Statement();
                }
            }
            else
            {
                SyntaxError("then excepted");
            }
        }
        
        public void SyntaxError(string message) 
        {
            var errorMessage = "Syntax error in line " + l.LexRow.ToString() + ":\n";
            errorMessage += l.FinishCurrentLine() + "\n";
            errorMessage += new String(' ', l.LexCol - 1) + "^\n";
            if (message != "")
            {
                errorMessage += message;
            }
            throw new ParserException(errorMessage);
        }
   
    }
}
