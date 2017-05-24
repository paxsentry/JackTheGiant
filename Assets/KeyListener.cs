using UnityEngine;

public class KeyListener : MonoBehaviour {
	void Update () {
        if (Input.GetKeyDown("Enter"))
        {
            Debug.Log("Enter pressed");
        }
	}
}
