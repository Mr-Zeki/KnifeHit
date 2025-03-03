using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeManager : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();

    [SerializeField] private GameObject knifePrefab;

    [SerializeField] private GameObject knifeIconPrefab;

    [SerializeField] private Color activeColor;

    [SerializeField] private Color deactiveColor;

    [SerializeField] private Vector2 knifeIconPosition;

    [SerializeField] private int knifeCount;

    private List<GameObject> knifeIconList = new List<GameObject>();
    private int knifeIndex;
    // Start is called before the first frame update
    void Start()
    {
        CreateKnife();
        CreateKnifeIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateKnife()
    {
        for (int i = 0; i< knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefab, new Vector2(0f, -3f), Quaternion.Euler(0f, 0f, -45f));
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
        }

        knifeList[0].SetActive(true);
    }

    private void CreateKnifeIcon()
    {
        for (int i = 0;i< knifeCount;i++)
        {
            GameObject newKnifeIcon = Instantiate(knifeIconPrefab,knifeIconPosition,knifeIconPrefab.transform.rotation);
            newKnifeIcon.GetComponent<SpriteRenderer>().color = activeColor;
            knifeIconPosition.y += 0.7f;
            knifeIconList.Add(newKnifeIcon);
        }
        
    }

    public void setDisableKnifeIconColor()
    {
        knifeIconList[(knifeIconList.Count - 1) - knifeIndex].GetComponent<SpriteRenderer>().color = deactiveColor;
    }

    public void setActiveKnife()
    {
        if (knifeIndex < knifeCount - 1)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true) ;
        }
    }
}
