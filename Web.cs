using UnityEngine;
using System.Collections;

public class Web : MonoBehaviour {

    
        public string url = "https://easel1.fulgentcorp.com/bifrost/ws.php?json=[{%22action%22:%22run_sql%22},{%22query%22:%22INSERT%20INTO%20`Logins`(`login_count`)%20VALUES%20(0)%22},{%22session_key%22:%2210ef46780a866cbbe95bddeb46432cbd67177ecde443d822e27780ce4fe36142%22}]";

        public IEnumerator DoWWW()
        {
            WWW www = new WWW(url);
            yield return www;
     
        
            print(www.text);
    }
    
}
