using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientImage : MonoBehaviour
{
    [SerializeField] Image progressIndicator;
    float[] partWidths;

    public float duration = 5f;

    private float timer = 0f;
    private float progress = 0f;

    Image image;
    Coroutine animationRoutine;
    bool isAnimationRunning=false;

    Vector3 startPos;

    int[] currentColorsPercents = new int[3] { 70, 10, 20 }; // R Y G

    void Start()
    {
        image = GetComponent<Image>();
        startPos=progressIndicator.transform.localPosition;
        Deactivate();
    }

    Color GetColorForIndex(int index)
    {
        switch (index)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.yellow;
            case 2:
                return Color.green;
            case 3:
                return Color.yellow;
            case 4:
                return Color.red;
            default:
                return Color.white;
        }
    }

    IEnumerator AnimationPlaying()
    {
        //startPos = progressIndicator.transform.localPosition;
        isAnimationRunning=true;
        timer=0;
        while (timer < duration)
        {
            progress = timer / duration;

            float currentValue = Mathf.Lerp(0f, image.rectTransform.rect.width, progress);
            progressIndicator.transform.localPosition = startPos + new Vector3(currentValue, 0, 0);
            timer += Time.deltaTime;
            yield return null;
        }
        progressIndicator.transform.localPosition = startPos;
    }

    void SetColors(int[] colorPercents)
    {
        currentColorsPercents = colorPercents;

        int width = (int)image.rectTransform.rect.width;
        int height = (int)image.rectTransform.rect.height;

        Texture2D texture = new Texture2D(width, height);

        float totalWidth = 0;
        partWidths = new float[5];


        for (int i = 0; i < 5; i++)
        {   

            float percent = i > 2 ? colorPercents[4 - i] : colorPercents[i];

            if(i!=2)
            percent /= 2;

            float partWidth = width * percent / 100;
            partWidths[i] = Mathf.RoundToInt(partWidth);
            totalWidth += partWidths[i];
        }

        if (totalWidth < width)
        {
            Debug.LogWarning("Total with is lower "+ totalWidth+ " "+width);
            partWidths[4] += width - totalWidth;
        }

        for (int i = 0; i < 5; i++)
        {
            Color color = GetColorForIndex(i);

            for (int x = (int)(totalWidth - partWidths[i]); x < totalWidth; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    texture.SetPixel(x, y, color);
                }
            }
            totalWidth -= partWidths[i];
        }

        texture.Apply();

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
    }

    public float GetProgress()
    {
        return progress;
    }

    public void PlayAnimation()
    {
        animationRoutine = StartCoroutine(AnimationPlaying());
    }

    public void Activate(int[] colorPercents)
    {
        this.gameObject.SetActive(true);
        if (colorPercents.Length > 0)
        {
            SetColors(colorPercents);
            PlayAnimation();
        }
    }

    public void Deactivate()
    {
        if(isAnimationRunning)
        {
        StopCoroutine(animationRoutine);
        isAnimationRunning=false;
        }

        progressIndicator.transform.localPosition = startPos;
        this.gameObject.SetActive(false);
    }
}