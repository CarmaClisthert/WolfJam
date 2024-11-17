using UnityEngine;

public class ArrayTestMaking : MonoBehaviour
{
    public string[] name;
    public string[] occupation;
    public string[] bark;
    public Sprite[] goon;

    public int namenum;
    public int occupationnum;
    public int barknum;
    public int goonnum;

    public string goonname;
    public string goonoccupation;
    public string goonbark;

    public SpriteRenderer goonsprite;
    public Sprite goonimage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        namenum = Random.RandomRange(0, 3);
        occupationnum = Random.Range(0, 3);
        barknum = Random.Range(0, 3);
        goonnum = Random.RandomRange(0, 2);

        goonname = name[namenum];
        goonoccupation = occupation[occupationnum];
        goonbark = bark[barknum];

        print(goonname);
        print(goonoccupation);
        print(goonbark);
        goonsprite.sprite = goon[goonnum];
        //ChangeSprite();
    }

    // Update is called once per frame
    void ChangeSprite()
    {
        goonsprite.sprite = goon[goonnum];
    }
}
