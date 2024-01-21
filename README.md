# Unity TPS Controller Projesi

Bu Unity projesi, Third Person Shooter (TPS) türünde bir oyuncu kontrol sistemini içermektedir. Proje, "The Sims" oyunlarından ilham alarak geliştirilmiş olup, oyuncunun klavye aracılığıyla çeşitli nesnelerle etkileşime geçebildiği bir kontrol sistemini hedeflemektedir.

## Sınıflar ve Özellikleri

### 1. GameSaveSystem

`GameSaveSystem` sınıfı, oyuncu konumunu, lambaların durumunu ve pil enerjisi gibi önemli verileri kaydedip yüklemekle sorumludur. Ayrıca, oyun içi dinamikleri kontrol etmek için çeşitli fonksiyonları içerir.


**Önemli Kod Blokları:**
- `LampLoadSystem`: Lambaların durumunu yükler.
  ```cs
  public void LampLoadSystem()
  {
      for(int i = 0; i <= Lamps.Count; i++)
      {
          if(PlayerPrefs.HasKey("Lamp_" + i))
          {
              Lamps[i].enabled = Convert.ToBoolean(PlayerPrefs.GetString("Lamp_" + i.ToString()));
          }
      }
  }
  ```
- `PlayerTransformLoad`: Oyuncu konumunu yükler.
  ```cs
    public void PlayerTransformLoad()
    {
        if(PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            Debug.Log("Transform Update");
            PlayerTransform.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        }
    }
  ```
- `BatteryLoad`: Pil verilerini yükler.
  ```cs
    public void BatteryLoad()
    {
        if(PlayerPrefs.HasKey("BatteryNumber"))
        {
            FlasLight_System.batteryNumber = PlayerPrefs.GetInt("BatteryNumber");
        }
        
        if(PlayerPrefs.HasKey("BatteryEnergy"))
        {
            FL.batteryEnergy = PlayerPrefs.GetFloat("BatteryEnergy");
        }
    }
  ```
- `SaveSystem`: Oyun kaydı yapma işlemi için tetikleyici olan fonksiyon.
  ```cs
  public void SaveSystem()
  {
      if(Input.GetKeyDown(KeyCode.Backspace))
      {
          Debug.Log("Save");
          LampSaveSystem();
          PlayerTransformSave();
          BatterySave();
      }
  }
  ```
- `LampSaveSystem`: Lambaların durumunu kaydeder.
  ```cs
  public void LampSaveSystem()
  {
      for(int i = 0; i <= Lamps.Count - 1; i++)
      {
          PlayerPrefs.SetString("Lamp_" + i, Lamps[i].enabled.ToString()); //lamp_i - "True" or "false"
      }
  }
  ```
- `PlayerTransformSave`: Oyuncu konumunu kaydeder.
  ```cs
  public void PlayerTransformSave()
  {
      PlayerPrefs.SetFloat("PlayerX", PlayerTransform.transform.position.x);
      PlayerPrefs.SetFloat("PlayerY", PlayerTransform.transform.position.y);
      PlayerPrefs.SetFloat("PlayerZ", PlayerTransform.transform.position.z);
  }
  ```
- `BatterySave`: Pil verilerini kaydeder.
  ```cs
  public void BatterySave()
  {
      PlayerPrefs.SetFloat("BatteryEnergy", FL.batteryEnergy);
      PlayerPrefs.SetInt("BatteryNumber", FlasLight_System.batteryNumber);
  }
  ```

---

### 2. GroundControl

`GroundControl` sınıfı, oyuncunun zeminle temasını kontrol eder ve farklı zeminlere temas durumuna göre ses efektleri çalar.

**Önemli Kod Blokları:**
- `OnTriggerStay`: Oyuncunun belirli tipte zeminle temasını kontrol eder ve ses efektlerini tetikler.


---


### 3. InformationPanel

`InformationPanel` sınıfı, nesnelerle etkileşimde bulunulduğunda ekrana bilgi paneli ekranı getiren bir sistemdir. Görsel ve metin öğelerini yönetir.

**Önemli Kod Blokları:**
- `Information`: Bilgi panelini görüntülemek için kullanılan fonksiyon.


---


### 4. LazerSystem

`LazerSystem` sınıfı, oyuncunun bakış yönündeki nesnelerle etkileşimini kontrol eder. Kapıları açma, kapatma, sandıkları kontrol etme gibi işlevlere odaklanır.

**Önemli Kod Blokları:**
- `Update`: Lazer sistemi tarafından sürekli olarak çağrılan ve etkileşim kontrolünü gerçekleştiren fonksiyon.


---


### 5. Resources_Script

`Resources_Script` sınıfı, oyuncunun topladığı kaynakları yönetir ve envanterde görüntülenmesini sağlar.

**Önemli Kod Blokları:**
- `SpriteImage`: Oyuncunun topladığı kaynakların görüntülenmesini sağlayan fonksiyon.

## Kullanım

Proje içindeki her bir sınıf, belirli bir oyun öğesini kontrol etmek veya etkileşimde bulunmak amacıyla tasarlanmıştır. Class'lar arasındaki işbirliği ve etkileşim, Unity ortamında gerçekleştirilmiştir. 
