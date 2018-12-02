using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    public class Scene
    {
        public string Name;

        internal List<GameObject> _gameObjects = new List<GameObject>();
        internal Behaviour[] _behaviours;

        public Scene(string name)
        {
            Name = name;
        }

        internal Behaviour internalFindBehaviour(Type type)
        {
            var tempList = _behaviours.ToList();
            return tempList.Find(x => x.GetType() == type);
        }

        internal void internalAddBehaviour(Behaviour behaviour)
        {
            var temp = new Behaviour[_behaviours.Length + 1];
            temp[temp.Length] = behaviour;
            _behaviours = temp;
        }
    }
}
