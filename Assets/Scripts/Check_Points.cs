using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

public class Check_Points : MonoBehaviour
{
    [SerializeField] public Transform Latest_Checkpoint;
    [SerializeField] Transform Latest_BlockWall;
    [SerializeField] public GameObject Player;
    [SerializeField] public Transform Spawn;
    [SerializeField] public Transform ZeroCount;
    [SerializeField] public Transform Latest_Checkpoint_count;
    [SerializeField] public Transform Latest_BlockWall_count;
    [SerializeField] public Transform Latest_BlockWall_place;
    [SerializeField] public GameObject Camera;
    public GameObject DestroyMoneyGameObject;
    public GameManager gamemanager;

    public static bool IsMoneyCountChanged = false;
    
    void Awake()
    {
        if(this.CompareTag("Checkpoint"))
        {
            Debug.Log("Запуск: значение последнего чекпоинта равно координатам спавна");
            Latest_Checkpoint_count.transform.position = Spawn.transform.position;
            Latest_BlockWall.transform.position = new Vector3(10f, 1.5f, 8000f);
        }
        
    }
    
    Vector3 StringToVector3(string input)
    {
        string[] values = input.Split(',', '(', ')');
        float x = float.Parse(values[1].Trim(), CultureInfo.InvariantCulture.NumberFormat);
        float y = float.Parse(values[2].Trim(), CultureInfo.InvariantCulture.NumberFormat);
        float z = float.Parse(values[3].Trim(), CultureInfo.InvariantCulture.NumberFormat);
        return new Vector3(x, y, z);
        
    }
    
    void Start()  
    {  

        if(this.CompareTag("Checkpoint"))  
        {  
            Debug.Log("Активирован метод Старт");
            Player.SetActive(false);
            Debug.Log("Игрок неактивен");
            Camera.SetActive(true);
            Debug.Log("Камера активна");
            GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            Debug.Log("В переменную для конверта присвоено сохранение последнего чекпоинта");
            GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
            Debug.Log("Переменная вектор3 равна переменной для конверта из трансформ в вектор3");    
            Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;     
            Debug.Log("Значение последнего чекпоинта равна сохранённому прогрессу");
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
            Debug.Log("Сохранённая позиция была использована последним чекпоинтом");    
            Player.transform.position = Latest_Checkpoint.transform.position;
            Debug.Log("Игрок телепортирован к последнему чекпоинту");
            GameManager.Latest_BlockWall_pos = PlayerPrefs.GetString("StringLatest_BlockWall");
            Debug.Log("В переменную для конверта присвоено сохранение последней стены");
            GameManager.Latest_BlockWall_ToVector3 = StringToVector3(GameManager.Latest_BlockWall_pos);
            Debug.Log("Переменная вектор3 равна переменной для конверта из трансформ в вектор3");
            Latest_BlockWall_count.transform.position = GameManager.Latest_BlockWall_ToVector3;
            Debug.Log("Значение последней стены равно переменной вектор3");
            Latest_BlockWall.transform.position = Latest_BlockWall_count.transform.position;
            Debug.Log("Координаты стены были изменены на текущее сохранение");          
            Debug.Log("Метод старт был закончен");
        } 
        
    }

    void OnTriggerEnter(Collider other) 
    { 
        if(this.CompareTag("Money") && other.CompareTag("Player")) 
        { 
            IsMoneyCountChanged = true; 
            Destroy(this.gameObject); 
            Latest_BlockWall_count.transform.position = Latest_BlockWall_place.transform.position;
            Latest_BlockWall.transform.position = Latest_BlockWall_count.transform.position;
            GameManager.Latest_BlockWall_pos = Latest_BlockWall_count.transform.position.ToString();
            PlayerPrefs.SetString("StringLatest_BlockWall", GameManager.Latest_BlockWall_pos);
            PlayerPrefs.Save();
            gamemanager.UpInf();

        } 
        if(this.CompareTag("Checkpoint") && other.CompareTag("Player"))
        {
            Latest_Checkpoint_count.transform.position = this.transform.position;
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;
            GameManager.Latest_Checkpoint_pos = Latest_Checkpoint_count.transform.position.ToString();
            PlayerPrefs.SetString("StringLatest_Checkpoint", GameManager.Latest_Checkpoint_pos);
            PlayerPrefs.Save();
            gamemanager.UpInf();


        }
        if(this.CompareTag("Death_Ground") && other.CompareTag("Player"))
        {
            GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            
            GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
                
            
            Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
                
            
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
                
            
            Player.transform.position = Latest_Checkpoint.transform.position;  
            gamemanager.UpInf();

        }
        if(this.CompareTag("Latest_Checkpoint") && other.CompareTag("Checkpoint"))
        {
            DestroyMoneyGameObject = other.gameObject;
            DestroyMoneyGameObject = GameObject.Find("Money");
            Debug.Log("Finded Money");
        }
    }

    public void Reset()
    {
        Latest_Checkpoint_count.transform.position = Spawn.transform.position;
        GameManager.Latest_Checkpoint_pos = Latest_Checkpoint_count.transform.position.ToString();
        PlayerPrefs.SetString("StringLatest_Checkpoint", GameManager.Latest_Checkpoint_pos);
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        PlayerPrefs.SetInt("Money", 0   );
        PlayerPrefs.SetInt("Current_Lvl", 0);
        PlayerPrefs.Save();
        gamemanager.ResetInf();
        SceneManager.LoadScene("Game 1");
    }

    public void ResetV2()
    {
        //Debug.Log("Success!");
        Debug.Log("Функция ResetV2 была запущена");
        Latest_Checkpoint_count.transform.position = Spawn.transform.position;
        Debug.Log("Значение последнего чекпоинта равно позиции спавна");
        GameManager.Latest_Checkpoint_pos = Latest_Checkpoint_count.transform.position.ToString();
        Debug.Log("Значение переменной для конверта равно значению последнего чекпоинта");
        PlayerPrefs.SetString("StringLatest_Checkpoint", GameManager.Latest_Checkpoint_pos);
        Debug.Log("Значение последнего чекпоинта было сохранено");
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        Debug.Log("Положение стены представлено нулём и сохранено");
        PlayerPrefs.SetInt("Money", 0   );
        Debug.Log("Количество монет равно 0 и сохранено");
        PlayerPrefs.SetInt("Current_Lvl", 0);
        Debug.Log("Текущий прогресс равен 0 и сохранен");
        PlayerPrefs.Save();
        gamemanager.ResetInf();
        Debug.Log("Все изменения сохранены");
        Debug.Log("Вызван метод UpInf");
        gamemanager.UpInf();
        Debug.Log("Метод ResetV2 был закончен");
        //Debug.Log("Success2!");

    }

    public void DestroyMoneyChild(GameObject MoneyCount)
    {
        
        if(MoneyCount != null)
        {
            MoneyCount.gameObject.SetActive(false);
            Debug.Log("Монета была успешно уничтожена");
        } else 
        {
            Debug.Log("Crash");
        }
    }

    public void SecondStart()
    {
        Debug.Log("Запуск SecondStart");
        GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
        Debug.Log("SecondStart: переменная для конверта присвоено сохранение последнего чекпоинта");
        GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
        Debug.Log("SecondStart: конвертер вектор 3 равен переменной для конверта");        
        Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
        Debug.Log("SecondStart: значение последнего чекпоинта равно конвертированным координатам");        
        Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
        Debug.Log("SecondStart: позиция последнего чекпоинта равна значению последнего сохранения");
        Player.transform.position = Latest_Checkpoint.transform.position;
        Debug.Log("SecondStart: позиция игрока равна последнему чекпоинту");
        Latest_BlockWall.transform.position = new Vector3(10f, 1.5f, 8000f);
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        Debug.Log("SecondStart: сохранение блокстены равно нулю");
        PlayerPrefs.Save();
        Debug.Log("SecondStart: изменения сохранены");
        Debug.Log("SecondStart: метод завершён");
            
        // Latest_BlockWall_count.transform.position = GameManager.Latest_BlockWall_ToVector3;
            

        // Latest_BlockWall.transform.position = Latest_BlockWall_count.transform.position;

    }
    
    

    
}
