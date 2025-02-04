using System.Threading.Tasks;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private async void Start()
    {
        await StartLevelTimer(10);

        EndLevel();
    }

    private async Task StartLevelTimer(int seconds)
    {
        // Start the timer when the level is started
        var tcs = new TaskCompletionSource<bool>();
        Invoke(nameof(CompleteTimer), seconds);
        await tcs.Task;
    }

    private void CompleteTimer()
    {
        // tcs.SetResult(true);
    }

    private void EndLevel() 
    {
        Debug.Log("Time Limit Reached!");
    }
}
