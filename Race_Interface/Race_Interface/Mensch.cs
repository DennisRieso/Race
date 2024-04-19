using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Interface
{
    internal class Mensch : Race_Element
    {
        int     schuhgroesse;
        float   groesse;
        string  vorname;

        public Mensch (string in_name)
        {
            this.vorname = in_name;
            this.groesse = 0;
            this.schuhgroesse = 1;
        }

        public string getName()
        {
            return this.vorname;
        }

        public int getPos_x()
        {
            return (int)this.groesse;
        }

        public char getSymbol()
        {
            return 'M';
        }

        public void move()
        {
            this.groesse += this.schuhgroesse;
        }
    }
}
