using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_Group
{
    public class JWThelper
    {
        private static string secret = "asdasdsdfdfgdfgdfgwe1214234@@@asdfasdthtghdfghdfg";


        public static string Encrypt(string userName)
        {
            var payLoad = new Dictionary<string, object>
            {
                { "UserId",123},
                { "UserName",userName}
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payLoad, secret);
            return token;
        }

        public static string Decrypt(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var data = decoder.DecodeToObject<Dictionary<string, string>>(token, secret, verify: true);

                return data["UserName"];
            }
            catch (TokenExpiredException)
            {
                return null;
            }
            catch (SignatureVerificationException)
            {
                return null;
            }
        }
    }
}