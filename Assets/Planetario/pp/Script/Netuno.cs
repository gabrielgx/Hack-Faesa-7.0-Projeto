using UnityEngine;
using System.Collections;

public class Netuno : MonoBehaviour 

{
	
	float speedRotacao;  //Velocidade da rotacao;
	public static float speedTranslacao;
	bool ZoomIn = false;
	bool ZoomOut = false;
	bool VoltarAtivo = false;
	public Camera cam;
	bool label = false;
	bool texto = false;
	public Texture img;
	public GUIStyle style;
	float delay = 50f;
	
	
	
	void Start () //Seta as velocidades do planeta, velocidade negativa para inverter a direçao;
	{
		speedRotacao = 10;
	}
	
	void LateUpdate() 
	{					
		transform.Rotate(Vector3.up * speedRotacao * Time.deltaTime); //Chama funcao para rotacao do planeta
		transform.RotateAround (Vector3.zero, Vector3.up, speedTranslacao * Time.deltaTime);
		
		
		
		if(ZoomIn == true)
		{
			Painel.AtivaMouseDown = false;
			if(SmoothLookAt2.fov > 20)
			{
				SmoothLookAt2.fov -= 0.5f;	
			}
		}
		
		if(SmoothLookAt2.fov <= 20)
		{
			VoltarAtivo = true;
	
		}
		else
		{
			VoltarAtivo = false;

		}
		
		if(ZoomOut == true)
		{
			Painel.AtivaMouseDown = false;
			
			if(SmoothLookAt2.fov < 100)
			{
				SmoothLookAt2.fov += 0.5f;
				MouseOrbitZoom.fov = SmoothLookAt2.fov;
			}	
			if(SmoothLookAt2.fov >= 100)
			{
				delay--;

				
				if(delay <= 0)
				{
					Painel.AtivaMouseDown = true;
					ZoomOut = false;
					cam.GetComponent<MouseOrbitZoom>().enabled = true;
					MouseOrbitZoom.rotation = SmoothLookAt2.rotation;
					delay = 50f;
				}
			}
			
		}
		
		
		
	}
	void OnMouseOver(){
		if(Painel.AtivaMouseOver == true)
		{
			speedTranslacao = 0;
			label = true;
		}
	}
	
	void OnMouseExit()
	{
		if(Painel.MenuAtivo == false)
		{
			Painel.Reset = true;
			label = false;	
		}
		
	}
	
	void OnMouseDown(){
		
		if(Painel.AtivaMouseDown == true)
		{
			Painel.ZeraTranslacao = true;
			Painel.MenuAtivo = true;
			ZoomIn = true;
			ZoomOut = false;			
			cam.GetComponent<MouseOrbitZoom>().enabled = false;
			SmoothLookAt2.target = transform;
			label = true;
			Painel.AtivaMouseOver = false;
			texto = true;
		}
	}
	
	void OnGUI(){
		
		if(label == true)
		{	
			GUI.Box(new Rect(Input.mousePosition.x,Screen.height-Input.mousePosition.y - 25,50,20),"");
			GUI.Label(new Rect(Input.mousePosition.x + 5,Screen.height-Input.mousePosition.y - 25,100,100),"Netuno");
		}
		
		if(texto == true)	
		{
			GUI.Box(new Rect(20,40,350,540),img,style);
		}	
		
		if(ZoomIn == true)
		{
			label = false;
			if(VoltarAtivo == true)
			{
				if(GUI.Button(new Rect(Screen.width/2 - 50,10,100,20),"VOLTAR"))
				{		
					
					Painel.Reset = true;
					Painel.MenuAtivo = false;
					ZoomIn = false;
					ZoomOut = true;
					label = false;
					SmoothLookAt2.target = GameObject.Find("SolEsfera").transform;
					Painel.AtivaMouseOver = true;
					texto = false;
					
					
				}
			}
			
		}
	}
	
}

