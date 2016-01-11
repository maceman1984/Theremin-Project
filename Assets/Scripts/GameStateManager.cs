using UnityEngine;
using System.Collections;
using Leap;

public class GameStateManager : MonoBehaviour {

	//public bool hasHands;
	//public bool hasCredits;
	public GameObject theText;

	Controller leapController = new Controller ();
	Frame leapFrame = new Frame();
	HandList leapHands = new HandList();
	Hand trackingHand = new Hand();


	void Awake()
	{
		theText.SetActive(true);
		print ("this works");
	}

	void Update() 
	{
		if (leapController.IsConnected){
			leapFrame = leapController.Frame();
			leapHands = leapFrame.Hands;

			if (!leapHands.IsEmpty)
				{
				theText.SetActive(false);
				print ("hand off");
				}
			else if(leapHands.IsEmpty)
				{
				theText.SetActive(true);
				print ("hand on");
			    }

   }	
}
}