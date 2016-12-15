using UnityEngine;
using System.Collections;

public class Web : MonoBehaviour {

    
        public string url = "https://easel1.fulgentcorp.com/bifrost/ws.php?json=[{%22action%22:%22run_sql%22},{%22query%22:%22%20INSERT%20INTO%20`Logins`(`login_count`)%20VALUES%20(0)%22},{%22session_key%22:%225baac3e06d00d2fc8086dddd0febaea5e7bfcc72bc197823ff845d9a67d63e9d%22}]";

        public IEnumerator DoWWW()
        {
            WWW www = new WWW(url);
            yield return www;
     
        
            print(www.text);
    }
    
}
