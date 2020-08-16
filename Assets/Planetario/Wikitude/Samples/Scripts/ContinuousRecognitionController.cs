using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class ContinuousRecognitionController : SampleController
{
    public ImageTracker Tracker;
    public Text buttonText;
    private bool _trackerRunning = false;
    private bool _connectionInitialized = false;

    private double _recognitionInterval = 1.5;

    #region UI Events
    public void OnToggleClicked() {
        /* Toggle continuous cloud recognition on or off. */
        _trackerRunning = !_trackerRunning;
        ToggleContinuousCloudRecognition(_trackerRunning);
    }
    #endregion

    #region Tracker Events
    public void OnInitialized() {
        base.OnTargetsLoaded();
        _connectionInitialized = true;
    }

    public void OnInitializationError(Error error) {
        PrintError("Error initializing cloud connection!", error);
    }

    public void OnRecognitionResponse(CloudRecognitionServiceResponse response) {
        if (response.Recognized) {
            /* If the cloud recognized a target, we stop continuous recognition and track that target locally. */
            ToggleContinuousCloudRecognition(false);
        }
    }

    public void OnInterruption(double suggestedInterval) {
        /* If recognition was interrupted, try to start it again using the suggested interval. */
        _recognitionInterval = suggestedInterval;
        Tracker.CloudRecognitionService.StartContinuousRecognition(_recognitionInterval);
    }
    #endregion

    private void ToggleContinuousCloudRecognition(bool enabled) {
        if (Tracker != null && _connectionInitialized) {
            if (enabled) {
                buttonText.text = "Scanning";
                Tracker.CloudRecognitionService.StartContinuousRecognition(_recognitionInterval);
            } else {
                buttonText.text = "Press to start scanning";
                Tracker.CloudRecognitionService.StopContinuousRecognition();
            }
            _trackerRunning = enabled;
        }
    }

    public void OnRecognitionError(Error error) {
        PrintError("Recognition error!", error);
    }
}
