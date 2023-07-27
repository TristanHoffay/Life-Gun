using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer eyesRenderer;
    [SerializeField]
    private SpriteRenderer mouthRenderer;
    [SerializeField]
    private Sprite eyes_normal;
    [SerializeField]
    private Sprite eyes_happy;
    [SerializeField]
    private Sprite eyes_angry;
    [SerializeField]
    private Sprite eyes_worried;
    [SerializeField]
    private Sprite eyes_blink;
    [SerializeField]
    private Sprite mouth_cute;
    [SerializeField]
    private Sprite mouth_curious;
    [SerializeField]
    private Sprite mouth_frown;
    [SerializeField]
    private Sprite mouth_happy;
    [SerializeField]
    private Sprite mouth_open;
    [SerializeField]
    private Sprite mouth_shock;

    private float nextBlinkTime = 1f;
    private bool blinking = false;
    private Sprite blinkingExpression;

    // for testing cycling through expressions
    [SerializeField]
    private bool TestExpressionCycle = false;
    private float expressionChangeTime = 2f;
    private int cycle = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // blink every so often
        if (Time.time > nextBlinkTime)
        {
            // if not blinked, blink
            if (!blinking)
            {
                //blink
                blinkingExpression = eyesRenderer.sprite;
                blinking = true;
                eyesRenderer.sprite = eyes_blink;
                // set time to unblink
                nextBlinkTime = Time.time + Random.Range(0.1f, 0.3f);
            }
            // otherwise, unblink 
            else
            {
                //unblink
                blinking = false;
                // make sure expression hasnt been changed midblink
                if (eyesRenderer.sprite == eyes_blink)
                    eyesRenderer.sprite = blinkingExpression;
                // Set next time to blink
                nextBlinkTime = Time.time + Random.Range(0.3f, 10f);
            }
        }
        if (TestExpressionCycle && Time.time > expressionChangeTime)
        {
            expressionChangeTime = Time.time + 2f;
            switch (cycle)
            {
                case 0:
                    SetHappy();
                    break;
                case 1:
                    SetShocked();
                    break;
                case 2:
                    SetCurious();
                    break;
                case 3:
                    SetSad();
                    break;
                case 4:
                    SetCrying();
                    break;
                case 5:
                    SetFrown();
                    break;
                case 6:
                    SetUpset();
                    break;
                case 7:
                    SetAngry();
                    break;
                case 8:
                    SetCuteAngry();
                    break;
                case 9:
                    SetAggressive();
                    break;
                case 10:
                    SetAwe();
                    break;
                case 11:
                    SetCute();
                    break;
                case 12:
                    SetJoy();
                    break;
                case 13:
                    SetWhistling();
                    break;
                case 14:
                    SetPleased();
                    break;
            }
            cycle++;
            if (cycle > 14)
                cycle = 0;
        }
    }

    public void SetHappy()
    {
        eyesRenderer.sprite = eyes_normal;
        mouthRenderer.sprite = mouth_happy;
    }
    public void SetShocked()
    {
        eyesRenderer.sprite = eyes_normal;
        mouthRenderer.sprite = mouth_shock;
    }
    public void SetCurious()
    {
        eyesRenderer.sprite = eyes_normal;
        mouthRenderer.sprite = mouth_curious;
    }
    public void SetSad()
    {
        eyesRenderer.sprite = eyes_worried;
        mouthRenderer.sprite = mouth_frown;
    }
    public void SetCrying()
    {
        eyesRenderer.sprite = eyes_happy;
        mouthRenderer.sprite = mouth_frown;
    }
    public void SetFrown()
    {
        eyesRenderer.sprite = eyes_normal;
        mouthRenderer.sprite = mouth_frown;
    }
    public void SetUpset()
    {
        eyesRenderer.sprite = eyes_angry;
        mouthRenderer.sprite = mouth_frown;
    }
    public void SetAngry()
    {
        eyesRenderer.sprite = eyes_angry;
        mouthRenderer.sprite = mouth_shock;
    }
    public void SetCuteAngry()
    {
        eyesRenderer.sprite = eyes_angry;
        mouthRenderer.sprite = mouth_cute;
    }
    public void SetAggressive()
    {
        eyesRenderer.sprite = eyes_angry;
        mouthRenderer.sprite = mouth_happy;
    }
    public void SetAwe()
    {
        eyesRenderer.sprite = eyes_normal;
        mouthRenderer.sprite = mouth_open;
    }
    public void SetCute()
    {
        eyesRenderer.sprite = eyes_normal;
        mouthRenderer.sprite = mouth_cute;
    }
    public void SetJoy()
    {
        eyesRenderer.sprite = eyes_happy;
        mouthRenderer.sprite = mouth_happy;
    }
    public void SetWhistling()
    {
        eyesRenderer.sprite = eyes_happy;
        mouthRenderer.sprite = mouth_curious;
    }
    public void SetPleased()
    {
        eyesRenderer.sprite = eyes_happy;
        mouthRenderer.sprite = mouth_cute;
    }


}
