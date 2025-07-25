using System;
using System.Diagnostics.Metrics;
using System.IO;

namespace minecraftServer_snyc_client_UWP_
{
    public static class DirectoryValidator
    {
        public static bool IsDirectoryValid(string directoryPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(directoryPath) || !Path.IsPathRooted(directoryPath))
                {
                    return false;
                }

                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

                if (!dirInfo.Exists)
                {
                    return false;
                }

                try
                {
                    var dummy = dirInfo.GetFiles().FirstOrDefault();
                }
                catch (UnauthorizedAccessException)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    // 将 programInfomation_current 改为普通类并实现单例
    public class programInfomation_current
    {
        // 静态变量保存单例实例
        private static readonly programInfomation_current instance = new programInfomation_current();

        //成员变量表
        public bool isPath; // 是否存在目标目录

        public bool isServer_exisit; // 服务器是否存在

        public bool isServer_connect; // 服务器是否连接

        public bool user_name_id;

        public bool user_password;

        public string application_log = string.Empty; // 应用程序日志


        // 私有构造函数防止外部实例化
        private programInfomation_current()
        {
            // 成员变量赋值
            isPath = false;
            isServer_exisit = false;
            isServer_connect = false;
            user_name_id = false;
            user_password = false;
        }

        // 公共静态属性提供对实例的全局访问点
        public static programInfomation_current Instance
        {
            get
            {
                return instance;
            }
        }
    }

    public static class server_info
    {
        public static async Task<bool> Online_verify(string server_dest)
        {
            string json_back = string.Empty;
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = await client.GetAsync(server_dest);
                    response.EnsureSuccessStatusCode();
                    json_back = await response.Content.ReadAsStringAsync();

                    using (var doc = System.Text.Json.JsonDocument.Parse(json_back))
                    {
                        var root = doc.RootElement;
                        if (root.TryGetProperty("status", out var statusProp))
                        {
                            if (statusProp.ValueKind == System.Text.Json.JsonValueKind.True)
                                return true;
                            if (statusProp.ValueKind == System.Text.Json.JsonValueKind.String && statusProp.GetString()?.ToLower() == "health")
                                return true;
                            if (statusProp.ValueKind == System.Text.Json.JsonValueKind.Number && statusProp.GetInt32() == 1)
                                return true;
                        }
                    }
                }
            }
            catch
            {
                // 网络或解析异常视为不在线
            }
            return false;
        }
    }
}

