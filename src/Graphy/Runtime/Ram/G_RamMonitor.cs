﻿/* ---------------------------------------
 * Author:          Martin Pane (martintayx@gmail.com) (@tayx94)
 * Contributors:    https://github.com/Tayx94/graphy/graphs/contributors
 * Project:         Graphy - Ultimate Stats Monitor
 * Date:            15-Dec-17
 * Studio:          Tayx
 *
 * Git repo:        https://github.com/Tayx94/graphy
 *
 * This project is released under the MIT license.
 * Attribution is not required, but it is always welcomed!
 * -------------------------------------*/

using UnityEngine;
using UnityEngine.Profiling;

#if UNITY_5_5_OR_NEWER

#endif

namespace Appalachia.Utility.Overlays.Graphy.Ram
{
    public class G_RamMonitor : MonoBehaviour
    {
#region Methods -> Unity Callbacks

        private void Update()
        {
            AllocatedRam = Profiler.GetTotalAllocatedMemoryLong() / 1048576f;
            ReservedRam = Profiler.GetTotalReservedMemoryLong() / 1048576f;
            MonoRam = Profiler.GetMonoUsedSizeLong() / 1048576f;
        }

#endregion

#region Properties -> Public

        public float AllocatedRam { get; private set; }
        public float ReservedRam { get; private set; }
        public float MonoRam { get; private set; }

#endregion
    }
}
