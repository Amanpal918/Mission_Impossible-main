using UnityEngine;
using Platformer.Mechanics;

public class TokenReset : MonoBehaviour
{
    private TokenInstance token;
    private Collider2D col;
    private SpriteRenderer sr;
    // private SpriteRenderer sr1;
    public TokenController controller;

    void Awake()
    {
        token = GetComponent<TokenInstance>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    //     sr1 = GetComponent<SpriteRenderer>();
    
    }
     public void ResetToken()
    {
        // Debug.Log("Step 1");
    //     token.collected = false;
    //     token.frame = 0;
    //     // token.sprites = token.idleAnimation;
    //     //  Debug.Log("Step 2");
    //     //  sr.sprite = token.sprites[0];
    //     sr1.sprite =token.collectedAnimation[0];
    //     sr.sprite = token.idleAnimation[0];
    //     gameObject.SetActive(true);
    //     col.enabled = true;
    //     sr.enabled = true;
    controller.Testing();
    token.collected = false;
    token.frame = 0;
    
    // 2. Point back to the idle/spinning animation
    token.sprites = token.idleAnimation;
    
    // 3. FORCE the SpriteRenderer to show the first frame of the animation
    if (sr != null && token.sprites.Length > 0)
    {
        sr.sprite = token.sprites[0]; 
    }

    // 4. Reactivate the object and its components
    gameObject.SetActive(true);
    if (col != null) col.enabled = true;
    if (sr != null) sr.enabled = true;

    }
}

