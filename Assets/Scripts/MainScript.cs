using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class MainScript : MonoBehaviour
{
	public string UNITY_AD_ID;

	void Awake()
	{
		if (Advertisement.isSupported)
		{
			Advertisement.Initialize(UNITY_AD_ID);
		}
		else
		{
			Debug.Log("Platform not supported");
		}
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(10, 10, 150, 50), Advertisement.IsReady() ? "Show Ad" : "Waiting..."))
		{
			// Show with default zone, pause engine and print result to debug log
			Advertisement.Show(
				null,
				new ShowOptions {
					resultCallback = result => {
						Debug.Log(result.ToString());
					}
				}
			);
		}
		
		GUI.Label(
			new Rect(10, 160, 200, 150), Application.bundleIdentifier + "\n" + Application.version);

	}
}
