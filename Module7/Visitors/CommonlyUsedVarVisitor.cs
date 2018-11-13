using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class CommonlyUsedVarVisitor : AutoVisitor
    {
        public Dictionary<string, int> va = new Dictionary<string, int>();
        public override void VisitVarDefNode(VarDefNode w)
        {
            foreach (var v in w.vars)
            {
                va.Add(v.Name, 0);
                v.Visit(this);
            }
        }
        public override void VisitIdNode(IdNode id)
        {
            va[id.Name] += 1;
        }
        public string mostCommonlyUsedVar()
        {
            return va.FirstOrDefault(x => x.Value.Equals(va.Values.Max())).Key;
        }
    }
}
