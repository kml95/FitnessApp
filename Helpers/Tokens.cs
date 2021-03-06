﻿using FitnessApp.Auth;
using FitnessApp.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitnessApp.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                Id = identity.Claims.Single(c => c.Type.Equals("id")).Value,
                Role = identity.Claims.Single(c => c.Type.Equals("rol")).Value, 
                Auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
                Expires_in = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}
