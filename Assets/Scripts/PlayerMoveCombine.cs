using UnityEngine;
using System.Collections;

public class PlayerMoveCombine : MonoBehaviour 
{	
	//Public Variables
	public float playerSpeedVertical 		= 10.0f;  														//Offers designer a modifiable vertical speed
	public float playerSpeedHorizontal 		= 10.0f;  														//Offers designer a modifiable horizontal speed

	public float pitchScaleX 				= 0.0f; 
	public float pitchMin 					= 1.0f;
	public float pitchMax 					= 3.0f;

	public float volumeScaleY 				= 0.0f; 
	public float volumeMin 					= 0.0f;
	public float volumeMax 					= 1.0f;
	
	public GameObject myParticleSystem;
			
	//Private Variables
		
	void Update ()
	{
		//stores input variables from project input settings
		float transV = Input.GetAxis ("Vertical") * playerSpeedVertical * Time.deltaTime;
		float transH = Input.GetAxis ("Horizontal") * playerSpeedHorizontal * Time.deltaTime;

		//moves player based on stored input
		transform.Translate (transH, transV, 0);
			
		//create on-screen movement boundry limits for player
		PitchChange ();
	}

	public void PitchChange () 
	{
		PitchChangeX ();
		PitchChangeY ();
	}
		
	public void PitchChangeX()
	{
		double normPosX = 0.0;
		print (transform.position.x);
		if(transform.position.x >= -10 && transform.position.x <= 10)
		{
			normPosX = (transform.position.x / 20 + .5);
			myParticleSystem.active = true;
		}
		if (transform.position.x < -10 || transform.position.x > 10)
		{
			myParticleSystem.active = false;
		}

		pitchScaleX = (float)normPosX * 3;
		GetComponent<AudioSource>().pitch = pitchScaleX;
			
		if( GetComponent<AudioSource>().pitch >= pitchMin && GetComponent<AudioSource>().pitch <= pitchMax)
		{
			GetComponent<AudioSource>().pitch = pitchScaleX;
		}
	}

	public void PitchChangeY()
	{
		double normPosY = 0.0;
		
		if(transform.position.y >= -4.5 && transform.position.y <= 4.5)
		{
			normPosY = (transform.position.y / 9 + .5);
			myParticleSystem.active = true;
		}
		
		if (transform.position.y < -4.5 || transform.position.y > 4.5) 
		{
			myParticleSystem.active = false;
		}
		
		
		volumeScaleY = (float)normPosY;
		GetComponent<AudioSource>().volume = volumeScaleY;
		
		if( GetComponent<AudioSource>().volume >= volumeMin && GetComponent<AudioSource>().volume <= volumeMax)
		{
			GetComponent<AudioSource>().volume = volumeScaleY;
		}
	}


	IEnumerator CreateWait(float waitTime)
	{
		print ("now");
		yield return new WaitForSeconds(waitTime);
	}
	

}