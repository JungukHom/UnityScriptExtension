namespace developer0223.Utilities
{
    // Unity
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public partial class Utility // .Scene
    {
        public static void LoadScene(int sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static string GetActiveSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}