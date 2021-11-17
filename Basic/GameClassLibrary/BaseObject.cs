using System;

namespace GameClassLibrary
{
    internal class BaseObject
    {
        protected int _id;
        protected string _name;
        protected string _icon;

        protected BaseObject(int id, string name, string icon)
        {
            _id = id;
            _name = name;
            _icon = icon;
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Icon { get { return _icon; } }
    }
}
