using UnityEngine.SceneManagement;

namespace SpaceInvaders.Utils
{
    public class GameplayTracker
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}