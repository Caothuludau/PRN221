using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BusinessObject
{
    public class BusinessRules
    {
        // Member business rules
        public class MemberRules
        {
            public static bool IsAdmin(string email, string password)
            {
                // Read the JSON file into a string
                string jsonContent = File.ReadAllText("D:\\Ky7\\PRNRepo\\PRN221\\Ass01Solution\\BusinessObject\\appsettings.json");
                JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
                JsonElement root = jsonDocument.RootElement;

                if (root.TryGetProperty("AdminInfo", out JsonElement adminInfoElement))
                {
                    // Access the properties within "AdminInfo"
                    if (adminInfoElement.TryGetProperty("Email", out JsonElement emailElement))
                    {
                        if (!email.Equals(emailElement.GetString())) return false;
                    }

                    if (adminInfoElement.TryGetProperty("Password", out JsonElement passwordElement))
                    {
                        if (!password.Equals(passwordElement.GetString())) return false;
                    }
                    return true;
                }
                else return false;
            }
        }
    }
}
