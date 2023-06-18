using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleB : MonoBehaviour
{

	public Texture2D tip;
	public string goToScene = "Field1";
	public string spawnPointName = "PlayerSpawnPointC";
	public GameObject characterDatabase;
	public Transform modelPosition;

	private float progressValue;
	public Slider slider;   //进度条
	public Text text;      //加载进度文本

	//private int presave = 0;

	private int saveSlot = 0;
	private string charName = "Richea";
	private int charSelect = 0;
	private int maxChar = 1;
	private CharacterDataC charData;
	private GameObject showingModel;

	public Text[] saveSlotText = new Text[3];

	public GameObject eventSystemToDelete;

	public bool useLegacyUi = false;

	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		charData = characterDatabase.GetComponent<CharacterDataC>();
		maxChar = charData.player.Length;
		if (!modelPosition)
		{
			modelPosition = this.transform;
		}
		//Reset All Static variable in Evene Maker System
		for (int a = 0; a < EventSetting.globalBoolean.Length; a++)
		{
			EventSetting.globalBoolean[a] = false;
		}
		for (int a = 0; a < EventSetting.globalInt.Length; a++)
		{
			EventSetting.globalInt[a] = 0;
		}
		SwitchModel();
	}









	public void NewGame()
	{
		PlayerPrefs.SetInt("SaveSlot", saveSlot);
		PlayerPrefs.SetString("Name" +saveSlot.ToString(), charName);
		//PlayerPrefs.SetInt("PlayerID" +saveSlot.ToString(), charSelect);
		PlayerPrefs.SetInt("Loadgame", 0);
		Destroy(eventSystemToDelete);
		GameObject pl = Instantiate(charData.player[charSelect].playerPrefab, transform.position, transform.rotation) as GameObject;
		pl.GetComponent<StatusC>().spawnPointName = spawnPointName;
		pl.GetComponent<StatusC>().characterId = charSelect;
		pl.GetComponent<StatusC>().characterName = charName;
		GlobalConditionC.playerId = pl.GetComponent<StatusC>().characterId;
		//Application.LoadLevel(goToScene);
		SceneManager.LoadScene(goToScene, LoadSceneMode.Single);
	}
	public void LoadNextLeaver()
	{
		//image.SetActive(true);
		StartCoroutine(LoadLeaver());
	}
	IEnumerator LoadLeaver()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("Fight");
		async.allowSceneActivation = false;
		while (!async.isDone)
		{
			if (async.progress < 0.9f)
				progressValue = async.progress;
			else
				progressValue = 1.0f;

			slider.value = progressValue;
			text.text = (int)(slider.value * 100) + " %"+"穿越中";

			if (progressValue >= 0.9)
			{
				text.text = "按任意键继续";
				if (Input.anyKeyDown)
				{
					async.allowSceneActivation = true;
				}
			}

			yield return null;
		}


	}

	
	public void SwitchModel()
	{
		if (showingModel)
		{
			Destroy(showingModel);
		}
		//Spawn Showing Model from Character Database
		if (charData.player[charSelect].characterSelectModel)
		{
			showingModel = Instantiate(charData.player[charSelect].characterSelectModel, modelPosition.position, modelPosition.rotation) as GameObject;
		}
	}


	public void SetPlayerName(string val)
	{
		charName = val;
	}

}