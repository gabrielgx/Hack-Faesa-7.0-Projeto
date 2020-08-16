using UnityEngine;
using System.Collections;

public class Painel : MonoBehaviour {

	private bool AtivaOrbita = true;
	public static bool AtivaMouseOver = true;
	public static bool AtivaMouseDown = true;
	public static bool Reset = false;
	public static bool ZeraTranslacao = false;
	public static bool MenuAtivo = false;

	public float TerraSpeed;
	public float JupiterSpeed;
	public float MarteSpeed;
	public float MercurioSpeed;
	public float NetunoSpeed;
	public float SaturnoSpeed;
	public float UranoSpeed;
	public float VenusSpeed;
	// Use this for initialization
	void Start () {
		
			Terra.speedTranslacao = TerraSpeed;
			Jupiter.speedTranslacao = JupiterSpeed;
			Marte.speedTranslacao = MarteSpeed;
			Mercurio.speedTranslacao = MercurioSpeed;
			Netuno.speedTranslacao = NetunoSpeed;
			Saturno.speedTranslacao = SaturnoSpeed;
			Urano.speedTranslacao = UranoSpeed;
			Venus.speedTranslacao = VenusSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Reset == true) 
		
		{
			Terra.speedTranslacao = TerraSpeed;
			Jupiter.speedTranslacao = JupiterSpeed;
			Marte.speedTranslacao = MarteSpeed;
			Mercurio.speedTranslacao = MercurioSpeed;
			Netuno.speedTranslacao = NetunoSpeed;
			Saturno.speedTranslacao = SaturnoSpeed;
			Urano.speedTranslacao = UranoSpeed;
			Venus.speedTranslacao = VenusSpeed;

			Reset = false;
		}

		if (ZeraTranslacao == true)
		
		{
			Terra.speedTranslacao = 0;
			Jupiter.speedTranslacao = 0;
			Marte.speedTranslacao = 0;
			Mercurio.speedTranslacao = 0;
			Netuno.speedTranslacao = 0;
			Saturno.speedTranslacao = 0;
			Urano.speedTranslacao = 0;
			Venus.speedTranslacao = 0;

			ZeraTranslacao = false;

		}

	
	}

	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width - 150,10,140,40),"");

		AtivaOrbita = GUI.Toggle(new Rect(Screen.width - 130,20,200,15),AtivaOrbita,"Visualizar Orbita");
		
		


		if( AtivaOrbita == true)
		{
			GameObject.Find("TerraOrbit").GetComponent<Renderer>().enabled = true;
			GameObject.Find("MercurioOrbit").GetComponent<Renderer>().enabled = true;
			GameObject.Find("JupiterOrbit").GetComponent<Renderer>().enabled = true;
			GameObject.Find("MarteOrbit").GetComponent<Renderer>().enabled = true;
			GameObject.Find("NetunoOrbit").GetComponent<Renderer>().enabled = true;
			GameObject.Find("SaturnoOrbit").GetComponent<Renderer>().enabled = true;
			GameObject.Find("UranoOrbit").GetComponent<Renderer>().enabled = true;
			GameObject.Find("VenusOrbit").GetComponent<Renderer>().enabled = true;
		}
		if( AtivaOrbita == false)
		{
			GameObject.Find("TerraOrbit").GetComponent<Renderer>().enabled = false;
			GameObject.Find("MercurioOrbit").GetComponent<Renderer>().enabled = false;
			GameObject.Find("JupiterOrbit").GetComponent<Renderer>().enabled = false;
			GameObject.Find("MarteOrbit").GetComponent<Renderer>().enabled = false;
			GameObject.Find("NetunoOrbit").GetComponent<Renderer>().enabled = false;
			GameObject.Find("SaturnoOrbit").GetComponent<Renderer>().enabled = false;
			GameObject.Find("UranoOrbit").GetComponent<Renderer>().enabled = false;
			GameObject.Find("VenusOrbit").GetComponent<Renderer>().enabled = false;
			
		}

	


	}


}
