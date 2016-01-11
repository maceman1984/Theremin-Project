using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{

//Public Variables
public float playerSpeedVertical 		= 10.0f;  														//Offers designer a modifiable vertical speed
public float playerSpeedHorizontal 		= 10.0f;  														//Offers designer a modifiable horizontal speed
public float horMin 					= -5.75f;														//Offers designer a modifiable horizontal left movement limit
public float horMax 					= 5.75f;														//Offers designer a modifiable horizontal right movement limit
public float verMin						= -2.5f;														//Offers designer a modifiable horizontal down movement limit
public float verMax						= 2.5f;															//Offers designer a modifiable horizontal up movement limit
	
//Private Variables

void  Update ()
	{
	//stores input variables from project input settings
	float transV = Input.GetAxis ("Vertical") * playerSpeedVertical * Time.deltaTime;			//used to store variable for vertical movement
	float transH = Input.GetAxis ("Horizontal") * playerSpeedHorizontal * Time.deltaTime;		//used to store variable for horizontal movement
		
	//moves player based on stored input
	transform.Translate (transH, transV, 0);		
		
	//create on-screen movement boundry limits for player
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, horMin, horMax);
		pos.y = Mathf.Clamp(pos.y, verMin, verMax);
		transform.position = pos;
	}
}