using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Solitaire : MonoBehaviour
{
	public Sprite[] cardFaces;
	public GameObject cardPrefab;
	public GameObject[] bottomPos;
	public GameObject[] topPos;
	public GameObject[] rightPos;
	public GameObject[] leftPos;
	
	public static string[] suits = new string[] { "B", "G", "R", "Y" };
    public static string[] values = new string[] { "1", "2", "S", "4", "5", "6", "7", "H", "9", "10", "11", "12", "13", "14", "15" };
	public List<string>[] bottoms;
	public List<string>[] tops;
	public List<string>[] rights;
	public List<string>[] lefts;
	
	private List<string> bottom0= new List<string>();
	private List<string> bottom1= new List<string>();
	private List<string> bottom2= new List<string>();
	private List<string> bottom3= new List<string>();
	private List<string> bottom4= new List<string>();
	private List<string> bottom5= new List<string>();
	private List<string> bottom6= new List<string>();
	private List<string> bottom7= new List<string>();
	private List<string> bottom8= new List<string>();
	private List<string> bottom9= new List<string>();
	private List<string> bottom10= new List<string>();
	private List<string> bottom11= new List<string>();
	private List<string> bottom12= new List<string>();
	private List<string> bottom13= new List<string>();
	private List<string> bottom14= new List<string>();
	private List<string> top0= new List<string>();
	private List<string> top1= new List<string>();
	private List<string> top2= new List<string>();
	private List<string> top3= new List<string>();
	private List<string> top4= new List<string>();
	private List<string> top5= new List<string>();
	private List<string> top6= new List<string>();
	private List<string> top7= new List<string>();
	private List<string> top8= new List<string>();
	private List<string> top9= new List<string>();
	private List<string> top10= new List<string>();
	private List<string> top11= new List<string>();
	private List<string> top12= new List<string>();
	private List<string> top13= new List<string>();
	private List<string> top14= new List<string>();
	private List<string> right0= new List<string>();
	private List<string> right1= new List<string>();
	private List<string> right2= new List<string>();
	private List<string> right3= new List<string>();
	private List<string> right4= new List<string>();
	private List<string> right5= new List<string>();
	private List<string> right6= new List<string>();
	private List<string> right7= new List<string>();
	private List<string> right8= new List<string>();
	private List<string> right9= new List<string>();
	private List<string> right10= new List<string>();
	private List<string> right11= new List<string>();
	private List<string> right12= new List<string>();
	private List<string> right13= new List<string>();
	private List<string> right14= new List<string>();
	private List<string> left0= new List<string>();
	private List<string> left1= new List<string>();
	private List<string> left2= new List<string>();
	private List<string> left3= new List<string>();
	private List<string> left4= new List<string>();
	private List<string> left5= new List<string>();
	private List<string> left6= new List<string>();
	private List<string> left7= new List<string>();
	private List<string> left8= new List<string>();
	private List<string> left9= new List<string>();
	private List<string> left10= new List<string>();
	private List<string> left11= new List<string>();
	private List<string> left12= new List<string>();
	private List<string> left13= new List<string>();
	private List<string> left14= new List<string>();
	
	
    public List<string> deck;
   
   
    // Start is called before the first frame update
    void Start()
    {
		bottoms = new List<string>[] { bottom0, bottom1, bottom2, bottom3, bottom4, bottom5, bottom6, bottom7, bottom8, bottom9, bottom10, bottom11, bottom12, bottom13, bottom14 };
		tops = new List<string>[] { top0, top1, top2, top3, top4, top5, top6, top7, top8, top9, top10, top11, top12, top13, top14 };
		rights = new List<string>[] { right0, right1, right2, right3, right4, right5, right6, right7, right8, right9, right10, right11, right12, right13, right14 };
		lefts = new List<string>[] { left0, left1, left2, left3, left4, left5, left6, left7, left8, left9, left10, left11, left12, left13, left14 };
		
        PlayCards();
		
		
    }

    // Update is called once per frame
    void Update()
    {
		
	}
	
	public void PlayCards()
	{
		deck = GenerateDeck();
		Shuffle(deck);
		
		//test the cards in the deck:
		foreach (string card in deck)
		{
			print(card);
		}
		SolitaireSort();
		StartCoroutine(SolitaireDeal());
	}
	
	
	public static List<string> GenerateDeck()
	{
		List<string> newDeck = new List<string>();
		foreach (string s in suits)
		{
			foreach (string v in values)
			{
				newDeck.Add(s + v);
			}
		}
		return newDeck;
		
	}
	void Shuffle<T>(List<T> list)
	{
		System.Random random = new System.Random();
		int n = list.Count;
		while (n> 1)
		{
			int k = random.Next(n);
			n--;
			T temp = list[k];
			list[k] = list[n];
			list[n]=temp;
		}
	}
	
	//Deals the cards out to specific location
	IEnumerator SolitaireDeal()
	{
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[0])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[0].transform.position.x, leftPos[0].transform.position.y - yOffset, leftPos[0].transform.position.z - zOffset), Quaternion.identity, leftPos[0].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[0])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[0].transform.position.x, topPos[0].transform.position.y - yOffset, topPos[0].transform.position.z - zOffset), Quaternion.identity, topPos[0].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[0])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[0].transform.position.x, rightPos[0].transform.position.y - yOffset, rightPos[0].transform.position.z - zOffset), Quaternion.identity, rightPos[0].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[0])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[0].transform.position.x, bottomPos[0].transform.position.y - yOffset, bottomPos[0].transform.position.z - zOffset), Quaternion.identity, bottomPos[0].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[1])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[1].transform.position.x, leftPos[1].transform.position.y - yOffset, leftPos[1].transform.position.z - zOffset), Quaternion.identity, leftPos[1].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[1])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[1].transform.position.x, topPos[1].transform.position.y - yOffset, topPos[1].transform.position.z - zOffset), Quaternion.identity, topPos[1].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[1])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[1].transform.position.x, rightPos[1].transform.position.y - yOffset, rightPos[1].transform.position.z - zOffset), Quaternion.identity, rightPos[1].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[1])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y - yOffset, bottomPos[1].transform.position.z - zOffset), Quaternion.identity, bottomPos[1].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[2])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[2].transform.position.x, leftPos[2].transform.position.y - yOffset, leftPos[2].transform.position.z - zOffset), Quaternion.identity, leftPos[2].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[2])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[2].transform.position.x, topPos[2].transform.position.y - yOffset, topPos[2].transform.position.z - zOffset), Quaternion.identity, topPos[2].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[2])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[2].transform.position.x, rightPos[2].transform.position.y - yOffset, rightPos[2].transform.position.z - zOffset), Quaternion.identity, rightPos[2].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[2])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y - yOffset, bottomPos[2].transform.position.z - zOffset), Quaternion.identity, bottomPos[2].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[3])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[3].transform.position.x, leftPos[3].transform.position.y - yOffset, leftPos[3].transform.position.z - zOffset), Quaternion.identity, leftPos[3].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[3])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[3].transform.position.x, topPos[3].transform.position.y - yOffset, topPos[3].transform.position.z - zOffset), Quaternion.identity, topPos[3].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[3])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[3].transform.position.x, rightPos[3].transform.position.y - yOffset, rightPos[3].transform.position.z - zOffset), Quaternion.identity, rightPos[3].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[3])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y - yOffset, bottomPos[3].transform.position.z - zOffset), Quaternion.identity, bottomPos[3].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[4])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[4].transform.position.x, leftPos[4].transform.position.y - yOffset, leftPos[4].transform.position.z - zOffset), Quaternion.identity, leftPos[4].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[4])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[4].transform.position.x, topPos[4].transform.position.y - yOffset, topPos[4].transform.position.z - zOffset), Quaternion.identity, topPos[4].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[4])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[4].transform.position.x, rightPos[4].transform.position.y - yOffset, rightPos[4].transform.position.z - zOffset), Quaternion.identity, rightPos[4].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[4])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[4].transform.position.x, bottomPos[4].transform.position.y - yOffset, bottomPos[4].transform.position.z - zOffset), Quaternion.identity, bottomPos[4].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[5])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[5].transform.position.x, leftPos[5].transform.position.y - yOffset, leftPos[5].transform.position.z - zOffset), Quaternion.identity, leftPos[5].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[5])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[5].transform.position.x, topPos[5].transform.position.y - yOffset, topPos[5].transform.position.z - zOffset), Quaternion.identity, topPos[5].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[5])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[5].transform.position.x, rightPos[5].transform.position.y - yOffset, rightPos[5].transform.position.z - zOffset), Quaternion.identity, rightPos[5].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[5])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[5].transform.position.x, bottomPos[5].transform.position.y - yOffset, bottomPos[5].transform.position.z - zOffset), Quaternion.identity, bottomPos[5].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[6])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[6].transform.position.x, leftPos[6].transform.position.y - yOffset, leftPos[6].transform.position.z - zOffset), Quaternion.identity, leftPos[6].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[6])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[6].transform.position.x, topPos[6].transform.position.y - yOffset, topPos[6].transform.position.z - zOffset), Quaternion.identity, topPos[6].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[6])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[6].transform.position.x, rightPos[6].transform.position.y - yOffset, rightPos[6].transform.position.z - zOffset), Quaternion.identity, rightPos[6].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[6])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[6].transform.position.x, bottomPos[6].transform.position.y - yOffset, bottomPos[6].transform.position.z - zOffset), Quaternion.identity, bottomPos[6].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[7])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[7].transform.position.x, leftPos[7].transform.position.y - yOffset, leftPos[7].transform.position.z - zOffset), Quaternion.identity, leftPos[7].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[7])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[7].transform.position.x, topPos[7].transform.position.y - yOffset, topPos[7].transform.position.z - zOffset), Quaternion.identity, topPos[7].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[7])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[7].transform.position.x, rightPos[7].transform.position.y - yOffset, rightPos[7].transform.position.z - zOffset), Quaternion.identity, rightPos[7].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[7])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[7].transform.position.x, bottomPos[7].transform.position.y - yOffset, bottomPos[7].transform.position.z - zOffset), Quaternion.identity, bottomPos[7].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[8])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[8].transform.position.x, leftPos[8].transform.position.y - yOffset, leftPos[8].transform.position.z - zOffset), Quaternion.identity, leftPos[8].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[8])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[8].transform.position.x, topPos[8].transform.position.y - yOffset, topPos[8].transform.position.z - zOffset), Quaternion.identity, topPos[8].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[8])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[8].transform.position.x, rightPos[8].transform.position.y - yOffset, rightPos[8].transform.position.z - zOffset), Quaternion.identity, rightPos[8].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[8])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[8].transform.position.x, bottomPos[8].transform.position.y - yOffset, bottomPos[8].transform.position.z - zOffset), Quaternion.identity, bottomPos[8].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[9])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[9].transform.position.x, leftPos[9].transform.position.y - yOffset, leftPos[9].transform.position.z - zOffset), Quaternion.identity, leftPos[9].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[9])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[9].transform.position.x, topPos[9].transform.position.y - yOffset, topPos[9].transform.position.z - zOffset), Quaternion.identity, topPos[9].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[9])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[9].transform.position.x, rightPos[9].transform.position.y - yOffset, rightPos[9].transform.position.z - zOffset), Quaternion.identity, rightPos[9].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[9])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[9].transform.position.x, bottomPos[9].transform.position.y - yOffset, bottomPos[9].transform.position.z - zOffset), Quaternion.identity, bottomPos[9].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[10])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[10].transform.position.x, leftPos[10].transform.position.y - yOffset, leftPos[10].transform.position.z - zOffset), Quaternion.identity, leftPos[10].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[10])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[10].transform.position.x, topPos[10].transform.position.y - yOffset, topPos[10].transform.position.z - zOffset), Quaternion.identity, topPos[10].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[10])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[10].transform.position.x, rightPos[10].transform.position.y - yOffset, rightPos[10].transform.position.z - zOffset), Quaternion.identity, rightPos[10].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[10])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[10].transform.position.x, bottomPos[10].transform.position.y - yOffset, bottomPos[10].transform.position.z - zOffset), Quaternion.identity, bottomPos[10].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[11])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[11].transform.position.x, leftPos[11].transform.position.y - yOffset, leftPos[11].transform.position.z - zOffset), Quaternion.identity, leftPos[11].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[11])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[11].transform.position.x, topPos[11].transform.position.y - yOffset, topPos[11].transform.position.z - zOffset), Quaternion.identity, topPos[11].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[11])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[11].transform.position.x, rightPos[11].transform.position.y - yOffset, rightPos[11].transform.position.z - zOffset), Quaternion.identity, rightPos[11].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[11])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[11].transform.position.x, bottomPos[11].transform.position.y - yOffset, bottomPos[11].transform.position.z - zOffset), Quaternion.identity, bottomPos[11].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[12])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[12].transform.position.x, leftPos[12].transform.position.y - yOffset, leftPos[12].transform.position.z - zOffset), Quaternion.identity, leftPos[12].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[12])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[12].transform.position.x, topPos[12].transform.position.y - yOffset, topPos[12].transform.position.z - zOffset), Quaternion.identity, topPos[12].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[12])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[12].transform.position.x, rightPos[12].transform.position.y - yOffset, rightPos[12].transform.position.z - zOffset), Quaternion.identity, rightPos[12].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[12])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[12].transform.position.x, bottomPos[12].transform.position.y - yOffset, bottomPos[12].transform.position.z - zOffset), Quaternion.identity, bottomPos[12].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[13])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[13].transform.position.x, leftPos[13].transform.position.y - yOffset, leftPos[13].transform.position.z - zOffset), Quaternion.identity, leftPos[13].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[13])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[13].transform.position.x, topPos[13].transform.position.y - yOffset, topPos[13].transform.position.z - zOffset), Quaternion.identity, topPos[13].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[13])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[13].transform.position.x, rightPos[13].transform.position.y - yOffset, rightPos[13].transform.position.z - zOffset), Quaternion.identity, rightPos[13].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[13])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[13].transform.position.x, bottomPos[13].transform.position.y - yOffset, bottomPos[13].transform.position.z - zOffset), Quaternion.identity, bottomPos[13].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		//Deals to left row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in lefts[14])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(leftPos[14].transform.position.x, leftPos[14].transform.position.y - yOffset, leftPos[14].transform.position.z - zOffset), Quaternion.identity, leftPos[14].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to top row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in tops[14])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[14].transform.position.x, topPos[14].transform.position.y - yOffset, topPos[14].transform.position.z - zOffset), Quaternion.identity, topPos[14].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to right side
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in rights[14])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(rightPos[14].transform.position.x, rightPos[14].transform.position.y - yOffset, rightPos[14].transform.position.z - zOffset), Quaternion.identity, rightPos[14].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = false;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
		
		//Deals to bottom row
		for (int i = 0; i < 1; i++)
		{
		
			float yOffset = 0;
			float zOffset = 0.03f;
			foreach (string card in bottoms[14])
			{
				yield return new WaitForSeconds(.03f);
				GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[14].transform.position.x, bottomPos[14].transform.position.y - yOffset, bottomPos[14].transform.position.z - zOffset), Quaternion.identity, bottomPos[14].transform);
				newCard.name = card;
				newCard.GetComponent<Selectable>().faceUp = true;
				
				yOffset = yOffset + 0.3f;
				zOffset = zOffset + 0.03f;
			}
		}
			
	}
	
	//Places the cards out to correct card holder position
	void SolitaireSort()
	{
	
		//Places in bottom card holders
		for (int i = 0; i < 15; i++)
		{
			bottoms[i].Add(deck.Last<string>());
			deck.RemoveAt(deck.Count - 1);
		}
		
		//Places in top card holders
		for (int i = 0; i < 15; i++)
		{
			tops[i].Add(deck.Last<string>());
			deck.RemoveAt(deck.Count - 1);
		}
		
		//Places in right card holders
		for (int i = 0; i < 15; i++)
		{
			rights[i].Add(deck.Last<string>());
			deck.RemoveAt(deck.Count - 1);
		}
		
		//Places in left card holders
		for (int i = 0; i < 15; i++)
		{
			lefts[i].Add(deck.Last<string>());
			deck.RemoveAt(deck.Count - 1);
		}
	}
	
	
	
}
