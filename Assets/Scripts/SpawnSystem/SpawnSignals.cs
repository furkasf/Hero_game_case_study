using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public static class SpawnSignals
    {
        public static Func<Transform> OnGetSpawnPoint;
    }
}
