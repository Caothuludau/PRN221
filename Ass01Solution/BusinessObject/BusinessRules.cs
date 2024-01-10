using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BusinessObject
{
    internal class BusinessRules
    {
        // Member business rules
        public class MemberRules
        {
            public static bool IsAdmin(Member member)
            {
                // Read the JSON file into a string
                string jsonContent = File.ReadAllText("appsettings.json");
                JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
                JsonElement root = jsonDocument.RootElement;

                if (root.TryGetProperty("AdminInfo", out JsonElement adminInfoElement))
                {
                    // Access the properties within "AdminInfo"
                    if (adminInfoElement.TryGetProperty("Email", out JsonElement emailElement))
                    {
                        if (member.Email.Equals(emailElement.GetString())) return false;
                    }

                    if (adminInfoElement.TryGetProperty("Password", out JsonElement passwordElement))
                    {
                        if (member.Password != passwordElement.GetString()) return false;
                    }
                    return true;
                }
                else return false;
            }
        }
    }
}
