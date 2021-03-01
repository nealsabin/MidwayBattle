using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class Character
    {
        #region Enums
        public enum HomeCountry { USA,Japan}
        #endregion

        #region Fields
        protected int _id;
        protected string _name;
        protected int _age;
        protected HomeCountry _country;
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public HomeCountry Country
        {
            get { return _country; }
            set { _country = value; }
        }
        #endregion

        public Character()
        {

        }
        public Character(string name, HomeCountry country)
        {
            _name = name;
            _country = country;
        }
    }
}
