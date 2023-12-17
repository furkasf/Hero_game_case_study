using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public abstract class Spawner : MonoBehaviour
    {
        public virtual void Spawn() { }
    }
}
