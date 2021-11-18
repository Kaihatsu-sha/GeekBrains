using System;

namespace GameClassLibrary
{
    public class BaseObject
    {
        public delegate void OnNotify(string name, string message);

        private static int _globalId = 0;
        protected int _id;
        protected string _name;
        protected string _icon;
        protected OnNotify _notify;

        protected BaseObject(string name, string icon)
        {
            _id = _globalId++;
            _name = name;
            _icon = icon;
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Icon { get { return _icon; } }
        public OnNotify Notify { set { _notify = value; } }
    }
}
