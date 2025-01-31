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

using Appalachia.Utility.Overlays.Graphy.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Appalachia.Utility.Overlays.Graphy.Audio
{
    public class G_AudioText : MonoBehaviour
    {
#region Variables -> Serialized Private

        [SerializeField] private Text m_DBText;

#endregion

#region Methods -> Public

        public void UpdateParameters()
        {
            m_updateRate = m_graphyManager.AudioTextUpdateRate;
        }

#endregion

#region Methods -> Private

        private void Init()
        {
            G_IntString.Init(-80, 0); // dB range

            m_graphyManager = transform.root.GetComponentInChildren<GraphyManager>();

            m_audioMonitor = GetComponent<G_AudioMonitor>();

            UpdateParameters();
        }

#endregion

#region Variables -> Private

        private GraphyManager m_graphyManager;

        private G_AudioMonitor m_audioMonitor;

        private int m_updateRate = 4;

        private float m_deltaTimeOffset;

#endregion

#region Methods -> Unity Callbacks

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            if (m_audioMonitor.SpectrumDataAvailable)
            {
                if (m_deltaTimeOffset > (1f / m_updateRate))
                {
                    m_deltaTimeOffset = 0f;

                    m_DBText.text = Mathf.Clamp((int) m_audioMonitor.MaxDB, -80, 0)
                                         .ToStringNonAlloc();
                }
                else
                {
                    m_deltaTimeOffset += Time.deltaTime;
                }
            }
        }

#endregion
    }
}
