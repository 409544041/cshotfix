/**
 * Auto generated, do not edit it
 *Author lichunlin
 * t_jobBean
 */
using System.IO;
using System.Collections.Generic;
public class t_jobBean
{
    public int t_id;
    public string t_name;
    public string t_desc;
    public string t_skill;
    private static Dictionary<int, t_jobBean> m_Dic = new Dictionary<int, t_jobBean>(); 
    public static t_jobBean GetConfig(int key)
    { 
        t_jobBean bean = null;
        
        if (m_Dic.TryGetValue(key, out bean))
        {
            return bean;
        }
        else
        {
            bean = GetConfigImp(key);
            m_Dic.Add(key, bean);
            return bean;
        }
    }
    public static void ClearConfig()
    {
        m_Dic.Clear();
    }
    private static t_jobBean GetConfigImp(int key)
    {
        t_jobBean bean = null;
        GameDll.Tool.StringBuilder.Append("select * from t_jobBean where t_id = ");
        GameDll.Tool.StringBuilder.Append(key); 
        if(GameDll.DataManager.BeginRead(GameDll.Tool.StringBuilder.ToString()))
        {
            bean = new t_jobBean();
            bean.t_id = GameDll.DataManager.ReadInt();
            bean.t_name = GameDll.DataManager.ReadString();
            bean.t_desc = GameDll.DataManager.ReadString();
            bean.t_skill = GameDll.DataManager.ReadString();
        }
        GameDll.DataManager.EndRead();
        GameDll.Tool.StringBuilder.Clear();
        if(bean == null)
        {
            UnityEngine.Debug.LogError("没有找到配置表，配置表是：t_jobBean Id:"+key);
            return null;
        }
        return bean; 
    }
}