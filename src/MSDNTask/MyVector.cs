using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDNTask
{
    public class MyVector
    {
        private readonly string[] strlist;

        public MyVector(string[] strlist)
        {
            this.strlist = strlist;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string t in strlist)
            {
                yield return t;
            }
            //return new MyVectorEnumerator(strlist);
        }

    }

    public class MyVectorEnumerator:IEnumerator
    {
        private readonly string[] strlist;
        private int pos;

        public MyVectorEnumerator(string[] strlist)
        {
            this.strlist = strlist;
            pos = -1;
        }

        public object Current => strlist[pos];

        public bool MoveNext()
        {
            pos++;
            return pos<strlist.Length;
        }

        public void Reset()
        {
            pos = -1;
        }
    }
}
