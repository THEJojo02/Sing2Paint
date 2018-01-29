using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	
	public void Starten () {
		
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
   
	}
	
}
