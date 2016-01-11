using UnityEngine;
using System.Collections;

public class AudioHandle : MonoBehaviour 
{
//Public Variables

//Private Variables

void Update ()
	{
	PitchChangeX ();
	PitchChangeY ();
	}

public void PitchChangeX()
	{
	double normPosX = 0.0;
	float pitchScaleX = 0.0f; 
	float pitchMin = 1.0f;
	float pitchMax = 3.0f;
		
		if(transform.position.x >= -190 && transform.position.x <= 190)
			{
			normPosX = (transform.position.x / 380 + .5);
			}
	pitchScaleX = (float)normPosX * 3;
	GetComponent<AudioSource>().pitch = pitchScaleX;
		
		if( GetComponent<AudioSource>().pitch > pitchMin && GetComponent<AudioSource>().pitch < pitchMax)
			{
			GetComponent<AudioSource>().pitch = pitchScaleX;
			}
		}

public void PitchChangeY()
	{
	double normPosY = 0.0;
	float volumeScaleY = 0.0f; 
	float volumeMin = 0.0f;
	float volumeMax = 1.0f;
		
		if(transform.position.y >= 60 && transform.position.y <= 360)
			{
			normPosY = ((transform.position.y - 60) / 300);
			}
		
	volumeScaleY = (float)normPosY;
	GetComponent<AudioSource>().volume = volumeScaleY;
	print (GetComponent<AudioSource>().volume);
		
		if( GetComponent<AudioSource>().volume >= volumeMin && GetComponent<AudioSource>().volume <= volumeMax)
			{
			GetComponent<AudioSource>().volume = volumeScaleY;
			}
	}
}