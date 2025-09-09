using MelonLoader;
using UnityEngine;

namespace Insomia
{
    public class InsomiaMod : MelonMod
    {
        private static bool guiDisabled = false;
        private static Canvas[] canvases;

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("made 4 censored");
        }

        public override void OnUpdate()
        {
            // Initialize canvas cache once
            if (canvases == null || canvases.Length == 0)
            {
                canvases = UnityEngine.Object.FindObjectsOfType<Canvas>();
            }

            // Toggle on key down (not every frame the key is held)
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                guiDisabled = !guiDisabled;
                ToggleGUI(guiDisabled);
            }
        }

        void ToggleGUI(bool disable)
        {
            foreach (Canvas canvas in canvases)
            {
                if (canvas != null)
                {
                    canvas.gameObject.SetActive(!disable);
                }
            }
        }
    }
}
