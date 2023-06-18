using UnityEngine;

namespace NatureRendererDemo
{
    public class OpenWebsiteButton : MonoBehaviour
    {
        public void OnButtonClicked()
        {
            Application.OpenURL(
                "https://v3.visualdesigncafe.com/nature-renderer/start"
                    + "?utm_source=unity-editor"
                    + "&utm_medium=referral"
                    + "&utm_campaign=nature-renderer-2021-demo-scene" );
        }
    }
}
