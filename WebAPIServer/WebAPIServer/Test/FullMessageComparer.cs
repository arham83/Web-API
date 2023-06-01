using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServer.MessageStructure;

namespace WebAPIServer.Test
{
    public class Comparer 
    {
        public bool CompareFM(FullMessage x, FullMessage y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x is null || y is null)
                return false;

            if (x.Header.Count != y.Header.Count || x.Rows.Count != y.Rows.Count)
                return false;
            
            for (int i = 0; i < x.Header.Count; i++)
            {
                if (x.Header[i].Name != y.Header[i].Name)
                    return false;
                if (x.Header[i].Type != y.Header[i].Type)
                    return false;
                if (x.Header[i].IsList != y.Header[i].IsList)
                    return false;
                if (x.Header[i].IsNullable != y.Header[i].IsNullable)
                    return false;
                if (x.Header[i].Format != y.Header[i].Format)
                    return false;
                if (x.Header[i].Aggregation != y.Header[i].Aggregation)
                    return false;
                if (x.Header[i].Labels != y.Header[i].Labels)
                    return false;
            }
            
            for (int i = 0; i < x.Rows.Count; i++)
            {
                if (!x.Rows[i].SequenceEqual(y.Rows[i]))
                    return false;
            }
            
            return true;
        }

        public bool CompareOM(OptimizedMessage x, OptimizedMessage y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x is null || y is null)
                return false;

            if (x.Header.Count != y.Header.Count || x.Rowdata != y.Rowdata)
                return false;

            for (int i = 0; i < x.Header.Count; i++)
            {
                if (x.Header[i].Name != y.Header[i].Name)
                    return false;
                if (x.Header[i].Type != y.Header[i].Type)
                    return false;
                if (x.Header[i].IsList != y.Header[i].IsList)
                    return false;
                if (x.Header[i].IsNullable != y.Header[i].IsNullable)
                    return false;
                if (x.Header[i].Format != y.Header[i].Format)
                    return false;
                if (x.Header[i].Aggregation != y.Header[i].Aggregation)
                    return false;
                if (x.Header[i].Labels != y.Header[i].Labels)
                    return false;
            }

            return true;
        }
    }

   
}
