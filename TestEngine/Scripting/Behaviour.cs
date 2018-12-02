using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    public abstract class Behaviour : Component
    {
        public Behaviour()
        {
            Engine.CurrentScene.internalAddBehaviour(this);
            Name = typeof(Behaviour).Name;
            Awake();
        }

        public virtual void Start()
        {

        }

        public virtual void Awake()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Update()
        {

        }
    }
}
