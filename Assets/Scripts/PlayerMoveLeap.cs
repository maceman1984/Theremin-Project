using UnityEngine;
using System.Collections;
using Leap;
[RequireComponent(typeof(ParticleSystem))]
public class PlayerMoveLeap : MonoBehaviour {

	public double normHandX = 0.0;
	public float pitchScaleX = 0.0f; 
	public float pitchMin = 1.0f;
	public float pitchMax = 3.0f;

	public double normHandY = 0.0;
	public float volumeScaleY = 0.0f; 
	public float volumeMin = 0.0f;
	public float volumeMax = 1.0f;

	ParticleSystem[] myParticleSystem;
	ParticleSystem.Particle[] myParticles;

	public GameObject effect;

	public Color startColor;

	Controller leapController = new Controller ();
	Frame leapFrame = new Frame();
	HandList leapHands = new HandList();
	Hand trackingHand = new Hand();
	//Listener leapListener = new Listener();
	
	// Use this for initialization
	void Start () 
	{
		myParticleSystem = gameObject.GetComponentsInChildren<ParticleSystem> ();
		//myParticleSystem.particleSystem.startColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (leapController.IsConnected){
			leapFrame = leapController.Frame();
			leapHands = leapFrame.Hands;
			if (!leapHands.IsEmpty){
				trackingHand = leapHands.Frontmost;
			}
			//print ("Tracking Hand X: " + trackingHand.PalmPosition.x);
			//print ("Tracking Hand Y: " + trackingHand.PalmPosition.y);
		}

		PitchChange();
		ColorChange ();

	}
	// n*r
	// 1-n * b
	public void PitchChange()
	{

		if(trackingHand.PalmPosition.x >= -190 && trackingHand.PalmPosition.x <= 190)
		{
			normHandX = (trackingHand.PalmPosition.x / 380 + .5);
		}
		pitchScaleX = (float)normHandX * 3;
		GetComponent<AudioSource>().pitch = pitchScaleX;
		
		if( GetComponent<AudioSource>().pitch > pitchMin && GetComponent<AudioSource>().pitch < pitchMax)
		{
			GetComponent<AudioSource>().pitch = pitchScaleX;
		}

		if(trackingHand.PalmPosition.y >= 60 && trackingHand.PalmPosition.y <= 360)
		{
			normHandY = ((trackingHand.PalmPosition.y - 60) / 300);
		}
		
		volumeScaleY = (float)normHandY;
		GetComponent<AudioSource>().volume = volumeScaleY;
		
		if( GetComponent<AudioSource>().volume >= volumeMin && GetComponent<AudioSource>().volume <= volumeMax)
		{
			GetComponent<AudioSource>().volume = volumeScaleY;
		}
	} 

	public void ColorChange()
	{
		if(trackingHand.PalmPosition.x >= -190 && trackingHand.PalmPosition.x <= 190)
		{
			normHandX = (trackingHand.PalmPosition.x / 380 + .5);
			myParticles = new ParticleSystem.Particle[15];
			int particlesAlive = myParticleSystem[0].GetParticles(myParticles);
			//print (particlesAlive);
			Color colorChange = new Vector4((float)normHandX , 0, (1 - (float)normHandX) , 1);
			for (int i = 0; i < particlesAlive; i++){
				//print (colorChange);
				myParticles[i].color = colorChange;
			}
			myParticleSystem[0].SetParticles(myParticles, particlesAlive);
		}
	}
		
}


	


