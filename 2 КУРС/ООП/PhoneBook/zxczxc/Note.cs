using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxczxc
{
    public class Note
    {
        public string LastName;
        public string Name;
        public string Patronymic;
        public string Street;
        public ushort House;
        public ushort Flat;
        public string Phone;
        public static bool fl = false;
        public override bool Equals(object obj)
        {           
            Note temp = (Note)obj;
            if (Name == temp.Name && LastName == temp.LastName && Patronymic == temp.Patronymic && Street == temp.Street && House == temp.House && Flat == temp.Flat && Phone == temp.Phone) fl = true ;
            return (fl);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
