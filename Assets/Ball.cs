using UnityEngine;
using System.Collections;


public class Ball : MonoBehaviour {
    
public float speed = 30;

  
public GameObject RightScore,LeftScore,Winner;  
public int ls=0,rs=0;
void Start() {
 
	ls=0;rs=0;
	GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
  
}
    
    
float hitFactor(Vector2 ballPos, Vector2 racketPos,
 float racketHeight) {
                
	return (ballPos.y - racketPos.y) / racketHeight;
    
}

    
void OnCollisionEnter2D(Collision2D col) {
 
 
	if(rs==21) { TextMesh t = (TextMesh)Winner.GetComponent(typeof(TextMesh)); t.text = "Winner    Right";} 
	else if(ls==21) { TextMesh t = (TextMesh)Winner.GetComponent(typeof(TextMesh)); t.text = "Winner    Left";} 
	else { 
		if (col.gameObject.name == "RacketLeft") {
    
			float y = hitFactor(transform.position,
col.transform.position,col.collider.bounds.size.y);

     
			ls++;  
			TextMesh t = (TextMesh)LeftScore.GetComponent(typeof(TextMesh));
    			t.text = "Left Score : " + ls.ToString();         
			Vector2 dir = new Vector2(1, y).normalized;GetComponent<Rigidbody2D>().velocity = dir * speed;
     
			}
		if (col.gameObject.name == "RacketRight") {

			float y = hitFactor(transform.position,
col.transform.position,col.collider.bounds.size.y);

    
			rs++;      
			TextMesh t = (TextMesh)RightScore.GetComponent(typeof(TextMesh));
    			t.text = "Right Score : " +rs.ToString();        
			Vector2 dir = new Vector2(-1, y).normalized;
GetComponent<Rigidbody2D>().velocity = dir * speed;
        
			}
  
	      }  
	}

}
